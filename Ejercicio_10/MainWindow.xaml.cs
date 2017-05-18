using System.Windows;
using System.Windows.Controls;

namespace Ejercicio_10
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] operandos = new string[3];
        int nDatos = 0;
        bool EnterPulsado = false;
        public MainWindow()
        {
            InitializeComponent();
            operandos[nDatos++] = "0";
        }

        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            if (EnterPulsado)
            {
                nDatos = 0;
                operandos[nDatos++] = "0";
                tbxCalculo.Text = "0";
                EnterPulsado = false;
            }
            if (nDatos == 2)
            {
                nDatos++;
                tbxCalculo.Text = ((Button)sender).Content.ToString();
            }
            else if (double.Parse(tbxCalculo.Text) == 0)
            {
                tbxCalculo.Text = ((Button)sender).Content.ToString();
            }
            else
            {
                tbxCalculo.Text += ((Button)sender).Content.ToString();
            }      

            operandos[nDatos - 1] = tbxCalculo.Text;
            if (operandos[nDatos - 1] == "0")
            {
                if (btnSignoUnitario.IsEnabled)
                {
                    btnSignoUnitario.IsEnabled = false;
                    btnLimpiar.IsEnabled = false;
                }
            }
            else
            {
                btnSignoUnitario.IsEnabled = true;
                btnLimpiar.IsEnabled = true;
            }
        }

        private void Operador_Click(object sender, RoutedEventArgs e)
        {
            if (EnterPulsado)
            {
                EnterPulsado = false;
            }
            if (nDatos > 0)
            {
                if (btnSignoUnitario.IsEnabled)
                {
                    btnSignoUnitario.IsEnabled = false;
                    btnLimpiar.IsEnabled = false;
                }
                switch (nDatos)
                {
                    case 1:
                        operandos[nDatos++] = ((Button)sender).Content.ToString();
                        break;
                    case 2:
                        operandos[nDatos - 1] = ((Button)sender).Content.ToString();
                        break;
                    case 3:
                        Calcular();
                        operandos[nDatos++] = ((Button)sender).Content.ToString();
                        break;
                }

            }
        }

        void Calcular()
        {
            if (nDatos == 3)
            {
                if (operandos[nDatos-1][operandos[nDatos-1].Length-1] == ',')
                {
                    operandos[nDatos - 1] = operandos[nDatos - 1].Substring(0, operandos[nDatos - 1].Length - 2);
                }
                switch (operandos[1])
                {
                    case "*":
                        operandos[0] = (double.Parse(operandos[0]) * double.Parse(operandos[2])).ToString();
                        break;
                    case "+":
                        operandos[0] = (double.Parse(operandos[0]) + double.Parse(operandos[2])).ToString();
                        break;
                    case "-":
                        operandos[0] = (double.Parse(operandos[0]) - double.Parse(operandos[2])).ToString();
                        break;
                    case "/":
                        operandos[0] = (double.Parse(operandos[0]) / double.Parse(operandos[2])).ToString();
                        break;
                }
                nDatos = 0;
                tbxCalculo.Text = operandos[nDatos++];
                if (operandos[nDatos-1] == "0")
                {
                    if (btnSignoUnitario.IsEnabled)
                    {
                        btnSignoUnitario.IsEnabled = false;
                        btnLimpiar.IsEnabled = false;
                    }
                }
            }
        }

        private void btlLimpiarTodo_Click(object sender, RoutedEventArgs e)
        {
            nDatos = 0;
            operandos[nDatos++] = "0";
            tbxCalculo.Text = operandos[nDatos-1];
        }

        private void btnCero_Click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(tbxCalculo.Text) != 0)
            {
                if (nDatos == 2)
                {
                    nDatos++;
                }
                operandos[nDatos - 1] += ((Button)sender).Content.ToString();

                tbxCalculo.Text = operandos[nDatos-1];
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Calcular();
            EnterPulsado = true;
        }

        private void btnSignoUnitario_Click(object sender, RoutedEventArgs e)
        {
            if (NoGuion(tbxCalculo.Text))
            {
                operandos[nDatos - 1] = "-" + tbxCalculo.Text;
                tbxCalculo.Text = operandos[nDatos - 1]; 
            }
            else
            {
                operandos[nDatos - 1] = tbxCalculo.Text;
                operandos[nDatos - 1] = operandos[nDatos - 1].Substring(1, operandos[nDatos - 1].Length - 1);
                tbxCalculo.Text = operandos[nDatos - 1];
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            if (nDatos == 1 || nDatos == 3)
            {
                operandos[nDatos-1] = "0";
                tbxCalculo.Text = operandos[nDatos-1];
            }
        }

        private void btnComaDec_Click(object sender, RoutedEventArgs e)
        {

            if (NoComa(tbxCalculo.Text))
            {
                operandos[nDatos - 1] += ',';
                tbxCalculo.Text = operandos[nDatos - 1];
            }

        }
        private bool NoComa(string texto)
        {
            int indice = 0;
            while (indice < texto.Length)
            {
                if (texto[indice] == ',')
                {
                    return false;
                }
                indice++;
            }
            return true;
        }

        private bool NoGuion(string texto)
        {
            int indice = 0;
            while (indice < texto.Length)
            {
                if (texto[indice] == '-')
                {
                    return false;
                }
                indice++;
            }
            return true;
        }
    }
}
