using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class SplashForm : Form
    {
        private int counter = 1;

        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            loadTimer.Start();
            loadTimer.Interval = 50;
        }

        private void loadTimer_Tick(object sender, EventArgs e)
        {
            if (counter <= 15) {
                counter++;
            } else if (this.Opacity > 0) {
                this.Opacity -= 0.1;
                counter++;
            } else
                this.Close();
        }

        private void SplashForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadTimer.Stop();
        }
    }
}
