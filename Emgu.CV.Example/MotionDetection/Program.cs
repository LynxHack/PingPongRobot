using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;


namespace MotionDetection
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
        Form1 _form;
        IntPtr _ptrBmpPixels;
        IntPtr _ptrBmpPixels2;
        bool _threadRunning;
        ManualResetEvent _exitEvent;
        #endregion

        public static int CameraCount { get { return CLEyeGetCameraCount(); } }
        public static Guid CameraUUID(int idx) { return CLEyeGetCameraUUID(idx); }

        public Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _form = new Form1();

            _form.Load += new EventHandler(OnLoaded);
        }
        IntPtr framePtr;
        IntPtr framePtr2;

        void OnLoaded(object sender, EventArgs e)
        {
            int texW = 0, texH = 0;
            int texW2 = 0, texH2 = 0;

            Guid CLEye1UUID = CLEyeGetCameraUUID(0); //Camera 0
            Guid CLEye2UUID = CLEyeGetCameraUUID(1); //Camera 1

            framePtr = CLEyeCreateCamera(CLEye1UUID, CLEyeCameraColorMode.CLEYE_COLOR_PROCESSED, CLEyeCameraResolution.CLEYE_VGA, 60);
            framePtr2 = CLEyeCreateCamera(CLEye2UUID, CLEyeCameraColorMode.CLEYE_COLOR_PROCESSED, CLEyeCameraResolution.CLEYE_VGA, 60);

            if (CLEyeGetCameraCount() == 2)
            {
                CLEyeCameraGetFrameDimensions(framePtr, ref texW, ref texH);
                CLEyeCameraGetFrameDimensions(framePtr2, ref texW2, ref texH2);
            }
            else if(CLEyeGetCameraCount() == 1)
            {
                CLEyeCameraGetFrameDimensions(framePtr, ref texW, ref texH);
            }

            _ptrBmpPixels = Marshal.AllocHGlobal(1280 * 960);
            _ptrBmpPixels2 = Marshal.AllocHGlobal(1280 * 960);

            _exitEvent = new ManualResetEvent(false);

            _threadRunning = true;

            if (CLEyeGetCameraCount() >= 1)
            {
                CLEyeCameraStart(framePtr);
                ThreadPool.QueueUserWorkItem(RunCam1);
            }
            if (CLEyeGetCameraCount() >= 2)
            {
                CLEyeCameraStart(framePtr2);
                ThreadPool.QueueUserWorkItem(RunCam2);
            }
        }

        void RunCam1(object obj)
        {
            while (_threadRunning)
            {
                if (CLEyeCameraGetFrame(framePtr, _ptrBmpPixels, 500))
                {
                    int bitsPerPixel = ((int)System.Drawing.Imaging.PixelFormat.Format32bppRgb & 0xff00) >> 8;
                    int bytesPerPixel = (bitsPerPixel + 7) / 8;
                    int stride = 4 * ((640 * bytesPerPixel + 3) / 4);
                    Bitmap frame1 = new Bitmap(640, 480, stride, System.Drawing.Imaging.PixelFormat.Format32bppRgb, _ptrBmpPixels);
                    Image<Bgr, Byte> RetrievedImage = new Image<Bgr, Byte>(frame1).Resize(_form.imageBox1.Width, _form.imageBox1.Height, INTER.CV_INTER_LINEAR);
                    if (_form.ImageProcessing(RetrievedImage, 0))
                    {
                        _form.UpdateKinematics(RetrievedImage, 0);
                    }
                    _form.imageBox1.Image = RetrievedImage;
                    Image<Bgr, Byte> RetrievedImageLarge = (RetrievedImage).Resize(_form.imageBox3.Width, _form.imageBox3.Height, INTER.CV_INTER_LINEAR);
                    _form.imageBox3.Image = RetrievedImageLarge;

                    _form.imageBox1.Invalidate();
                    GC.Collect();   //Reclaim unused memory
                }
            }
        }

        void RunCam2(object obj)
        {
            while (_threadRunning)
            {
                if (CLEyeCameraGetFrame(framePtr2, _ptrBmpPixels2, 500))
                {
                    int bitsPerPixel = ((int)System.Drawing.Imaging.PixelFormat.Format32bppRgb & 0xff00) >> 8;
                    int bytesPerPixel = (bitsPerPixel + 7) / 8;
                    int stride = 4 * ((640 * bytesPerPixel + 3) / 4);
                    Bitmap frame2 = new Bitmap(640, 480, stride, System.Drawing.Imaging.PixelFormat.Format32bppRgb, _ptrBmpPixels2);
                    Image<Bgr, Byte> RetrievedImage2 = new Image<Bgr, Byte>(frame2).Resize(_form.imageBox6.Width, _form.imageBox6.Height, INTER.CV_INTER_LINEAR);
                    if (_form.ImageProcessing(RetrievedImage2, 1))
                    {
                       // _form.UpdateKinematics(RetrievedImage2, 1);
                    }
                    _form.imageBox6.Image = RetrievedImage2;
                    Image<Bgr, Byte> RetrievedImageLarge = (RetrievedImage2).Resize(_form.imageBox4.Width, _form.imageBox4.Height, INTER.CV_INTER_LINEAR);
                    _form.imageBox4.Image = RetrievedImageLarge;

                    _form.imageBox6.Invalidate();
                    GC.Collect();   //Reclaim unused memory
                }
            }
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