using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les14TimerB01
{
    public partial class lblTimeDis : Form
    {
        public lblTimeDis()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // code here
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            timer1.Stop();
        }
    }
}
