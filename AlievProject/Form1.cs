using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlievProject
{
    public partial class Form1 : Form
    {
        List<Life> life;
        Pen pen;
        Bitmap myBitmap;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Thread simulationThread = new Thread(Simulation);
            simulationThread.Start();*/

            life = new List<Life>();
            for (int i = 0; i < 15; i++)
            {
                life.Add(new Life(life, new Random((int)(DateTime.Now.Ticks % int.MaxValue)).NextDouble(),
                    new Random((int)(DateTime.Now.Ticks % (i + 1))).NextDouble()));
            }

            pen = new Pen(Color.Black);

            timer1.Start();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 15 - life.Count; i++)
            {
                life.Add(new Life(life, new Random((int)(DateTime.Now.Ticks % int.MaxValue)).NextDouble(),
                    new Random((int)(DateTime.Now.Ticks % (i + 1))).NextDouble()));
            }

            myBitmap = new Bitmap(Form1.ActiveForm.Width, Form1.ActiveForm.Height);
            Graphics myGraphics = Graphics.FromImage(myBitmap);

            myGraphics.DrawLine(pen, 0, 608, 608, 608);
            myGraphics.DrawLine(pen, 608, 608, 608, 0);

            for (int j = 0; j < life.Count; j++)
            {
                if (life[j] != null)
                {
                    var l = life[j];
                    l.DoLive();
                    l.Draw(myGraphics);
                }
            }
            Form1.ActiveForm.Refresh();
            Form1.ActiveForm.BackgroundImage = myBitmap;

            Form1.ActiveForm.Text = life.Count.ToString();
        }
    }
}
