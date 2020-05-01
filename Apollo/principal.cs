using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO.Ports;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using Emgu.Util;

namespace Apollo
{
    public partial class principal : Form
    {
        #region --Variáveis globais--
        //Comunicação Serial
        SerialPort arduino = new SerialPort();
        string recebeBackGround = "";
        public delegate void funcaoDelegate(string a);
        //------------------

        //Sensibilidade do Giro
        int weit = 1;
        int Xmin = 0;
        int Xmax = 12;
        int sens;
        int d = 2;
        int temp = 0;
        int temp2 = 0;
        bool piscou = false;
        int cena = 0;
        //---------------------

        //--------------------------
        public Image<Bgr, Byte> frame;
        public Image<Gray, Byte> gray;
        public HaarCascade haar1;
        public Capture capture;
        public Point eyeCenter;
        public bool eyeeDetected;
        public int tclin = 1;
        public int eyepPos;
        int mode = 0;
        int oitava = 1;
        int menu = 0;
        int menui = 0;
        //--------------------------

        //--------------------------
        private SoundPlayer nDO1;
        private SoundPlayer nRE1;
        private SoundPlayer nMI1;
        private SoundPlayer nFA1;
        private SoundPlayer nSOL1;
        private SoundPlayer nLA1;
        private SoundPlayer nSI1;

        private SoundPlayer nDO2;
        private SoundPlayer nRE2;
        private SoundPlayer nMI2;
        private SoundPlayer nFA2;
        private SoundPlayer nSOL2;
        private SoundPlayer nLA2;
        private SoundPlayer nSI2;

        private SoundPlayer nDO3;
        private SoundPlayer nRE3;
        private SoundPlayer nMI3;
        private SoundPlayer nFA3;
        private SoundPlayer nSOL3;
        private SoundPlayer nLA3;
        private SoundPlayer nSI3;
        private SoundPlayer click1;
        private SoundPlayer click2;
        //--------------------------
        #endregion n

        public principal()
        {
            InitializeComponent();
            arduino.PortName = "COM4";
            arduino.BaudRate = 115200;
            try
            {
                txt1.Text = "Pisque para continuar";
                Sit1.BackColor = Color.Green;
            }
            catch
            {
                txt1.Text = "Não foi possivel abrir a porta selecionada!";
            }
            nDO1 = new SoundPlayer("DÓ1.wav");
            nRE1 = new SoundPlayer("RÉ1.wav");
            nMI1 = new SoundPlayer("MI1.wav");
            nFA1 = new SoundPlayer("FÁ1.wav");
            nSOL1 = new SoundPlayer("SOL1.wav");
            nLA1 = new SoundPlayer("LÁ1.wav");
            nSI1 = new SoundPlayer("SI1.wav");

            nDO2 = new SoundPlayer("DÓ2.wav");
            nRE2 = new SoundPlayer("RÉ2.wav");
            nMI2 = new SoundPlayer("MI2.wav");
            nFA2 = new SoundPlayer("FÁ2.wav");
            nSOL2 = new SoundPlayer("SOL2.wav");
            nLA2 = new SoundPlayer("LÁ2.wav");
            nSI2 = new SoundPlayer("SI2.wav");

            nDO3 = new SoundPlayer("DÓ3.wav");
            nRE3 = new SoundPlayer("RÉ3.wav");
            nMI3 = new SoundPlayer("MI3.wav");
            nFA3 = new SoundPlayer("FÁ3.wav");
            nSOL3 = new SoundPlayer("SOL3.wav");
            nLA3 = new SoundPlayer("LÁ3.wav");
            nSI3 = new SoundPlayer("SI3.wav");

            click1 = new SoundPlayer("click1.wav");
            click2 = new SoundPlayer("click2.wav");
            haar1 = new HaarCascade("haarcascade_eye.xml");
            Application.Idle += processFrame;
            Application.Idle += pisc;
            arduino.DataReceived += new SerialDataReceivedEventHandler(serialReceiver);
            sens = (Xmax - Xmin) / 12;
            try
            {
                capture = new Capture(2);
            }
            catch (NullReferenceException except)
            {
                txt1.Text = except.Message;
                return;
            }

        }


