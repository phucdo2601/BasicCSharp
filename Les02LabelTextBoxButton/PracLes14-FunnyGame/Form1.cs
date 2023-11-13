using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracLes14_FunnyGame
{
    public partial class Form1 : Form
    {
        int MoneyPlayer = 100;

        Random rd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        //btnSpin
        private void button1_Click(object sender, EventArgs e)
        {
            if (MoneyPlayer < 20)
            {
                MessageBox.Show("Ban khong du 20 xu, can phai nap them xu");
            }
            else
            {
                MoneyPlayer -= 20;
                txtCoin.Text = MoneyPlayer.ToString();

                //start time
                timer1.Start();

            }
        }

        //btnStop
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (lblNum1.Text == "7")
            {
                MoneyPlayer += 30;
            }
            if (lblNum2.Text == "7")
            {
                MoneyPlayer += 40;
            }
            if (lblNum3.Text == "7")
            {
                MoneyPlayer += 50;
            }

            txtCoin.Text = MoneyPlayer.ToString();
        }

        // btnNewGame
        private void button2_Click(object sender, EventArgs e)
        {
            MoneyPlayer = 100;
            txtCoin.Text = MoneyPlayer.ToString();
        }

        // btnExit
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit the program?", "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /**
             * De random tu 0 den N thi can set tu 0 den N+1 của hàm random
             * Random rd = new Random();
             * int numRan = rd.Next(0, 8) + "";
             */
            lblNum1.Text = rd.Next(0, 8) + "";
            lblNum2.Text = rd.Next(0, 9) + "";
            lblNum3.Text = rd.Next(0, 10) + "";
        }
    }
}
