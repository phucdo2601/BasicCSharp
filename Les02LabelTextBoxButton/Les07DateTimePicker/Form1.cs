using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les07DateTimePicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool check = true;

            errPhone.Clear();

            if (txtPhone.Text == "")
            {
                check = false;
                errPhone.SetError(txtPhone, "Phone field is missing");
            }

            //age
            int age;
            if (int.TryParse(txtAge.Text, out age) == false)
            {
                check = false;
                errAge.SetError(txtAge, "Age is required number format!");
            }
            else
            {
                if (age < 17)
                {
                    check |= false;
                    errAge.SetError(txtAge, "Age is larger than 17");
                }
            }

            // check datetime picker is not monday
            if (dtpDk.Value.DayOfWeek == DayOfWeek.Monday)
            {
                check = false;
                errRegisterDate.SetError(dtpDk, "Choose register date is not monday!");
            }

            if (check == true)
            {
                MessageBox.Show("Your Register is successfully!");
            }
        }
    }
}
