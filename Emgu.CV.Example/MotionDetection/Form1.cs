using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Threading;

using System.Timers;
using System.Diagnostics;

using System.IO;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;

namespace MotionDetection
{
    //118 cm = 1000 counts
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComPortUpdate();
            //set up x data for initial condition and scrolling
            data_array_X[0] = 100;
            for (int i = 1; i < data_array_X.Length; i++)
            {
                data_array_X[i] = i;
                Kalman_array_X[i] = i;
                //data_array_Y[i] = rand.Next(100);
            }
        }

        #region //Look Up Table

        public int returnx(double x)
        {
            if (x > -26.72 && x <= -15.91)
            {
                return 0;
            }
            else if (x > -15.91 && x <= -5.303)
            {
                return 1;
            }
            else if (x > -5.303 && x <= 5.303)
            {
                return 2;
            }
            else if (x > 5.303 && x <= 15.91)
            {
                return 3;
            }
            else if (x > 15.91 && x <= 26.72)
            {
                return 4;
            }

            return 4;
        }


        public int returny(double y)
        {
            if (y > -15.91 && y <= -5.303)
            {
                return 2;
            }
            else if (y > -5.303 && y <= 5.303)
            {
                return 1;
            }
            else if (y > 5.303 && y <= 15.91)
            {
                return 0;
            }

            return 2;
        }

        public List<int> LookUpTable(double x, double y)
        {
            List<int> result = new List<int>();

            int[,] ServoCommandTable = new int[,] { { 52, 52, 52, 128, 128}, 
                                                    { 90, 90, 90, 90, 90}, 
                                                    { 128, 128, 128, 52, 52}};

            int[,] DCMotorCommandTable = new int[,] { { 725, -264, -1252, 264, -725}, 
                                                      { 388, -600, -1600, 600, -388}, 
                                                      { 725, -264, -1252, 264, -725}};

            int col = returnx(x);
            int row = returny(y);

            result.Add(DCMotorCommandTable[row, col]);
            result.Add(ServoCommandTable[row, col]);

            return result;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (DesiredX.Text != "" && DesiredY.Text != "")
            {
                double x = Convert.ToDouble(DesiredX.Text);
                double y = Convert.ToDouble(DesiredY.Text);

                List<int> output = LookUpTable(x, y);

                TransmitToMotor(output[0]);
                TransmitToServo(output[1]);
            }
        }

        private void ContinuousMode_CheckedChanged(object sender, EventArgs e)
        {
            if(ContinuousMode.Checked == true)
            {
                
                RobotTimer.Enabled = true;
            }
            else
            {
                RobotTimer.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                RobotTimer2.Enabled = true;
            }
            else
            {
                RobotTimer2.Enabled = false;
            }
        }

        public void ResetBot()
        {
            if(prevxcommand == 0 && prevycommand == 90)
            {
                return;
            }

            prevxcommand = 0;
            prevycommand = 90;

            TransmitToMotor(0);
            TransmitToServo(90);
        }

        private void RobotTimer2_Tick(object sender, EventArgs e)
        {
                
            double x = Convert.ToDouble((((240 - centroid1.Y) - 130) * 83 / 240 * 35 / 45));
            double y = Convert.ToDouble((((240 - centroid0.Y) - 120 + 28) * 82 / 240));

            DesiredX.Text = x.ToString();
            DesiredY.Text = y.ToString();


            if (x == prevxcommand && y == prevycommand)
            {
                return;
            }


            List<int> output = LookUpTable(x, y);

            prevxcommand = output[0];
            prevycommand = output[1];


            TransmitToMotor(output[0]);
                TransmitToServo(output[1]);
        }

        double prevxcommand = -1000;
        double prevycommand = -1000;
        private void RobotTimer_Tick(object sender, EventArgs e)
        {           
            if (DesiredX.Text != "" && DesiredY.Text != "")
            {
                double x = Convert.ToDouble(DesiredX.Text);
                double y = Convert.ToDouble(DesiredY.Text);
                prevxcommand = x;
                prevycommand = y;
                if (x == prevxcommand && y == prevycommand) {
                    return;
                }

                List<int> output = LookUpTable(x, y);

                TransmitToMotor(output[0]);
                TransmitToServo(output[1]);
            }
        }


        #endregion  

        #region //Kalman Filter

        #region Variables
        float px, py, cx, cy, ix = 100, iy;
        float px2, py2, cx2, cy2, ix2 = 100, iy2;

        #endregion

        #region Plot Variables
        double[] data_array_X = new double[100];
        double[] data_array_Y = new double[100];
        double[] Kalman_array_Y = new double[100];
        double[] Kalman_array_X = new double[100];
        Random rand = new Random();

        double[] data_array_X2 = new double[100];
        double[] data_array_Y2 = new double[100];
        double[] Kalman_array_Y2= new double[100];
        double[] Kalman_array_X2 = new double[100];
        Random rand2 = new Random();
        #endregion

        #region Kalman Filter and Poins Lists
        PointF[] oup = new PointF[2];
        private Kalman kal;
        private SyntheticData syntheticData;
        private List<PointF> mousePoints;
        private List<PointF> kalmanPoints;

        PointF[] oup2 = new PointF[2];
        private Kalman kal2;
        private SyntheticData syntheticData2;
        private List<PointF> mousePoints2;
        private List<PointF> kalmanPoints2;
        #endregion

        public void KalmanFilter(int camID)
        {
            if (camID == 0)
            {
                mousePoints = new List<PointF>();
                kalmanPoints = new List<PointF>();
                kal = new Kalman(4, 2, 0);
                syntheticData = new SyntheticData();
                Matrix<float> state = new Matrix<float>(new float[]
                {
                    0.0f, 0.0f, 0.0f, 0.0f
                });
                kal.CorrectedState = state;
                kal.TransitionMatrix = syntheticData.transitionMatrix;
                kal.MeasurementNoiseCovariance = syntheticData.measurementNoise;
                kal.ProcessNoiseCovariance = syntheticData.processNoise;
                kal.ErrorCovariancePost = syntheticData.errorCovariancePost;
                kal.MeasurementMatrix = syntheticData.measurementMatrix;
            }
            else if(camID == 1)
            {
                mousePoints2 = new List<PointF>();
                kalmanPoints2 = new List<PointF>();
                kal2 = new Kalman(4, 2, 0);
                syntheticData2 = new SyntheticData();
                Matrix<float> state2 = new Matrix<float>(new float[]
                {
                    0.0f, 0.0f, 0.0f, 0.0f
                });
                kal2.CorrectedState = state2;
                kal2.TransitionMatrix = syntheticData2.transitionMatrix;
                kal2.MeasurementNoiseCovariance = syntheticData2.measurementNoise;
                kal2.ProcessNoiseCovariance = syntheticData2.processNoise;
                kal2.ErrorCovariancePost = syntheticData2.errorCovariancePost;
                kal2.MeasurementMatrix = syntheticData2.measurementMatrix;
            }
        }
        public PointF[] filterPoints(PointF pt, int camID)
        {
            PointF[] results = new PointF[2];
            if (camID == 0)
            {
                syntheticData.state[0, 0] = pt.X;
                syntheticData.state[1, 0] = pt.Y;
                Matrix<float> prediction = kal.Predict();
                PointF predictPoint = new PointF(prediction[0, 0], prediction[1, 0]);
                PointF measurePoint = new PointF(syntheticData.GetMeasurement()[0, 0],
                    syntheticData.GetMeasurement()[1, 0]);
                Matrix<float> estimated = kal.Correct(syntheticData.GetMeasurement());
                PointF estimatedPoint = new PointF(estimated[0, 0], estimated[1, 0]);
                syntheticData.GoToNextState();

                results[0] = predictPoint;
                results[1] = estimatedPoint;
                px = predictPoint.X;
                py = predictPoint.Y;
                cx = estimatedPoint.X;
                cy = estimatedPoint.Y;
            }
            else
            {
                syntheticData2.state[0, 0] = pt.X;
                syntheticData2.state[1, 0] = pt.Y;
                Matrix<float> prediction = kal.Predict();
                PointF predictPoint = new PointF(prediction[0, 0], prediction[1, 0]);
                PointF measurePoint = new PointF(syntheticData2.GetMeasurement()[0, 0],
                    syntheticData.GetMeasurement()[1, 0]);
                Matrix<float> estimated = kal.Correct(syntheticData2.GetMeasurement());
                PointF estimatedPoint = new PointF(estimated[0, 0], estimated[1, 0]);
                syntheticData.GoToNextState();
                results[0] = predictPoint;
                results[1] = estimatedPoint;
                px2 = predictPoint.X;
                py2 = predictPoint.Y;
                cx2 = estimatedPoint.X;
                cy2 = estimatedPoint.Y;
            }
            return results;
        }

        public List<float> UpdateKalmanFilter(float ix, float iy, int camID)
        {
            List<float> returnvalue = new List<float>();
            if (camID == 0)
            {
                //set data
                Array.Copy(data_array_Y, 1, data_array_Y, 0, 99);
                data_array_Y[data_array_Y.Length - 1] = iy;
                Array.Copy(data_array_X, 1, data_array_X, 0, 99);
                data_array_X[data_array_X.Length - 1] = ix;

                //update kalman and predict
                PointF inp = new PointF(ix, iy);
                oup = new PointF[2];
                oup = filterPoints(inp, camID);

                PointF[] pts = oup;

                //Set kalman Data
                Array.Copy(Kalman_array_Y, 1, Kalman_array_Y, 0, 99);
                Kalman_array_Y[Kalman_array_Y.Length - 1] = cy;
                Array.Copy(Kalman_array_X, 1, Kalman_array_X, 0, 99);
                Kalman_array_X[Kalman_array_X.Length - 1] = cx;

                //Update();
                //this.Refresh();

                returnvalue.Add(px);
                returnvalue.Add(py);
            }
            else if (camID == 1)
            {
                //set data
                Array.Copy(data_array_Y2, 1, data_array_Y2, 0, 99);
                data_array_Y2[data_array_Y2.Length - 1] = iy2;
                Array.Copy(data_array_X2, 1, data_array_X2, 0, 99);
                data_array_X2[data_array_X2.Length - 1] = ix2;

                //update kalman and predict
                PointF inp2 = new PointF(ix, iy);
                oup2 = new PointF[2];
                oup2 = filterPoints(inp2, camID);

                PointF[] pts2 = oup2;

                //Set kalman Data
                Array.Copy(Kalman_array_Y2, 1, Kalman_array_Y2, 0, 99);
                Kalman_array_Y2[Kalman_array_Y2.Length - 1] = cy2;
                Array.Copy(Kalman_array_X2, 1, Kalman_array_X2, 0, 99);
                Kalman_array_X2[Kalman_array_X2.Length - 1] = cx2;

                returnvalue.Add(px2);
                returnvalue.Add(py2);
            }
            return returnvalue;
        }




        #endregion
        #region //Trajectory Prediction

        public void UpdateKinematics(Image<Bgr, Byte> image, int camID)
        {
            //TO-DO: Convert this velocity into real position 
            //TO-DO: Convert 9.81m/s^2 into pixel acceleration
            Point pos = new Point(0, 0);
            double velx = 0;
            double vely = 0;
            List<float> estimatedvelocities = new List<float>();



            if (camID == 0)
            {
                pos = centroid0;
                time0 = datawatch.ElapsedMilliseconds / 1000.0;
                velx = (centroid0.X - centroid0_prev.X) / (time0 - time_prev0);
                vely = (centroid0.Y - centroid0_prev.Y) / (time0 - time_prev0);

                //estimatedvelocities = UpdateKalmanFilter((float)velx, (float)vely, camID);
                //velx = estimatedvelocities[0];
                //vely = estimatedvelocities[1];
            }
            else if (camID == 1)
            {
                pos = centroid1;
                time1 = datawatch.ElapsedMilliseconds / 1000.0;

                velx = (centroid1.X - centroid1_prev.X) / (time1 - time_prev1);
                vely = (centroid1.Y - centroid1_prev.Y) / (time1 - time_prev1);

                if(vely > 1000)
                {
                    vely = 0;
                }


            }



            //double scale = 100;
            //double accy = -9.81 * scale;
            double accy = -2833.735;

            if (camID == 0)
            {
                Control0XVelBox.BeginInvoke((Action)(() =>
                {
                    Control0XVelBox.Text = "{X=" + Math.Round(velx,2) + "," + "Y=" + Math.Round(vely,2) + "}";
                }));
                centroid0_prev = centroid0;
                time_prev0 = time0;
                double timeinterval = 0.1;

                //if (velx < -20) //draw only if ball is moving right faster than 20 pixels a second
                //{
                //    double height = centroid0.Y - 0.5 * accy * (centroid0.X) / velx;
                //    CvInvoke.cvCircle(image, new Point(320, (int)height), 5, new MCvScalar(0, 255, 0), 3, LINE_TYPE.CV_AA, 0);

                //    if (centroid0.X < 10)
                //    {
                //        FinalPositionBox.BeginInvoke((Action)(() =>
                //        {
                //            FinalPositionBox.Text = "{y= " + (120 - height) * (83.0 / 240.0);
                //        }));
                //    }
                //}

                //for (int i = 0; i < 15; i++) //each time step == 0.1s
                //{
                //    vely = vely - accy * timeinterval;  //Apply gravitational acceleration
                //    pos = new Point(pos.X + (int)(velx * timeinterval), pos.Y + (int)(vely * timeinterval)); //increment position
                //    CvInvoke.cvCircle(image, pos, 3, new MCvScalar(255, 255, 0), 3, LINE_TYPE.CV_AA, 0);
                //}
            }
            else if (camID == 1) //Don't want gravity in top camera
            {
                Control1XVelBox.BeginInvoke((Action)(() =>
                {
                    Control1XVelBox.Text = "{X=" + Math.Round(velx,2) + "," + "Y=" + Math.Round(vely,2) + "}";
                }));

                centroid1_prev = centroid1;
                time_prev1 = time1;
                double timeinterval = 1;

                estimatedvelocities = UpdateKalmanFilter((float)velx, (float)vely, camID);
                velx = estimatedvelocities[0];
                vely = estimatedvelocities[1];

                if (velx > 10)
                {
                    ResetBot();
                }

                MemUsageBox.BeginInvoke((Action)(() =>
                {
                    MemUsageBox.Text = GC.GetTotalMemory(true).ToString();
                }));


                if (velx < -20)
                {
                    for (int i = 0; pos.X > 0; i++) //each time step == 0.1s
                    {
                        timeinterval = pos.X/320 + 0.1;
                        pos = new Point(pos.X + (int)(velx * timeinterval), pos.Y + (int)(vely * timeinterval)); //increment position
                        CvInvoke.cvCircle(image, pos, 3, new MCvScalar(255, 255, 0), 3, LINE_TYPE.CV_AA, 0);
                    }

                    double height = pos.Y;

                    if (height > 230 || height < 10)
                    {
                        height = centroid1.Y;
                    }

                    height = (240 - height) + 10;

                    double realy = (((240 - height) - 130) * 83 / 240 * 35 / 45);
                    if (realy <= -20)
                    {
                        realy = -20;
                    }
                    else if (realy >= 20)
                    {
                        realy = 20;
                    }

                    CvInvoke.cvCircle(image, pos, 5, new MCvScalar(255, 0, 0), 5, LINE_TYPE.CV_AA, 0);

                    DesiredX.BeginInvoke((Action)(() => //Take Over DesiredX control
                    {
                        DesiredX.Text = realy.ToString();
                    }));
                }
                else
                {
                    DesiredX.BeginInvoke((Action)(() => //Take Over DesiredX control
                    {
                        DesiredX.Text = (((240 - centroid1.Y) - 130) * 83 / 240 * 35 / 45).ToString(); ;
                    }));
                }
                //if (velx < -50) //draw only if ball is moving right
                //{
                //    //double height = centroid1.Y + (vely / velx) * (240-centroid1.X); //hi + dy/dx (dx) 
                //    //height = (240 - height)+10;
                //    //double realy = (((240 - height) - 130) * 83 / 240 * 35 / 45);
                //    //if(realy <= -20)
                //    //{
                //    //    realy = -20;
                //    //}
                //    //else if(realy >= 20)
                //    //{
                //    //    realy = 20;
                //    //}

                //    double height = pos.Y;
                //    height = (240 - height) + 10;
                //    double realy = (((240 - height) - 130) * 83 / 240 * 35 / 45);
                //    if (realy <= -20)
                //    {
                //        realy = -20;
                //    }
                //    else if (realy >= 20)
                //    {
                //        realy = 20;
                //    }

                //    //estimatedvelocities = UpdateKalmanFilter((float)time1, (float)height, camID);
                //    //height = estimatedvelocities[1];

                //    CvInvoke.cvCircle(image, new Point(0, (int)height), 5, new MCvScalar(255, 0, 0), 5, LINE_TYPE.CV_AA, 0);

                //    DesiredX.BeginInvoke((Action)(() => //Take Over DesiredX control
                //    {
                //        DesiredX.Text = realy.ToString();
                //    }));

                //    //if (centroid1.X > 220)
                //    //{
                //    //    FinalPositionBox2.BeginInvoke((Action)(() =>
                //    //    {
                //    //        FinalPositionBox2.Text = "{x= " + (120 - height) * (82.5 / 240.0);
                //    //    }));
                //    //}
                //}




                //for (int i = 0; i < 15; i++) //each time step == 0.1s
                //{
                //    pos = new Point(pos.X + (int)(velx * timeinterval), pos.Y + (int)(vely * timeinterval)); //increment position
                //    CvInvoke.cvCircle(image, pos, 3, new MCvScalar(255, 255, 0), 3, LINE_TYPE.CV_AA, 0);
                //}
            }


        }

        #endregion

        #region Globle Var

        private Capture capture;
        private bool captureInProgress;
        private bool imageInProgress;
        String filenameload;

        Image<Bgr, Byte> ImageHSVwheel = new Image<Bgr, Byte>(@"HSV-Wheel.png");
        Image<Hsv, Byte> hsvImage = new Image<Hsv, Byte>(0, 0);
        int diff_LH;
        #endregion

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

        #region Image Processing

        public static class globals
        {
            public static Image<Bgr, Byte> ImageFrame0;
            public static Image<Bgr, Byte> ImageFrame1;
        }

        public bool ImageProcessing(Image<Bgr, Byte> ImageFrame, int camID) //return true or false if a ball is detected
        {
            bool balldetected = false;
            if (camID == 0)
            {
                Image<Gray, Byte> ImageFrameDetection = cvAndHsvImage( //grayscale conversion
                    ImageFrame,
                   Convert.ToInt32(numeric_HL.Value), Convert.ToInt32(numeric_HH.Value),
                   Convert.ToInt32(numeric_SL.Value), Convert.ToInt32(numeric_SH.Value),
                   Convert.ToInt32(numeric_VL.Value), Convert.ToInt32(numeric_VH.Value),
                   checkBox_EH.Checked, checkBox_ES.Checked, checkBox_EV.Checked, checkBox_IV.Checked);

                if (iB2C == 0) imageBox2.Image = ImageFrameDetection;

                if (iB2C == 1)
                {
                    Image<Bgr, Byte> imgF = new Image<Bgr, Byte>(ImageFrame.Width, ImageFrame.Height);
                    Image<Bgr, Byte> imgD = ImageFrameDetection.Convert<Bgr, Byte>();
                    CvInvoke.cvAnd(ImageFrame, imgD, imgF, IntPtr.Zero);
                    imageBox2.Image = imgF;
                }

                if (iB2C == 2)
                {
                    Image<Bgr, Byte> imgF = new Image<Bgr, Byte>(ImageFrame.Width, ImageFrame.Height);
                    Image<Bgr, Byte> imgD = ImageFrameDetection.Convert<Bgr, Byte>();
                    CvInvoke.cvAnd(ImageFrame, imgD, imgF, IntPtr.Zero);
                    for (int x = 0; x < imgF.Width; x++)
                        for (int y = 0; y < imgF.Height; y++)
                        {
                            {
                                Bgr c = imgF[y, x];
                                if (c.Red == 0 && c.Blue == 0 && c.Green == 0)
                                {
                                    imgF[y, x] = new Bgr(255, 255, 255);
                                }
                            }
                        }
                    imageBox2.Image = imgF;
                }

                if (checkBox_VAr.Checked)
                {
                    trackBar_VAr.BeginInvoke((Action)(() =>
                    {
                        balldetected = RecDetection(ImageFrameDetection, ImageFrame, trackBar_VAr.Value, camID);
                    }));
                }

                Image<Gray, Byte> ImageHSVwheelDetection = cvAndHsvImage(
                       ImageHSVwheel,
                       Convert.ToInt32(numeric_HL.Value), Convert.ToInt32(numeric_HH.Value),
                       Convert.ToInt32(numeric_SL.Value), Convert.ToInt32(numeric_SH.Value),
                       Convert.ToInt32(numeric_VL.Value), Convert.ToInt32(numeric_VH.Value),
                       checkBox_EH.Checked, checkBox_ES.Checked, checkBox_EV.Checked, checkBox_IV.Checked);
            }
            else if (camID == 1)
            {
                Image<Gray, Byte> ImageFrameDetection = cvAndHsvImage( //grayscale conversion
                    ImageFrame,
                   Convert.ToInt32(numeric_HL.Value), Convert.ToInt32(numeric_HH.Value),
                   Convert.ToInt32(numeric_SL.Value), Convert.ToInt32(numeric_SH.Value),
                   Convert.ToInt32(numeric_VL.Value), Convert.ToInt32(numeric_VH.Value),
                   checkBox_EH.Checked, checkBox_ES.Checked, checkBox_EV.Checked, checkBox_IV.Checked);
                if (iB2C == 0)
                {

                    imageBox5.Image = ImageFrameDetection;
                }

                if (iB2C == 1)
                {
                    Image<Bgr, Byte> imgF = new Image<Bgr, Byte>(ImageFrame.Width, ImageFrame.Height);
                    Image<Bgr, Byte> imgD = ImageFrameDetection.Convert<Bgr, Byte>();
                    CvInvoke.cvAnd(ImageFrame, imgD, imgF, IntPtr.Zero);
                    imageBox5.Image = imgF;
                }

                if (iB2C == 2)
                {
                    Image<Bgr, Byte> imgF = new Image<Bgr, Byte>(ImageFrame.Width, ImageFrame.Height);
                    Image<Bgr, Byte> imgD = ImageFrameDetection.Convert<Bgr, Byte>();
                    CvInvoke.cvAnd(ImageFrame, imgD, imgF, IntPtr.Zero);
                    for (int x = 0; x < imgF.Width; x++)
                        for (int y = 0; y < imgF.Height; y++)
                        {
                            {
                                Bgr c = imgF[y, x];
                                if (c.Red == 0 && c.Blue == 0 && c.Green == 0)
                                {
                                    imgF[y, x] = new Bgr(255, 255, 255);
                                }
                            }
                        }
                    imageBox5.Image = imgF;
                }

                if (checkBox_VAr.Checked)
                {
                    trackBar_VAr.BeginInvoke((Action)(() =>
                    {
                        balldetected = RecDetection(ImageFrameDetection, ImageFrame, trackBar_VAr.Value, camID);
                    }));
                }

                Image<Gray, Byte> ImageHSVwheelDetection = cvAndHsvImage(
                       ImageHSVwheel,
                       Convert.ToInt32(numeric_HL.Value), Convert.ToInt32(numeric_HH.Value),
                       Convert.ToInt32(numeric_SL.Value), Convert.ToInt32(numeric_SH.Value),
                       Convert.ToInt32(numeric_VL.Value), Convert.ToInt32(numeric_VH.Value),
                       checkBox_EH.Checked, checkBox_ES.Checked, checkBox_EV.Checked, checkBox_IV.Checked);
            }
            return balldetected;
        }

        IntPtr storage = CvInvoke.cvCreateMemStorage(0);
        Point centroid0 = new Point(0, 0);
        Point centroid1 = new Point(0, 0);
        Point centroid0_prev = new Point(0, 0);
        Point centroid1_prev = new Point(0, 0);
        double time0 = 0;
        double time_prev0 = 0;
        double time1 = 0;
        double time_prev1 = 0;

        private bool RecDetection(Image<Gray, Byte> img, Image<Bgr, Byte> showRecOnImg, int areaV, int camID)
        {
            bool checkdetection = false;
            Image<Gray, Byte> imgForContour = new Image<Gray, byte>(img.Width, img.Height);
            CvInvoke.cvCopy(img, imgForContour, System.IntPtr.Zero);

            IntPtr contour = new IntPtr();

            CvInvoke.cvFindContours(
                imgForContour,
                storage,
                ref contour,
                System.Runtime.InteropServices.Marshal.SizeOf(typeof(MCvContour)),
                Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL,
                Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE,
                new Point(0, 0));

            Seq<Point> seq = new Seq<Point>(contour, null);
            if (seq.Ptr.ToInt64() == 0 && camID == 1)
            {
                //KalmanFilter(camID);
                ResetBot();
            }

            

            for (; seq != null && seq.Ptr.ToInt64() != 0; seq = seq.HNext)
            {
                Rectangle bndRec = CvInvoke.cvBoundingRect(seq, 2);
                double areaC = CvInvoke.cvContourArea(seq, MCvSlice.WholeSeq, 1) * -1;
                if (areaC > areaV)
                {
                    if (camID == 0)
                    {
                        centroid0 = new Point(bndRec.X + bndRec.Width / 2, bndRec.Y + bndRec.Height / 2);
                        Camera0XPosBox.Text = centroid0.ToString();
                        //DesiredY.Text = (((240-centroid0.Y)-120+28)*82/240).ToString();
                    }
                    else if (camID == 1)
                    {
                        centroid1 = new Point(bndRec.X + bndRec.Width / 2, bndRec.Y + bndRec.Height / 2);
                        //try
                        //{
                        //    List<float> estimatedvelocities = UpdateKalmanFilter((float)((double)sw.ElapsedMilliseconds / 1000.0), (float)centroid1.Y, 0);
                        //    centroid1 = new Point((int)estimatedvelocities[0], (int)estimatedvelocities[1]);
                        //}
                        //catch { }

                        Camera1XPosBox.Text = centroid1.ToString();
                        //DesiredX.Text = (((240-centroid1.Y)-130) * 83 / 240 *35 / 45).ToString();
                    }
                    checkdetection = true;
                    CvInvoke.cvCircle(showRecOnImg, new Point(bndRec.X + bndRec.Width / 2, bndRec.Y + bndRec.Height / 2), (int)((bndRec.Width / 2 + bndRec.Height / 2) / 2), new MCvScalar(0, 255, 0), 4, LINE_TYPE.CV_AA, 0);
                    if (startlog == true)
                    {
                        if (camID == 0)
                            Cam0TextBox.AppendText(Math.Round((double)sw.ElapsedMilliseconds / 1000.0, 2) + "\t" + (bndRec.X + bndRec.Width / 2) + "\t" + (bndRec.Y + bndRec.Height / 2) + "\n");
                        else if (camID == 1)
                            Cam1TextBox.AppendText(Math.Round((double)sw.ElapsedMilliseconds / 1000.0, 2) + "\t" + (bndRec.X + bndRec.Width / 2) + "\t" + (bndRec.Y + bndRec.Height / 2) + "\n");
                    }
                }
            }
            return checkdetection;
        }

        Stopwatch datawatch = new Stopwatch();
        private void checkBox_VAr_CheckedChanged(object sender, EventArgs e)
        {
            KalmanFilter(0); //initialize kalman filter cam 1

            if (CLEyeGetCameraCount() > 1)
            {
                KalmanFilter(1); //initialize kalman filter cam 1
            }
            if (checkBox_VAr.Checked == true)
            {
                datawatch.Start();
                UpdateData.Interval = 10; //10ms interval
                UpdateData.Enabled = true;
            }
            else
            {
                UpdateData.Enabled = false;
            }
        }

        private Image<Gray, Byte> cvAndHsvImage(Image<Bgr, Byte> imgFame, int L1, int H1, int L2, int H2, int L3, int H3, bool H, bool S, bool V, bool I)
        {
            Image<Hsv, Byte> hsvImage = imgFame.Convert<Hsv, Byte>();
            Image<Gray, Byte> ResultImage = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);
            Image<Gray, Byte> ResultImageH = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);
            Image<Gray, Byte> ResultImageS = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);
            Image<Gray, Byte> ResultImageV = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);

            Image<Gray, Byte> img1 = inRangeImage(hsvImage, L1, H1, 0);
            Image<Gray, Byte> img2 = inRangeImage(hsvImage, L2, H2, 1);
            Image<Gray, Byte> img3 = inRangeImage(hsvImage, L3, H3, 2);
            Image<Gray, Byte> img4 = inRangeImage(hsvImage, 0, L1, 0);
            Image<Gray, Byte> img5 = inRangeImage(hsvImage, H1, 180, 0);

            #region checkBox Color Mode

            if (H)
            {
                if (I)
                {
                    CvInvoke.cvOr(img4, img5, img4, System.IntPtr.Zero);
                    ResultImageH = img4;
                }
                else { ResultImageH = img1; }
            }

            if (S) ResultImageS = img2;
            if (V) ResultImageV = img3;

            if (H && !S && !V) ResultImage = ResultImageH;
            if (!H && S && !V) ResultImage = ResultImageS;
            if (!H && !S && V) ResultImage = ResultImageV;

            if (H && S && !V)
            {
                CvInvoke.cvAnd(ResultImageH, ResultImageS, ResultImageH, System.IntPtr.Zero);
                ResultImage = ResultImageH;
            }

            if (H && !S && V)
            {
                CvInvoke.cvAnd(ResultImageH, ResultImageV, ResultImageH, System.IntPtr.Zero);
                ResultImage = ResultImageH;
            }

            if (!H && S && V)
            {
                CvInvoke.cvAnd(ResultImageS, ResultImageV, ResultImageS, System.IntPtr.Zero);
                ResultImage = ResultImageS;
            }

            if (H && S && V)
            {
                CvInvoke.cvAnd(ResultImageH, ResultImageS, ResultImageH, System.IntPtr.Zero);
                CvInvoke.cvAnd(ResultImageH, ResultImageV, ResultImageH, System.IntPtr.Zero);
                ResultImage = ResultImageH;
            }
            #endregion

            CvInvoke.cvErode(ResultImage, ResultImage, (IntPtr)null, 1);

            return ResultImage;
        }
        private Image<Gray, Byte> inRangeImage(Image<Hsv, Byte> hsvImage, int Lo, int Hi, int con)
        {
            Image<Gray, Byte> ResultImage = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);
            Image<Gray, Byte> IlowCh = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height, new Gray(Lo));
            Image<Gray, Byte> IHiCh = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height, new Gray(Hi));
            try
            {
                CvInvoke.cvInRange(hsvImage[con], IlowCh, IHiCh, ResultImage);
            }
            catch { }
            return ResultImage;
        }

        private int[] scaleImage(int wP, int hP)
        {
            int[] dR = new int[2];
            int ra;
            if (wP != 0)
            {
                ra = (100 * 320) / wP;
                wP = 320;
                hP = (hP * ra) / 100;
                if (hP != 0 && hP > 240)
                {
                    ra = (100 * 240) / hP;
                    hP = 240;
                    wP = (wP * ra) / 100;
                }
                dR[0] = wP;
                dR[1] = hP;
            }
            return dR;
        }

        #endregion

        #region // Tooth Even

        private void numeric_Lo_ValueChanged(object sender, EventArgs e)
        {
            trackBar_HL.Value = Convert.ToInt32(numeric_HL.Value);
            trackBar_SL.Value = Convert.ToInt32(numeric_SL.Value);
            trackBar_VL.Value = Convert.ToInt32(numeric_VL.Value);
        }
        private void numeric_Hi_ValueChanged(object sender, EventArgs e)
        {
            trackBar_HH.Value = Convert.ToInt32(numeric_HH.Value);
            trackBar_SH.Value = Convert.ToInt32(numeric_SH.Value);
            trackBar_VH.Value = Convert.ToInt32(numeric_VH.Value);

        }
        private void numeric_VAr_ValueChanged(object sender, EventArgs e)
        {
            trackBar_VAr.Value = Convert.ToInt32(numeric_VAr.Value);
        }

        private void trackBar_Lo_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar_HL.Value >= trackBar_HH.Value && !checkBox_LH.Checked)
                trackBar_HH.Value = trackBar_HL.Value;
            if (checkBox_LH.Checked && trackBar_HL.Value + diff_LH <= 180)
                trackBar_HH.Value = trackBar_HL.Value + diff_LH;
            numeric_HL.Value = trackBar_HL.Value;
            numeric_SL.Value = trackBar_SL.Value;
            numeric_VL.Value = trackBar_VL.Value;
        }
        private void trackBar_Hi_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar_HH.Value <= trackBar_HL.Value && !checkBox_LH.Checked)
                trackBar_HL.Value = trackBar_HH.Value;

            if (checkBox_LH.Checked && trackBar_HH.Value - diff_LH >= 0)
                trackBar_HL.Value = trackBar_HH.Value - diff_LH;

            numeric_HH.Value = trackBar_HH.Value;
            numeric_SH.Value = trackBar_SH.Value;
            numeric_VH.Value = trackBar_VH.Value;
        }
        private void trackBar_VAr_ValueChanged(object sender, EventArgs e)
        {
            numeric_VAr.Value = trackBar_VAr.Value;
        }

        private void checkBox_LH_CheckedChanged(object sender, EventArgs e)
        {
            diff_LH = trackBar_HH.Value - trackBar_HL.Value;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            captureInProgress = false;
            OpenFileDialog OpenFile = new OpenFileDialog();
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                filenameload = OpenFile.FileName;
                imageInProgress = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        { 
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            trackBar_HH.Value = 0;
            trackBar_HL.Value = 0;
            trackBar_SH.Value = 255;
            trackBar_SL.Value = 0;
            trackBar_VH.Value = 255;
            trackBar_VL.Value = 0;
            checkBox_LH.Checked = false;
            checkBox_IV.Checked = false;
        }

        int iB2C;

        private void imageBox2_Click(object sender, EventArgs e)
        {
            iB2C++;
            if (iB2C > 2) iB2C = 0;
        }


        double position, velHz, velRPM;

        //ConcurrentQueue<int> dataQueue = new ConcurrentQueue<int>();
        private void serCom_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte;

            while (serCom.BytesToRead > 0)
            {
                newByte = serCom.ReadByte();
                //dataQueue.Enqueue(newByte);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serCom.Close();
            serComArduino.Close();
        }

        #endregion

        #region //Data Logging
        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            Cam1TextBox.Clear();
            Cam0TextBox.Clear();
        }



        Stopwatch sw;
        bool startlog = false;



        private void StartLogButton_Click(object sender, EventArgs e)
        {
            if (startlog == false)
            {
                startlog = true;
                StartLogButton.Text = "Stop Logging";
                StartLogButton.BackColor = Color.Red;
                sw = Stopwatch.StartNew();
            }
            else
            {
                startlog = false;
                StartLogButton.Text = "Start Logging";
                StartLogButton.BackColor = Color.Green;
            }
        }

        private void SaveDataButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog datasave = new SaveFileDialog();
            datasave.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (datasave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter datalog = new StreamWriter(datasave.FileName);
                datalog.WriteLine("X \t Y");
                List<string> xydata = Cam0TextBox.Text.Split('\n').ToList();
                xydata.ToArray().ToString().Split('\t').ToList();
                datalog.WriteLine("Camera #0 \n" + Cam0TextBox + "\n\n");
                datalog.WriteLine("Camera #1 \n" + Cam1TextBox);
            }
        }
        #endregion

        #region //Serial Communication

        private void ComPortUpdate()
        {
            cmbComPort.Items.Clear();
            string[] comPortArray = System.IO.Ports.SerialPort.GetPortNames().ToArray();
            Array.Reverse(comPortArray);
            cmbComPort.Items.AddRange(comPortArray);
            cmbComPort2.Items.AddRange(comPortArray);
            if (cmbComPort.Items.Count != 0)
                cmbComPort.SelectedIndex = 0;
            if (cmbComPort2.Items.Count != 0)
                cmbComPort2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                if (cmbComPort.Items.Count > 0)
                {
                    try
                    {
                        serCom.BaudRate = Convert.ToInt16(txtBaudRate.Text);
                        serCom.PortName = cmbComPort.SelectedItem.ToString();
                        serCom.Open();

                        btnConnect.Text = "Disconnect";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    serCom.Close();
                    btnConnect.Text = "Connect";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void bntConnect2_Click(object sender, EventArgs e)
        {
            if (bntConnect2.Text == "Connect")
            {
                if (cmbComPort2.Items.Count > 0)
                {
                    try
                    {
                        serComArduino.BaudRate = Convert.ToInt16(txtBaudRate.Text);
                        serComArduino.PortName = cmbComPort.SelectedItem.ToString();
                        serComArduino.Open();

                        bntConnect2.Text = "Disconnect";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    serComArduino.Close();
                    bntConnect2.Text = "Connect";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void transmitbytes(int byte1, int byte2, int byte3)
        {
            byte[] TxBytes = new Byte[3];

            try
            {
                if (serCom.IsOpen)
                {
                    TxBytes[0] = Convert.ToByte(byte1);
                    serCom.Write(TxBytes, 0, 1);

                    TxBytes[1] = Convert.ToByte(byte1);
                    serCom.Write(TxBytes, 1, 1);

                    TxBytes[2] = Convert.ToByte(byte3);
                    serCom.Write(TxBytes, 2, 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void TransmitToServo(int datasend)
        {
            byte[] TxBytes = new Byte[1];

            try
            {
                if (serComArduino.IsOpen)
                {
                    TxBytes[0] = Convert.ToByte(datasend);
                    serComArduino.Write(TxBytes, 0, 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        public void TransmitToMotor(int dataSend)
        {
            byte[] TxBytes = new Byte[3];

            try
            {
                if (serCom.IsOpen)
                {
                    int MSByte = (dataSend >> 8) & 0xFF;
                    int LSByte = dataSend & 0xFF;
                    if (txtByte1.Text != "")
                    {
                        TxBytes[0] = Convert.ToByte(255);
                        TxBytes[1] = Convert.ToByte(MSByte);
                        TxBytes[2] = Convert.ToByte(LSByte);
                        serCom.Write(TxBytes, 0, 1);
                        serCom.Write(TxBytes, 1, 1);
                        serCom.Write(TxBytes, 2, 1);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        private void btnResetPosition_Click(object sender, EventArgs e)
        {
            position = 0;
        }

        private void button1_Click_1(object sender, EventArgs e) //Servo motor transmit
        {
            byte[] TxBytes = new Byte[1];

            try
            {
                if (serComArduino.IsOpen)
                {
                    TxBytes[0] = Convert.ToByte(Convert.ToInt32(ServoCommandBox.Text));
                    serComArduino.Write(TxBytes, 0, 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnTransmitToComPort_Click_1(object sender, EventArgs e) //DC motor transmit
        {
            byte[] TxBytes = new Byte[3];

            try
            {
                if (serCom.IsOpen)
                {
                    int dataSend = Convert.ToInt32(txtByte1.Text);
                    int MSByte = (dataSend >> 8) & 0xFF;
                    int LSByte = dataSend & 0xFF;
                    if (txtByte1.Text != "")
                    {
                        TxBytes[0] = Convert.ToByte(255);
                        TxBytes[1] = Convert.ToByte(MSByte);
                        TxBytes[2] = Convert.ToByte(LSByte);
                        serCom.Write(TxBytes, 0, 1);
                        serCom.Write(TxBytes, 1, 1);
                        serCom.Write(TxBytes, 2, 1);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion
    }
}