        void processFrame(object sender, EventArgs e)
        {
            weit = 1; 
            eyeD.BackColor = Color.Red;
            if (eyeeDetected == true)
            {
                eyeD.BackColor = Color.Green;
            }
            else
            {
                //if (tclin == 2) nDO.Play();
                //if (tclin == 3) nRE.Play();
                //if (tclin == 4) nMI.Play();
                //if (tclin == 5) nFA.Play();
                //if (tclin == 6) nSOL.Play();
                //if (tclin == 7) nLA.Play();
                //if (tclin == 8) nSI.Play();

            }
            if(menu == 1)
            {
                oit1.Visible = true;
                oit2.Visible = true;
                oit3.Visible = true;

                if (piscou == true && tclin == 10 && menui <= 2)
                {
                    menui = menui + 1;
                    if (tclin == 10) click1.Play();
                }
                if (piscou == true && tclin == 11 && menui >= 0)
                {
                    menui = menui - 1;
                    if (tclin == 11) click1.Play();
                }
                if (piscou == true && tclin == 12)
                {
                    if (tclin == 12) click2.Play();
                }

                if (menui == 2)
                {
                    btn1.Image = Apollo.Properties.Resources.LIVRE1;
                    btn2.Image = Apollo.Properties.Resources.APRENDIZADO1;
                    btn3.Image = Apollo.Properties.Resources.SAIR2;
                }
                if (menui == 1)
                {
                    btn1.Image = Apollo.Properties.Resources.LIVRE1;
                    btn2.Image = Apollo.Properties.Resources.APRENDIZADO2;
                    btn3.Image = Apollo.Properties.Resources.SAIR1;
                }
                if (menui == 0)
                {
                    btn1.Image = Apollo.Properties.Resources.LIVRE2;
                    btn2.Image = Apollo.Properties.Resources.APRENDIZADO1;
                    btn3.Image = Apollo.Properties.Resources.SAIR1;
                }

            }
            if (piscou == true && mode == 1)
            {
                if (oitava == 3 && weit == 1)
                {
                    try
                    {
                        if (tclin == 2) nDO3.Play();
                        if (tclin == 3) nRE3.Play();
                        if (tclin == 4) nMI3.Play();
                        if (tclin == 5) nFA3.Play();
                        if (tclin == 6) nSOL3.Play();
                        if (tclin == 7) nLA3.Play();
                        if (tclin == 8) nSI3.Play();
                        if (tclin == 1)
                        {
                            click2.Play();
                            oitava = 2;
                            weit = 0;
                            oit1.BackColor = Color.Turquoise;
                            oit2.BackColor = Color.Teal;
                            oit3.BackColor = Color.Turquoise;
                        }
                        if (tclin == 9)
                        {
                            click2.Play();
                            weit = 0;
                        }
                    }
                    catch
                    {

                    }
                    
                }
                if (oitava == 2 && weit == 1)
                {
                    try
                    {
                        if (tclin == 2) nDO2.Play();
                        if (tclin == 3) nRE2.Play();
                        if (tclin == 4) nMI2.Play();
                        if (tclin == 5) nFA2.Play();
                        if (tclin == 6) nSOL2.Play();
                        if (tclin == 7) nLA2.Play();
                        if (tclin == 8) nSI2.Play();
                        if (tclin == 1)
                        {
                            click2.Play();
                            oitava = 1;
                            weit = 0;
                            oit1.BackColor = Color.Teal;
                            oit2.BackColor = Color.Turquoise;
                            oit3.BackColor = Color.Turquoise;
                        }
                        if (tclin == 9)
                        {
                            click2.Play();
                            oitava = 3;
                            weit = 0;
                            oit1.BackColor = Color.Turquoise;
                            oit2.BackColor = Color.Turquoise;
                            oit3.BackColor = Color.Teal;
                        }
                    }
                    catch
                    {

                    }
                }
                if (oitava == 1 && weit == 1)
                {
                    try
                    {
                        if (tclin == 2) nDO1.Play();
                        if (tclin == 3) nRE1.Play();
                        if (tclin == 4) nMI1.Play();
                        if (tclin == 5) nFA1.Play();
                        if (tclin == 6) nSOL1.Play();
                        if (tclin == 7) nLA1.Play();
                        if (tclin == 8) nSI1.Play();
                        if (tclin == 1)
                        {
                            click2.Play();
                            weit = 0;
                        }
                        if (tclin == 9)
                        {
                            click2.Play();
                            oitava = 2;
                            weit = 0;
                            oit1.BackColor = Color.Turquoise;
                            oit2.BackColor = Color.Teal;
                            oit3.BackColor = Color.Turquoise;
                        }
                    }
                    catch
                    {

                    }
                   
                }
             
            }
            capture.FlipHorizontal = true;
            frame = capture.QuerySmallFrame();
            if (frame == null) return;

            gray = frame.Convert<Gray, byte>();
            var eyes = gray.DetectHaarCascade(haar1, 1.1, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(50, 50))[0];
            eyeeDetected = false;
            foreach (var eye in eyes)
            {
                frame.Draw(new CircleF(eyeCenter, 3), new Bgr(255, 0, 0), 2);
                eyeeDetected = true;
            }
            if (cena == 0)
            {
                txt1.Text = "Pisque para continuar";
            }
            if (cena == 6 && piscou == true)
            {
                try
                {
                    arduino.Write("2");
                    imag.Image = Apollo.Properties.Resources._8;
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = true;
                    menu = 1;
                    mode = 1;
                }
                catch
                {

                }
                cena = 7;
            }
            if (cena == 5 && piscou == true)
            {
                try
                {
                    arduino.Write("1");
                    imag.Image = Apollo.Properties.Resources._7;
                }
                catch
                {

                }
                cena = 6;
            }
            if (cena == 4 && piscou == true)
            {
                imag.Image = Apollo.Properties.Resources._6;
                cena = 5;
            }
            if (cena == 4)
            {
                imag.Image = Apollo.Properties.Resources._5;
            }
            if (cena == 3)
            {
                imag.Image = Apollo.Properties.Resources._4;
                progressBar1.Location = new Point(365, 404);
            }
            if (piscou == true && cena == 1)
            {
                imag.Image = Apollo.Properties.Resources._3;
                cena = 2;
                progressBar1.Visible = true;
            }
            if (piscou == true && cena == 0)
            {
                imag.Image = Apollo.Properties.Resources._2;
                cena = 1;
            }

            web1.Image = frame;


        }
        //-----VERIFICAR A TECLA-------------------------------------------------------
        void serialReceiver(object sender, SerialDataReceivedEventArgs e)
        {
                recebeBackGround = arduino.ReadExisting();
                this.BeginInvoke(new funcaoDelegate(textLogState), new object[] { recebeBackGround });
        }

