using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace GalagaEffect
{

    public partial class MainForm : Form
    {
        public System.Timers.Timer gameTimer;
        GameCostructor GM;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            GM = new GameCostructor(this);           
            SetTimer();   
        }
        private void SetTimer()
        {
            gameTimer = new System.Timers.Timer();
            gameTimer.Elapsed += new ElapsedEventHandler(TimerTick);
            gameTimer.Interval = 1000 / 120;
            gameTimer.Enabled = true;
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            mainPanel.Invalidate();
            GM.Next();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GM.Draw(g);            
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            GM.UserInput(e.KeyCode, true);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            GM.UserInput(e.KeyCode, false);
        }
    }
}
