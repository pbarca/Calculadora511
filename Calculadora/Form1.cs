using System;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string operador;
        double visor, mem, num1, num2;

        private void reset()
        {
            operador = "";
            visor = mem = num1 = num2 = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }

        bool limpar = true;
        private void mostra()
        {
            label1.Text = Math.Abs(visor).ToString();
            if (mem != 0) memory.Visible = false; else memory.Visible = true;
            if (visor < 0) minus.Visible = false; else minus.Visible = true;
            if (label1.Text.Length > 9) label1.Text = label1.Text.Substring(0, 9);
        }

        private void calcula()
        {
            if (num1 == 0) num1 = visor;
            else num2 = visor;
            if (operador == "+") visor = num1 + num2;
            else if (operador == "-") visor = num1 - num2;
            else if (operador == "×") visor = num1 * num2;
            else if (operador == "÷") visor = num1 / num2;
            else if (operador == "=") visor = num1;
            mostra();
            num1 = visor;
            limpar = true;
            visor = 0;
        }
        private void adiciona(string botao)
        {
            if (limpar)
            {
                label1.Text = "0";
                minus.Visible = true;
                limpar = false;
            }
            if (label1.Text == "0") label1.Text = botao;
            else label1.Text += botao;
            if (label1.Text.Length > 9) label1.Text = label1.Text.Substring(0, 9);
            visor = ecra();
        }
        private double ecra()
        {
            try
            {
                visor = Convert.ToDouble(label1.Text);
            }
            catch
            {
                visor = 0;
            }
            if (!minus.Visible) visor = -visor;
            return visor;
        }
        private void Clicar(object sender, EventArgs e)
        {
            string botao = ((Button)sender).Tag.ToString();
            switch (botao)
            {
                case "MRC": visor = mem; mostra(); break;
                case "M-": mem -= ecra(); mostra(); break;
                case "M+": mem += ecra(); mostra(); break;
                case "√": visor = Math.Sqrt(ecra()); mostra(); break;
                case "OFF": reset(); mostra(); label1.Text = ""; break;
                case "AC": reset(); mostra(); break;
                case "C": visor = 0; mostra(); break;
                case "+/-": visor = -ecra(); mostra(); break;
                case "%": visor = ecra() / 100 * num1; mostra(); break;
                case "+":
                case "-":
                case "×":
                case "÷":
                case "=": calcula(); operador = botao; break;
                case ".": if (!label1.Text.Contains(",")) label1.Text += ","; break;
                default: adiciona(botao); break;
            }
        }
    }
}