        public void textLogState(string a)
        {
            try
            {
                // txt1.Text = tclin.ToString();
                d = int.Parse(a);
                txt1.Text += " " + d;
            }
            catch
            {
                //txt1.Text += "Error: comunicação serial";
            }

            if (d > Xmin && d <= (Xmin + sens))
            {
                tclin = 1;
            }
            if (d > (Xmin + sens) && d <= (Xmin + 2 * sens))
            {
                tclin = 2;
            }
            if (d > (Xmin + 2 * sens) && d <= (Xmin + 3 * sens))
            {
                tclin = 3;
            }
            if (d > (Xmin + 3 * sens) && d <= (Xmin + 4 * sens))
            {
                tclin = 4;
            }
            if (d > (Xmin + 4 * sens) && d <= (Xmin + 5 * sens))
            {
                tclin = 5;
            }
            if (d > (Xmin + 5 * sens) && d <= (Xmin + 6 * sens))
            {
                tclin = 6;
            }
            if (d > (Xmin + 6 * sens) && d <= (Xmin + 7 * sens))
            {
                tclin = 7;
            }
            if (d > (Xmin + 7 * sens) && d <= (Xmin + 8 * sens))
            {
                tclin = 8;
            }
            if (d > (Xmin + 8 * sens) && d <= (Xmin + 9 * sens))
            {
                tclin = 9;
            }
            if (d > (Xmin + 9 * sens) && d <= (Xmin + 10 * sens))
            {
                tclin = 10;
            }
            if (d > (Xmin + 10 * sens) && d <= (Xmin + 11 * sens))
            {
                tclin = 11;
            }
            if (d > (Xmin + 11 * sens) && d <= (Xmin + 12 * sens))
            {
                tclin = 12;
            }
            txt1.Text = "";
            d = 0;
            a = "";
        }
        //-----CONECTAR ARDUINO---------------------------------------------
        public void pisc(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (arduino.IsOpen)
            {
                arduino.Close();
                Sit1.BackColor = Color.Red;
                txt1.Text = "Teclado desconectado!";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (eyeeDetected == false)
            {
                temp2 = 0;
                temp = temp + 1;
            }
            if (temp >= 1 && temp < 5 && eyeeDetected == true)
            {
                piscou = true;
                if(mode == 0){
                    nDO1.Play();
                }
            }
            if (eyeeDetected == true)
            {
                temp = 0;
                temp2 = temp2 + 1;

            }
            if (eyeeDetected == true && temp2 == 2)
            {
                piscou = false;
            }

            if (cena == 2)
            {
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    try
                    {
                        arduino.Open();
                    }
                    catch
                    {

                    }
                    cena = 3;
                    progressBar1.Value = 0;
                }
                progressBar1.Value += 10;
            }
            if (cena == 3)
            {
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    cena = 4;
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                }
                progressBar1.Value += 2;
            }

        }

        private void principal_Load(object sender, EventArgs e)
        {

        }
    }
}
