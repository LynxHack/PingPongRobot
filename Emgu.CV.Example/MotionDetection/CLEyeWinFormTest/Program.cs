using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;

namespace CLEyeWinFormTest
{
    public class Program
    {
        #region [ Camera Parameters ]
        // camera color mode
        public enum CLEyeCameraColorMode
        {
            CLEYE_MONO_PROCESSED,
            CLEYE_COLOR_PROCESSED,
            CLEYE_MONO_RAW,
            CLEYE_COLOR_RAW,
            CLEYE_BAYER_RAW
        };

        // camera resolution
        public enum CLEyeCameraResolution
        {
            CLEYE_QVGA,
            CLEYE_VGA
        };
        // camera parameters
        public enum CLEyeCameraParameter
        {
            // camera sensor parameters
            CLEYE_AUTO_GAIN,			// [false, true]
            CLEYE_GAIN,					// [0, 79]
            CLEYE_AUTO_EXPOSURE,		// [false, true]
            CLEYE_EXPOSURE,				// [0, 511]
            CLEYE_AUTO_WHITEBALANCE,	// [false, true]
            CLEYE_WHITEBALANCE_RED,		// [0, 255]
            CLEYE_WHITEBALANCE_GREEN,	// [0, 255]
            CLEYE_WHITEBALANCE_BLUE,	// [0, 255]
            // camera linear transform parameters
            CLEYE_HFLIP,				// [false, true]
            CLEYE_VFLIP,				// [false, true]
            CLEYE_HKEYSTONE,			// [-500, 500]
            CLEYE_VKEYSTONE,			// [-500, 500]
            CLEYE_XOFFSET,				// [-500, 500]
            CLEYE_YOFFSET,				// [-500, 500]
            CLEYE_ROTATION,				// [-500, 500]
            CLEYE_ZOOM,					// [-500, 500]
            // camera non-linear transform parameters
            CLEYE_LENSCORRECTION1,		// [-500, 500]
            CLEYE_LENSCORRECTION2,		// [-500, 500]
            CLEYE_LENSCORRECTION3,		// [-500, 500]
            CLEYE_LENSBRIGHTNESS		// [-500, 500]
        };
        #endregion

        #region [ CLEyeMulticam Imports ]
        [DllImport("CLEyeMulticam.dll")]
        public static extern int CLEyeGetCameraCount();
        [DllImport("CLEyeMulticam.dll")]
        public static extern Guid CLEyeGetCameraUUID(int camId);
        [DllImport("CLEyeMulticam.dll")]
        public static extern IntPtr CLEyeCreateCamera(Guid camUUID, CLEyeCameraColorMode mode, CLEyeCameraResolution res, float frameRate);
        [DllImport("CLEyeMulticam.dll")]
        public static extern bool CLEyeDestroyCamera(IntPtr camera);
        [DllImport("CLEyeMulticam.dll")]
        public static extern bool CLEyeCameraStart(IntPtr camera);
        [DllImport("CLEyeMulticam.dll")]
        public static extern bool CLEyeCameraStop(IntPtr camera);
        [DllImport("CLEyeMulticam.dll")]
        public static extern bool CLEyeCameraLED(IntPtr camera, bool on);
        [DllImport("CLEyeMulticam.dll")]
        public static extern bool CLEyeSetCameraParameter(IntPtr camera, CLEyeCameraParameter param, int value);
        [DllImport("CLEyeMulticam.dll")]
        public static extern int CLEyeGetCameraParameter(IntPtr camera, CLEyeCameraParameter param);
        [DllImport("CLEyeMulticam.dll")]
        public static extern bool CLEyeCameraGetFrameDimensions(IntPtr camera, ref int width, ref int height);
        [DllImport("CLEyeMulticam.dll")]
        public static extern bool CLEyeCameraGetFrame(IntPtr camera, IntPtr pData, int waitTimeout);

        [DllImport("kernel32.dll")]
        static extern void RtlZeroMemory(IntPtr dst, int length);
        #endregion

        #region [ Program Singleton ]
        private static Program instance;
        public static Program Instance
        {
            get
            {
                if (instance == null)
                    instance = new Program();
                return instance;
            }
        }
        #endregion

        #region [ Variables ]
        MainForm _form;
        IntPtr _ptrBmpPixels;
        bool _threadRunning;
        ManualResetEvent _exitEvent;
        IntPtr _camera;
        #endregion

        public static int CameraCount { get { return CLEyeGetCameraCount(); } }
        public static Guid CameraUUID(int idx) { return CLEyeGetCameraUUID(idx); }

        public Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _form = new MainForm();
            _form.Load += new EventHandler(OnLoaded);
        }

        void OnLoaded(object sender, EventArgs e)
        {
            int w = 0, h = 0;
            _camera = CLEyeCreateCamera(CameraUUID(0), CLEyeCameraColorMode.CLEYE_MONO_RAW, CLEyeCameraResolution.CLEYE_VGA, 30);
            if (_camera == IntPtr.Zero) return;
            CLEyeCameraGetFrameDimensions(_camera, ref w, ref h);
            CreateBitmap(w, h);
            // create thread exit event
            _exitEvent = new ManualResetEvent(false);
            // start capture here
            ThreadPool.QueueUserWorkItem(Capture);
        }

        void CreateBitmap(int w, int h)
        {
            // allocate bitmap memory
            _ptrBmpPixels = Marshal.AllocHGlobal(w * h);
            RtlZeroMemory(_ptrBmpPixels, w * h);

            // create bitmap object
            Bitmap bmpGraph = new Bitmap(w, h, w, PixelFormat.Format8bppIndexed, _ptrBmpPixels);

            // setup gray-scale palette
            ColorPalette GrayPalette = bmpGraph.Palette;
            for (int i = 0; i < GrayPalette.Entries.Length; i++)
                GrayPalette.Entries[i] = Color.FromArgb(i, i, i);
            bmpGraph.Palette = GrayPalette;

            // set bitmap to the picture box
            _form.pictureBox1.Image = bmpGraph;
        }

        // capture thread
        void Capture(object obj)
        {
            _threadRunning = true;
            Random rng = new Random();
            CLEyeCameraStart(_camera);
            while (_threadRunning)
            {
                if(CLEyeCameraGetFrame(_camera, _ptrBmpPixels, 500))
                    _form.pictureBox1.Invalidate();
            }
            CLEyeCameraStop(_camera);
            CLEyeDestroyCamera(_camera);
            _exitEvent.Set();
        }

        public void Run()
        {
            Application.Run(_form);
            // stop capture thread here
            _threadRunning = false;
            _exitEvent.WaitOne(3000);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // check if camera is connected
            if (Program.CameraCount == 0) return;
            Program.Instance.Run();
        }
    }
}
