// Calculadora 511

using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        private readonly PrivateFontCollection private_fonts = new PrivateFontCollection();
        public Form1()
        {
            InitializeComponent();

            String fonte = "Calculadora.Resources.digital-7-mono.ttf";
            Stream fontStream = this.GetType().Assembly.GetManifestResourceStream(fonte);
            IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            byte[] fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int)fontStream.Length);
            Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
            private_fonts.AddMemoryFont(data, (int)fontStream.Length);
            fontStream.Close();
            Marshal.FreeCoTaskMem(data);
            label1.Font = new Font(private_fonts.Families[0], 43);
            label1.UseCompatibleTextRendering = true;
        }

        string operador = "";
        double visor = 0, mem = 0, num1 = 0, num2 = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool limpar = true;
        private void mostra()
        {
            label1.Text = Math.Abs(visor).ToString();
            if (mem != 0) memory.Visible = false; else memory.Visible = true;
            if (visor < 0) minus.Visible = false; else minus.Visible = true;
            if (label1.Text.Length > 9) label1.Text = label1.Text.Substring(0, 9);
        }
        private void Clicar(object sender, EventArgs e)
        {
            if (limpar) { label1.Text = ""; limpar = false; }
            string botao = ((Button)sender).Tag.ToString();
            switch (botao)
            {
                case "MRC": visor = mem; mostra(); break;
                case "M-": mem -= visor; mostra(); break;
                case "M+": mem += visor; mostra(); break;
                case "√": visor = Math.Sqrt(visor); mostra(); break;
                case "OFF": visor = 0; mem = 0; mostra(); label1.Text = ""; break;
                case "AC": visor = 0; mem = 0; mostra(); break;
                case "C": visor = 0; mostra(); break;
                case "+/-": visor = -visor; mostra(); break;
                case "%": visor = visor / 100 * num1; mostra(); break;
                case "+":
                case "-":
                case "×":
                case "÷": operador = botao; num1 = visor; visor = 0; limpar = true; break;
                case "=":
                    {
                        num2 = visor;
                        if (operador == "+") visor = num1 + num2;
                        else if (operador == "-") visor = num1 - num2;
                        else if (operador == "×") visor = num1 * num2;
                        else if (operador == "÷") visor = num1 / num2;
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
