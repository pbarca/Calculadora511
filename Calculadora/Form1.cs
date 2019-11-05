// Calculadora 511

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

        string operador = "";
        double visor = 0, mem = 0, num1 = 0, num2 = 0;
        bool limpar = true;
        private void mostra()
        {
            label1.Text = Math.Abs(visor).ToString();
            if (mem != 0) memory.Visible = false; else memory.Visible = true;
            if (visor < 0) minus.Visible = false; else minus.Visible = true;
        }
        private void Clicar(object sender, EventArgs e)
        {
            if (limpar) { label1.Text = ""; limpar = false; }
            string botao = ((Button)sender).Text;
            switch (botao)
            {
                case "M+": mem += visor; mostra(); break;
                case "M-": mem -= visor; mostra(); break;
                case "MRC": visor = mem; mostra(); break;
                case "AC": label1.Text = ""; visor = 0; mem = 0; mostra(); break;
                case "C": label1.Text = ""; visor = 0; mostra(); break;
                case "+/-": visor = -visor; mostra(); break;
                case "+":
                case "-":
                case "x":
                case "/": operador = botao; num1 = visor; visor = 0; limpar = true; break;
                case "=":
                    {
                        num2 = visor;
                        if (operador == "+") visor = num1 + num2;
                        else if (operador == "-") visor = num1 - num2;
                        else if (operador == "x") visor = num1 * num2;
                        else if (operador == "/") visor = num1 / num2;
                        mostra();
                        break;
                    }
                case ".":
                    {
                        string backup = label1.Text;
                        mostra();
                        try
                        {
                            label1.Text += ",";
                            visor = Convert.ToDouble(label1.Text);
                        }
                        catch
                        {
                            Console.Beep();
                            label1.Text = backup;
                        }
                        break;
                    }
                default:
                    {
                        label1.Text += botao;
                        visor = Convert.ToDouble(label1.Text);
                        mostra();
                        break;
                    }
            }
        }
    }
}
