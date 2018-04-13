namespace MotionDetection
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.UpdateData = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmbComPort = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtBaudRate = new System.Windows.Forms.ToolStripTextBox();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.cmbComPort2 = new System.Windows.Forms.ToolStripComboBox();
            this.bntConnect2 = new System.Windows.Forms.ToolStripButton();
            this.serCom = new System.IO.Ports.SerialPort(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.MemUsageBox = new System.Windows.Forms.TextBox();
            this.ContinuousMode = new System.Windows.Forms.CheckBox();
            this.ComputeCmdButton = new System.Windows.Forms.Button();
            this.TransmitPositionButton = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtByte1 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.ServoCommandBox = new System.Windows.Forms.TextBox();
            this.DesiredY = new System.Windows.Forms.TextBox();
            this.DesiredX = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.btnTransmitToComPort = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.FinalPositionBox2 = new System.Windows.Forms.TextBox();
            this.FinalPositionBox = new System.Windows.Forms.TextBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.RealPos1 = new System.Windows.Forms.TextBox();
            this.RealPos0 = new System.Windows.Forms.TextBox();
            this.RealVel1 = new System.Windows.Forms.TextBox();
            this.RealVel0 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.Camera1XPosBox = new System.Windows.Forms.TextBox();
            this.Camera0XPosBox = new System.Windows.Forms.TextBox();
            this.Control1XVelBox = new System.Windows.Forms.TextBox();
            this.Control0XVelBox = new System.Windows.Forms.TextBox();
            this.Cam0TextBox = new System.Windows.Forms.TextBox();
            this.Cam1TextBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_LH = new System.Windows.Forms.CheckBox();
            this.checkBox_IV = new System.Windows.Forms.CheckBox();
            this.checkBox_EV = new System.Windows.Forms.CheckBox();
            this.checkBox_ES = new System.Windows.Forms.CheckBox();
            this.checkBox_EH = new System.Windows.Forms.CheckBox();
            this.numeric_SL = new System.Windows.Forms.NumericUpDown();
            this.numeric_HL = new System.Windows.Forms.NumericUpDown();
            this.numeric_VL = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_VL = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_SL = new System.Windows.Forms.TrackBar();
            this.trackBar_HL = new System.Windows.Forms.TrackBar();
            this.trackBar_VH = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_SH = new System.Windows.Forms.NumericUpDown();
            this.numeric_HH = new System.Windows.Forms.NumericUpDown();
            this.trackBar_SH = new System.Windows.Forms.TrackBar();
            this.numeric_VH = new System.Windows.Forms.NumericUpDown();
            this.trackBar_HH = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_VAr = new System.Windows.Forms.CheckBox();
            this.trackBar_VAr = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.numeric_VAr = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.imageBox6 = new Emgu.CV.UI.ImageBox();
            this.label9 = new System.Windows.Forms.Label();
            this.imageBox5 = new Emgu.CV.UI.ImageBox();
            this.label8 = new System.Windows.Forms.Label();
            this.StartLogButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.SaveDataButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.serComArduino = new System.IO.Ports.SerialPort(this.components);
            this.RobotTimer = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.RobotTimer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VAr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VAr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateData
            // 
            this.UpdateData.Interval = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbComPort,
            this.toolStripLabel1,
            this.txtBaudRate,
            this.btnConnect,
            this.toolStripButton1,
            this.cmbComPort2,
            this.bntConnect2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1407, 25);
            this.toolStrip1.TabIndex = 82;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmbComPort
            // 
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(120, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Baud Rate:";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(70, 25);
            this.txtBaudRate.Text = "9600";
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(56, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // cmbComPort2
            // 
            this.cmbComPort2.Name = "cmbComPort2";
            this.cmbComPort2.Size = new System.Drawing.Size(120, 25);
            // 
            // bntConnect2
            // 
            this.bntConnect2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bntConnect2.Image = ((System.Drawing.Image)(resources.GetObject("bntConnect2.Image")));
            this.bntConnect2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntConnect2.Name = "bntConnect2";
            this.bntConnect2.Size = new System.Drawing.Size(56, 22);
            this.bntConnect2.Text = "Connect";
            this.bntConnect2.Click += new System.EventHandler(this.bntConnect2_Click);
            // 
            // serCom
            // 
            this.serCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serCom_DataReceived);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.label32);
            this.tabPage3.Controls.Add(this.MemUsageBox);
            this.tabPage3.Controls.Add(this.ContinuousMode);
            this.tabPage3.Controls.Add(this.ComputeCmdButton);
            this.tabPage3.Controls.Add(this.TransmitPositionButton);
            this.tabPage3.Controls.Add(this.textBox5);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.txtByte1);
            this.tabPage3.Controls.Add(this.textBox6);
            this.tabPage3.Controls.Add(this.ServoCommandBox);
            this.tabPage3.Controls.Add(this.DesiredY);
            this.tabPage3.Controls.Add(this.DesiredX);
            this.tabPage3.Controls.Add(this.label38);
            this.tabPage3.Controls.Add(this.label39);
            this.tabPage3.Controls.Add(this.btnTransmitToComPort);
            this.tabPage3.Controls.Add(this.label40);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.label30);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.label34);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1412, 642);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Serial Communication";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(24, 225);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(116, 20);
            this.label32.TabIndex = 85;
            this.label32.Text = "Memory Usage";
            // 
            // MemUsageBox
            // 
            this.MemUsageBox.Location = new System.Drawing.Point(28, 248);
            this.MemUsageBox.Multiline = true;
            this.MemUsageBox.Name = "MemUsageBox";
            this.MemUsageBox.Size = new System.Drawing.Size(112, 22);
            this.MemUsageBox.TabIndex = 84;
            // 
            // ContinuousMode
            // 
            this.ContinuousMode.AutoSize = true;
            this.ContinuousMode.Location = new System.Drawing.Point(787, 211);
            this.ContinuousMode.Name = "ContinuousMode";
            this.ContinuousMode.Size = new System.Drawing.Size(109, 17);
            this.ContinuousMode.TabIndex = 52;
            this.ContinuousMode.Text = "Continuous Mode";
            this.ContinuousMode.UseVisualStyleBackColor = true;
            this.ContinuousMode.CheckedChanged += new System.EventHandler(this.ContinuousMode_CheckedChanged);
            // 
            // ComputeCmdButton
            // 
            this.ComputeCmdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComputeCmdButton.Location = new System.Drawing.Point(787, 138);
            this.ComputeCmdButton.Name = "ComputeCmdButton";
            this.ComputeCmdButton.Size = new System.Drawing.Size(195, 35);
            this.ComputeCmdButton.TabIndex = 51;
            this.ComputeCmdButton.Text = "Compute Command";
            this.ComputeCmdButton.UseVisualStyleBackColor = true;
            this.ComputeCmdButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // TransmitPositionButton
            // 
            this.TransmitPositionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransmitPositionButton.Location = new System.Drawing.Point(1023, 138);
            this.TransmitPositionButton.Name = "TransmitPositionButton";
            this.TransmitPositionButton.Size = new System.Drawing.Size(207, 35);
            this.TransmitPositionButton.TabIndex = 50;
            this.TransmitPositionButton.Text = "Transmit Position";
            this.TransmitPositionButton.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1113, 82);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 49;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1020, 85);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 13);
            this.label23.TabIndex = 48;
            this.label23.Text = "Angle Command";
            // 
            // txtByte1
            // 
            this.txtByte1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByte1.Location = new System.Drawing.Point(138, 46);
            this.txtByte1.Name = "txtByte1";
            this.txtByte1.Size = new System.Drawing.Size(104, 26);
            this.txtByte1.TabIndex = 44;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(857, 82);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 27;
            // 
            // ServoCommandBox
            // 
            this.ServoCommandBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServoCommandBox.Location = new System.Drawing.Point(469, 46);
            this.ServoCommandBox.Multiline = true;
            this.ServoCommandBox.Name = "ServoCommandBox";
            this.ServoCommandBox.Size = new System.Drawing.Size(100, 26);
            this.ServoCommandBox.TabIndex = 25;
            // 
            // DesiredY
            // 
            this.DesiredY.Location = new System.Drawing.Point(1113, 42);
            this.DesiredY.Name = "DesiredY";
            this.DesiredY.Size = new System.Drawing.Size(100, 20);
            this.DesiredY.TabIndex = 18;
            // 
            // DesiredX
            // 
            this.DesiredX.Location = new System.Drawing.Point(857, 42);
            this.DesiredX.Name = "DesiredX";
            this.DesiredX.Size = new System.Drawing.Size(100, 20);
            this.DesiredX.TabIndex = 16;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(24, 52);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(81, 20);
            this.label38.TabIndex = 47;
            this.label38.Text = "Set Count";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(24, 80);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(136, 20);
            this.label39.TabIndex = 46;
            this.label39.Text = "(-32767 to 32767)";
            // 
            // btnTransmitToComPort
            // 
            this.btnTransmitToComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransmitToComPort.Location = new System.Drawing.Point(28, 113);
            this.btnTransmitToComPort.Name = "btnTransmitToComPort";
            this.btnTransmitToComPort.Size = new System.Drawing.Size(214, 35);
            this.btnTransmitToComPort.TabIndex = 45;
            this.btnTransmitToComPort.Text = "Transmit Commands";
            this.btnTransmitToComPort.UseVisualStyleBackColor = true;
            this.btnTransmitToComPort.Click += new System.EventHandler(this.btnTransmitToComPort_Click_1);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(24, 27);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(105, 20);
            this.label40.TabIndex = 43;
            this.label40.Text = "Motor Control";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(784, 85);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(72, 13);
            this.label33.TabIndex = 26;
            this.label33.Text = "DC Command";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(336, 49);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(127, 20);
            this.label35.TabIndex = 24;
            this.label35.Text = "Servo Command";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(25, 160);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(117, 13);
            this.label31.TabIndex = 19;
            this.label31.Text = "*118 cm = 1000 counts";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(1020, 45);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(54, 13);
            this.label30.TabIndex = 17;
            this.label30.Text = "Y Position";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(340, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 35);
            this.button1.TabIndex = 15;
            this.button1.Text = "Transmit Servo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(784, 42);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(54, 13);
            this.label34.TabIndex = 12;
            this.label34.Text = "X Position";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.FinalPositionBox2);
            this.tabPage2.Controls.Add(this.FinalPositionBox);
            this.tabPage2.Controls.Add(this.imageBox4);
            this.tabPage2.Controls.Add(this.imageBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1412, 642);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trajectory Analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(721, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Final Position";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Final Position";
            // 
            // FinalPositionBox2
            // 
            this.FinalPositionBox2.Location = new System.Drawing.Point(796, 7);
            this.FinalPositionBox2.Name = "FinalPositionBox2";
            this.FinalPositionBox2.Size = new System.Drawing.Size(100, 20);
            this.FinalPositionBox2.TabIndex = 5;
            // 
            // FinalPositionBox
            // 
            this.FinalPositionBox.Location = new System.Drawing.Point(92, 6);
            this.FinalPositionBox.Name = "FinalPositionBox";
            this.FinalPositionBox.Size = new System.Drawing.Size(100, 20);
            this.FinalPositionBox.TabIndex = 4;
            // 
            // imageBox4
            // 
            this.imageBox4.Location = new System.Drawing.Point(724, 29);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(640, 480);
            this.imageBox4.TabIndex = 3;
            this.imageBox4.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.Location = new System.Drawing.Point(20, 29);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(640, 480);
            this.imageBox3.TabIndex = 2;
            this.imageBox3.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.RealPos1);
            this.tabPage1.Controls.Add(this.RealPos0);
            this.tabPage1.Controls.Add(this.RealVel1);
            this.tabPage1.Controls.Add(this.RealVel0);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.Camera1XPosBox);
            this.tabPage1.Controls.Add(this.Camera0XPosBox);
            this.tabPage1.Controls.Add(this.Control1XVelBox);
            this.tabPage1.Controls.Add(this.Control0XVelBox);
            this.tabPage1.Controls.Add(this.Cam0TextBox);
            this.tabPage1.Controls.Add(this.Cam1TextBox);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.imageBox1);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.imageBox2);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.imageBox6);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.imageBox5);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.StartLogButton);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.ClearLogButton);
            this.tabPage1.Controls.Add(this.SaveDataButton);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1412, 642);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Control Panel";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(526, 506);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 13);
            this.label25.TabIndex = 106;
            this.label25.Text = "Camera 1 Pos";
            // 
            // RealPos1
            // 
            this.RealPos1.Location = new System.Drawing.Point(529, 522);
            this.RealPos1.Name = "RealPos1";
            this.RealPos1.Size = new System.Drawing.Size(100, 20);
            this.RealPos1.TabIndex = 105;
            // 
            // RealPos0
            // 
            this.RealPos0.Location = new System.Drawing.Point(529, 469);
            this.RealPos0.Name = "RealPos0";
            this.RealPos0.Size = new System.Drawing.Size(100, 20);
            this.RealPos0.TabIndex = 103;
            // 
            // RealVel1
            // 
            this.RealVel1.Location = new System.Drawing.Point(638, 522);
            this.RealVel1.Name = "RealVel1";
            this.RealVel1.Size = new System.Drawing.Size(100, 20);
            this.RealVel1.TabIndex = 101;
            // 
            // RealVel0
            // 
            this.RealVel0.Location = new System.Drawing.Point(638, 469);
            this.RealVel0.Name = "RealVel0";
            this.RealVel0.Size = new System.Drawing.Size(100, 20);
            this.RealVel0.TabIndex = 99;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(526, 453);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 13);
            this.label27.TabIndex = 104;
            this.label27.Text = "Camera 0 Pos";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(635, 506);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 13);
            this.label28.TabIndex = 102;
            this.label28.Text = "Camera 1 Vel";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(635, 453);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 13);
            this.label29.TabIndex = 100;
            this.label29.Text = "Camera 0 Vel";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(526, 363);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(73, 13);
            this.label24.TabIndex = 98;
            this.label24.Text = "Camera 1 Pos";
            // 
            // Camera1XPosBox
            // 
            this.Camera1XPosBox.Location = new System.Drawing.Point(529, 379);
            this.Camera1XPosBox.Name = "Camera1XPosBox";
            this.Camera1XPosBox.Size = new System.Drawing.Size(100, 20);
            this.Camera1XPosBox.TabIndex = 97;
            // 
            // Camera0XPosBox
            // 
            this.Camera0XPosBox.Location = new System.Drawing.Point(529, 326);
            this.Camera0XPosBox.Name = "Camera0XPosBox";
            this.Camera0XPosBox.Size = new System.Drawing.Size(100, 20);
            this.Camera0XPosBox.TabIndex = 93;
            // 
            // Control1XVelBox
            // 
            this.Control1XVelBox.Location = new System.Drawing.Point(638, 379);
            this.Control1XVelBox.Name = "Control1XVelBox";
            this.Control1XVelBox.Size = new System.Drawing.Size(100, 20);
            this.Control1XVelBox.TabIndex = 89;
            // 
            // Control0XVelBox
            // 
            this.Control0XVelBox.Location = new System.Drawing.Point(638, 326);
            this.Control0XVelBox.Name = "Control0XVelBox";
            this.Control0XVelBox.Size = new System.Drawing.Size(100, 20);
            this.Control0XVelBox.TabIndex = 85;
            // 
            // Cam0TextBox
            // 
            this.Cam0TextBox.Location = new System.Drawing.Point(789, 316);
            this.Cam0TextBox.Multiline = true;
            this.Cam0TextBox.Name = "Cam0TextBox";
            this.Cam0TextBox.Size = new System.Drawing.Size(201, 298);
            this.Cam0TextBox.TabIndex = 68;
            // 
            // Cam1TextBox
            // 
            this.Cam1TextBox.Location = new System.Drawing.Point(1019, 316);
            this.Cam1TextBox.Multiline = true;
            this.Cam1TextBox.Name = "Cam1TextBox";
            this.Cam1TextBox.Size = new System.Drawing.Size(193, 298);
            this.Cam1TextBox.TabIndex = 70;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(526, 310);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 13);
            this.label26.TabIndex = 94;
            this.label26.Text = "Camera 0 Pos";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(635, 363);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 13);
            this.label22.TabIndex = 90;
            this.label22.Text = "Camera 1 Vel";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(635, 310);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 86;
            this.label19.Text = "Camera 0 Vel";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1048, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 20);
            this.label18.TabIndex = 84;
            this.label18.Text = "Binary";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(352, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 20);
            this.label17.TabIndex = 83;
            this.label17.Text = "Binary";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(703, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 20);
            this.label16.TabIndex = 82;
            this.label16.Text = "Camera 1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 20);
            this.label15.TabIndex = 81;
            this.label15.Text = "Camera 0";
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox1.Location = new System.Drawing.Point(11, 34);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(320, 240);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(442, 306);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(57, 23);
            this.button5.TabIndex = 65;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.checkBox_LH);
            this.groupBox1.Controls.Add(this.checkBox_IV);
            this.groupBox1.Controls.Add(this.checkBox_EV);
            this.groupBox1.Controls.Add(this.checkBox_ES);
            this.groupBox1.Controls.Add(this.checkBox_EH);
            this.groupBox1.Controls.Add(this.numeric_SL);
            this.groupBox1.Controls.Add(this.numeric_HL);
            this.groupBox1.Controls.Add(this.numeric_VL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackBar_VL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBar_SL);
            this.groupBox1.Controls.Add(this.trackBar_HL);
            this.groupBox1.Controls.Add(this.trackBar_VH);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numeric_SH);
            this.groupBox1.Controls.Add(this.numeric_HH);
            this.groupBox1.Controls.Add(this.trackBar_SH);
            this.groupBox1.Controls.Add(this.numeric_VH);
            this.groupBox1.Controls.Add(this.trackBar_HH);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(11, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 110);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HSV";
            // 
            // checkBox_LH
            // 
            this.checkBox_LH.AutoSize = true;
            this.checkBox_LH.Location = new System.Drawing.Point(435, 54);
            this.checkBox_LH.Name = "checkBox_LH";
            this.checkBox_LH.Size = new System.Drawing.Size(50, 17);
            this.checkBox_LH.TabIndex = 64;
            this.checkBox_LH.Text = "Lock";
            this.checkBox_LH.UseVisualStyleBackColor = true;
            this.checkBox_LH.CheckedChanged += new System.EventHandler(this.checkBox_LH_CheckedChanged);
            // 
            // checkBox_IV
            // 
            this.checkBox_IV.AutoSize = true;
            this.checkBox_IV.Location = new System.Drawing.Point(435, 27);
            this.checkBox_IV.Name = "checkBox_IV";
            this.checkBox_IV.Size = new System.Drawing.Size(53, 17);
            this.checkBox_IV.TabIndex = 78;
            this.checkBox_IV.Text = "Invert";
            this.checkBox_IV.UseVisualStyleBackColor = true;
            // 
            // checkBox_EV
            // 
            this.checkBox_EV.AutoSize = true;
            this.checkBox_EV.Location = new System.Drawing.Point(12, 80);
            this.checkBox_EV.Name = "checkBox_EV";
            this.checkBox_EV.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EV.TabIndex = 77;
            this.checkBox_EV.UseVisualStyleBackColor = true;
            // 
            // checkBox_ES
            // 
            this.checkBox_ES.AutoSize = true;
            this.checkBox_ES.Location = new System.Drawing.Point(12, 54);
            this.checkBox_ES.Name = "checkBox_ES";
            this.checkBox_ES.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ES.TabIndex = 76;
            this.checkBox_ES.UseVisualStyleBackColor = true;
            // 
            // checkBox_EH
            // 
            this.checkBox_EH.AutoSize = true;
            this.checkBox_EH.Location = new System.Drawing.Point(12, 28);
            this.checkBox_EH.Name = "checkBox_EH";
            this.checkBox_EH.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EH.TabIndex = 75;
            this.checkBox_EH.UseVisualStyleBackColor = true;
            // 
            // numeric_SL
            // 
            this.numeric_SL.Location = new System.Drawing.Point(201, 52);
            this.numeric_SL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_SL.Name = "numeric_SL";
            this.numeric_SL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numeric_SL.Size = new System.Drawing.Size(38, 20);
            this.numeric_SL.TabIndex = 67;
            this.numeric_SL.ValueChanged += new System.EventHandler(this.numeric_Lo_ValueChanged);
            // 
            // numeric_HL
            // 
            this.numeric_HL.Location = new System.Drawing.Point(201, 26);
            this.numeric_HL.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numeric_HL.Name = "numeric_HL";
            this.numeric_HL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numeric_HL.Size = new System.Drawing.Size(38, 20);
            this.numeric_HL.TabIndex = 66;
            this.numeric_HL.ValueChanged += new System.EventHandler(this.numeric_Lo_ValueChanged);
            // 
            // numeric_VL
            // 
            this.numeric_VL.Location = new System.Drawing.Point(201, 78);
            this.numeric_VL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_VL.Name = "numeric_VL";
            this.numeric_VL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numeric_VL.Size = new System.Drawing.Size(38, 20);
            this.numeric_VL.TabIndex = 65;
            this.numeric_VL.ValueChanged += new System.EventHandler(this.numeric_Lo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "V:";
            // 
            // trackBar_VL
            // 
            this.trackBar_VL.Location = new System.Drawing.Point(56, 77);
            this.trackBar_VL.Maximum = 255;
            this.trackBar_VL.Name = "trackBar_VL";
            this.trackBar_VL.Size = new System.Drawing.Size(140, 45);
            this.trackBar_VL.TabIndex = 34;
            this.trackBar_VL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_VL.ValueChanged += new System.EventHandler(this.trackBar_Lo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "S:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "H:";
            // 
            // trackBar_SL
            // 
            this.trackBar_SL.Location = new System.Drawing.Point(55, 52);
            this.trackBar_SL.Maximum = 255;
            this.trackBar_SL.Name = "trackBar_SL";
            this.trackBar_SL.Size = new System.Drawing.Size(140, 45);
            this.trackBar_SL.TabIndex = 33;
            this.trackBar_SL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_SL.ValueChanged += new System.EventHandler(this.trackBar_Lo_ValueChanged);
            // 
            // trackBar_HL
            // 
            this.trackBar_HL.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBar_HL.Location = new System.Drawing.Point(56, 25);
            this.trackBar_HL.Maximum = 180;
            this.trackBar_HL.Name = "trackBar_HL";
            this.trackBar_HL.Size = new System.Drawing.Size(140, 45);
            this.trackBar_HL.TabIndex = 32;
            this.trackBar_HL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_HL.ValueChanged += new System.EventHandler(this.trackBar_Lo_ValueChanged);
            // 
            // trackBar_VH
            // 
            this.trackBar_VH.Location = new System.Drawing.Point(289, 77);
            this.trackBar_VH.Maximum = 255;
            this.trackBar_VH.Name = "trackBar_VH";
            this.trackBar_VH.Size = new System.Drawing.Size(140, 45);
            this.trackBar_VH.TabIndex = 25;
            this.trackBar_VH.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_VH.Value = 255;
            this.trackBar_VH.ValueChanged += new System.EventHandler(this.trackBar_Hi_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Min";
            // 
            // numeric_SH
            // 
            this.numeric_SH.Location = new System.Drawing.Point(245, 52);
            this.numeric_SH.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_SH.Name = "numeric_SH";
            this.numeric_SH.Size = new System.Drawing.Size(38, 20);
            this.numeric_SH.TabIndex = 10;
            this.numeric_SH.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_SH.ValueChanged += new System.EventHandler(this.numeric_Hi_ValueChanged);
            // 
            // numeric_HH
            // 
            this.numeric_HH.Location = new System.Drawing.Point(245, 26);
            this.numeric_HH.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numeric_HH.Name = "numeric_HH";
            this.numeric_HH.Size = new System.Drawing.Size(38, 20);
            this.numeric_HH.TabIndex = 9;
            this.numeric_HH.ValueChanged += new System.EventHandler(this.numeric_Hi_ValueChanged);
            // 
            // trackBar_SH
            // 
            this.trackBar_SH.Location = new System.Drawing.Point(289, 52);
            this.trackBar_SH.Maximum = 255;
            this.trackBar_SH.Name = "trackBar_SH";
            this.trackBar_SH.Size = new System.Drawing.Size(140, 45);
            this.trackBar_SH.TabIndex = 24;
            this.trackBar_SH.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_SH.Value = 255;
            this.trackBar_SH.ValueChanged += new System.EventHandler(this.trackBar_Hi_ValueChanged);
            // 
            // numeric_VH
            // 
            this.numeric_VH.Location = new System.Drawing.Point(245, 78);
            this.numeric_VH.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_VH.Name = "numeric_VH";
            this.numeric_VH.Size = new System.Drawing.Size(38, 20);
            this.numeric_VH.TabIndex = 11;
            this.numeric_VH.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_VH.ValueChanged += new System.EventHandler(this.numeric_Hi_ValueChanged);
            // 
            // trackBar_HH
            // 
            this.trackBar_HH.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBar_HH.Location = new System.Drawing.Point(289, 26);
            this.trackBar_HH.Maximum = 180;
            this.trackBar_HH.Name = "trackBar_HH";
            this.trackBar_HH.Size = new System.Drawing.Size(140, 45);
            this.trackBar_HH.TabIndex = 23;
            this.trackBar_HH.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_HH.ValueChanged += new System.EventHandler(this.trackBar_Hi_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1127, 300);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 80;
            this.label14.Text = "Y";
            // 
            // imageBox2
            // 
            this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox2.Location = new System.Drawing.Point(356, 34);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(320, 240);
            this.imageBox2.TabIndex = 3;
            this.imageBox2.TabStop = false;
            this.imageBox2.Click += new System.EventHandler(this.imageBox2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1075, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "X";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.checkBox_VAr);
            this.groupBox3.Controls.Add(this.trackBar_VAr);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.numeric_VAr);
            this.groupBox3.Location = new System.Drawing.Point(11, 469);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 73);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detection";
            // 
            // checkBox_VAr
            // 
            this.checkBox_VAr.AutoSize = true;
            this.checkBox_VAr.Location = new System.Drawing.Point(21, 29);
            this.checkBox_VAr.Name = "checkBox_VAr";
            this.checkBox_VAr.Size = new System.Drawing.Size(67, 17);
            this.checkBox_VAr.TabIndex = 43;
            this.checkBox_VAr.Text = "ON/OFF";
            this.checkBox_VAr.UseVisualStyleBackColor = true;
            this.checkBox_VAr.CheckedChanged += new System.EventHandler(this.checkBox_VAr_CheckedChanged);
            // 
            // trackBar_VAr
            // 
            this.trackBar_VAr.Location = new System.Drawing.Point(103, 29);
            this.trackBar_VAr.Maximum = 2000;
            this.trackBar_VAr.Name = "trackBar_VAr";
            this.trackBar_VAr.Size = new System.Drawing.Size(286, 45);
            this.trackBar_VAr.TabIndex = 42;
            this.trackBar_VAr.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_VAr.Value = 100;
            this.trackBar_VAr.ValueChanged += new System.EventHandler(this.trackBar_VAr_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(408, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Value Area ";
            // 
            // numeric_VAr
            // 
            this.numeric_VAr.Location = new System.Drawing.Point(411, 35);
            this.numeric_VAr.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numeric_VAr.Name = "numeric_VAr";
            this.numeric_VAr.Size = new System.Drawing.Size(55, 20);
            this.numeric_VAr.TabIndex = 41;
            this.numeric_VAr.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numeric_VAr.ValueChanged += new System.EventHandler(this.numeric_VAr_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1016, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "Time";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1258, 550);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 50);
            this.button3.TabIndex = 61;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(894, 301);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 77;
            this.label10.Text = "Y";
            // 
            // imageBox6
            // 
            this.imageBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox6.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox6.Location = new System.Drawing.Point(707, 34);
            this.imageBox6.Name = "imageBox6";
            this.imageBox6.Size = new System.Drawing.Size(320, 240);
            this.imageBox6.TabIndex = 66;
            this.imageBox6.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(840, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "X";
            // 
            // imageBox5
            // 
            this.imageBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox5.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox5.Location = new System.Drawing.Point(1052, 34);
            this.imageBox5.Name = "imageBox5";
            this.imageBox5.Size = new System.Drawing.Size(320, 240);
            this.imageBox5.TabIndex = 67;
            this.imageBox5.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(786, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "Time";
            // 
            // StartLogButton
            // 
            this.StartLogButton.BackColor = System.Drawing.Color.Green;
            this.StartLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartLogButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.StartLogButton.Location = new System.Drawing.Point(1258, 332);
            this.StartLogButton.Name = "StartLogButton";
            this.StartLogButton.Size = new System.Drawing.Size(114, 53);
            this.StartLogButton.TabIndex = 74;
            this.StartLogButton.Text = "Start Logging";
            this.StartLogButton.UseVisualStyleBackColor = false;
            this.StartLogButton.Click += new System.EventHandler(this.StartLogButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(777, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "Camera 0 ";
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Location = new System.Drawing.Point(1258, 401);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(114, 53);
            this.ClearLogButton.TabIndex = 73;
            this.ClearLogButton.Text = "Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // SaveDataButton
            // 
            this.SaveDataButton.Location = new System.Drawing.Point(1258, 478);
            this.SaveDataButton.Name = "SaveDataButton";
            this.SaveDataButton.Size = new System.Drawing.Size(114, 53);
            this.SaveDataButton.TabIndex = 72;
            this.SaveDataButton.Text = "Save Data";
            this.SaveDataButton.UseVisualStyleBackColor = true;
            this.SaveDataButton.Click += new System.EventHandler(this.SaveDataButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1010, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "Camera 1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1420, 668);
            this.tabControl1.TabIndex = 81;
            // 
            // RobotTimer
            // 
            this.RobotTimer.Interval = 50;
            this.RobotTimer.Tick += new System.EventHandler(this.RobotTimer_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1024, 211);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(93, 17);
            this.checkBox1.TabIndex = 86;
            this.checkBox1.Text = "Position Mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RobotTimer2
            // 
            this.RobotTimer2.Interval = 10;
            this.RobotTimer2.Tick += new System.EventHandler(this.RobotTimer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 692);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Color Detection";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VAr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VAr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer UpdateData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cmbComPort;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtBaudRate;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.IO.Ports.SerialPort serCom;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtByte1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox ServoCommandBox;
        private System.Windows.Forms.TextBox DesiredY;
        private System.Windows.Forms.TextBox DesiredX;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btnTransmitToComPort;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox FinalPositionBox2;
        private System.Windows.Forms.TextBox FinalPositionBox;
        public Emgu.CV.UI.ImageBox imageBox4;
        public Emgu.CV.UI.ImageBox imageBox3;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox Camera1XPosBox;
        private System.Windows.Forms.TextBox Camera0XPosBox;
        private System.Windows.Forms.TextBox Control1XVelBox;
        private System.Windows.Forms.TextBox Control0XVelBox;
        private System.Windows.Forms.TextBox Cam0TextBox;
        private System.Windows.Forms.TextBox Cam1TextBox;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        public Emgu.CV.UI.ImageBox imageBox1;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox checkBox_LH;
        public System.Windows.Forms.CheckBox checkBox_IV;
        public System.Windows.Forms.CheckBox checkBox_EV;
        public System.Windows.Forms.CheckBox checkBox_ES;
        public System.Windows.Forms.CheckBox checkBox_EH;
        public System.Windows.Forms.NumericUpDown numeric_SL;
        public System.Windows.Forms.NumericUpDown numeric_HL;
        public System.Windows.Forms.NumericUpDown numeric_VL;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TrackBar trackBar_VL;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TrackBar trackBar_SL;
        public System.Windows.Forms.TrackBar trackBar_HL;
        public System.Windows.Forms.TrackBar trackBar_VH;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown numeric_SH;
        public System.Windows.Forms.NumericUpDown numeric_HH;
        public System.Windows.Forms.TrackBar trackBar_SH;
        public System.Windows.Forms.NumericUpDown numeric_VH;
        public System.Windows.Forms.TrackBar trackBar_HH;
        public System.Windows.Forms.Label label14;
        public Emgu.CV.UI.ImageBox imageBox2;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox checkBox_VAr;
        public System.Windows.Forms.TrackBar trackBar_VAr;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.NumericUpDown numeric_VAr;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label label10;
        public Emgu.CV.UI.ImageBox imageBox6;
        public System.Windows.Forms.Label label9;
        public Emgu.CV.UI.ImageBox imageBox5;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button StartLogButton;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button ClearLogButton;
        public System.Windows.Forms.Button SaveDataButton;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.IO.Ports.SerialPort serComArduino;
        private System.Windows.Forms.ToolStripComboBox cmbComPort2;
        private System.Windows.Forms.ToolStripButton bntConnect2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button TransmitPositionButton;
        private System.Windows.Forms.Button ComputeCmdButton;
        public System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox RealPos1;
        private System.Windows.Forms.TextBox RealPos0;
        private System.Windows.Forms.TextBox RealVel1;
        private System.Windows.Forms.TextBox RealVel0;
        public System.Windows.Forms.Label label27;
        public System.Windows.Forms.Label label28;
        public System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox ContinuousMode;
        private System.Windows.Forms.Timer RobotTimer;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox MemUsageBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer RobotTimer2;
    }
}


//namespace MotionDetection
//{
//    partial class Form1
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//           this.label1 = new System.Windows.Forms.Label();
//           this.label2 = new System.Windows.Forms.Label();
//           this.label3 = new System.Windows.Forms.Label();
//           this.motionImageBox = new Emgu.CV.UI.ImageBox();
//           this.capturedImageBox = new Emgu.CV.UI.ImageBox();
//           this.forgroundImageBox = new Emgu.CV.UI.ImageBox();
//           this.label4 = new System.Windows.Forms.Label();
//           ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).BeginInit();
//           ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
//           ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).BeginInit();
//           this.SuspendLayout();
//           // 
//           // label1
//           // 
//           this.label1.AutoSize = true;
//           this.label1.Location = new System.Drawing.Point(9, 18);
//           this.label1.Name = "label1";
//           this.label1.Size = new System.Drawing.Size(85, 13);
//           this.label1.TabIndex = 1;
//           this.label1.Text = "Captured Image:";
//           // 
//           // label2
//           // 
//           this.label2.AutoSize = true;
//           this.label2.Location = new System.Drawing.Point(835, 18);
//           this.label2.Name = "label2";
//           this.label2.Size = new System.Drawing.Size(39, 13);
//           this.label2.TabIndex = 3;
//           this.label2.Text = "Motion";
//           // 
//           // label3
//           // 
//           this.label3.AutoSize = true;
//           this.label3.Location = new System.Drawing.Point(12, 452);
//           this.label3.Name = "label3";
//           this.label3.Size = new System.Drawing.Size(35, 13);
//           this.label3.TabIndex = 4;
//           this.label3.Text = "label3";
//           // 
//           // motionImageBox
//           // 
//           this.motionImageBox.Location = new System.Drawing.Point(838, 53);
//           this.motionImageBox.Name = "motionImageBox";
//           this.motionImageBox.Size = new System.Drawing.Size(397, 353);
//           this.motionImageBox.TabIndex = 2;
//           this.motionImageBox.TabStop = false;
//           // 
//           // capturedImageBox
//           // 
//           this.capturedImageBox.Location = new System.Drawing.Point(4, 53);
//           this.capturedImageBox.Name = "capturedImageBox";
//           this.capturedImageBox.Size = new System.Drawing.Size(409, 353);
//           this.capturedImageBox.TabIndex = 0;
//           this.capturedImageBox.TabStop = false;
//           // 
//           // forgroundImageBox
//           // 
//           this.forgroundImageBox.Location = new System.Drawing.Point(427, 53);
//           this.forgroundImageBox.Name = "forgroundImageBox";
//           this.forgroundImageBox.Size = new System.Drawing.Size(397, 353);
//           this.forgroundImageBox.TabIndex = 5;
//           this.forgroundImageBox.TabStop = false;
//           // 
//           // label4
//           // 
//           this.label4.AutoSize = true;
//           this.label4.Location = new System.Drawing.Point(424, 18);
//           this.label4.Name = "label4";
//           this.label4.Size = new System.Drawing.Size(84, 13);
//           this.label4.TabIndex = 6;
//           this.label4.Text = "Forground Mask";
//           // 
//           // Form1
//           // 
//           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//           this.ClientSize = new System.Drawing.Size(1258, 482);
//           this.Controls.Add(this.label4);
//           this.Controls.Add(this.forgroundImageBox);
//           this.Controls.Add(this.label3);
//           this.Controls.Add(this.label2);
//           this.Controls.Add(this.motionImageBox);
//           this.Controls.Add(this.label1);
//           this.Controls.Add(this.capturedImageBox);
//           this.Name = "Form1";
//           this.Text = "Form1";
//           this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
//           ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).EndInit();
//           ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).EndInit();
//           ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).EndInit();
//           this.ResumeLayout(false);
//           this.PerformLayout();

//        }

//        #endregion

//        private Emgu.CV.UI.ImageBox capturedImageBox;
//        private System.Windows.Forms.Label label1;
//        private Emgu.CV.UI.ImageBox motionImageBox;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label3;
//        private Emgu.CV.UI.ImageBox forgroundImageBox;
//        private System.Windows.Forms.Label label4;
//    }
//}

