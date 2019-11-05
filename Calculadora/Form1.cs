using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Clicar(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "1": label1.Text = "1";break;

            }

            label1.Text = ((Button)sender).Text;
        }
    }
}
