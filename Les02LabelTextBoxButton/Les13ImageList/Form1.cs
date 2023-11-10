using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les13ImageLít
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDislayImage_Click(object sender, EventArgs e)
        {
            lblImageDis.ImageIndex = 0;
            lblImageDis.ImageAlign = ContentAlignment.TopRight;
        }
    }
}
