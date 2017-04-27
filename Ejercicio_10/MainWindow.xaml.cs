using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio_10
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] operandos = new string[3];
        int nDatos = 0;
        string resultado = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            if (nDatos == 0 || nDatos == 2)
            {
                nDatos++;
            }
            operandos[nDatos - 1] = ((Button)sender).Content.ToString();

            tbxCalculo.Text = ((Button)sender).Content.ToString();
            btnSignoUnitario.IsEnabled = true;
        }

        private void Operador_Click(object sender, RoutedEventArgs e)
        {
            if (nDatos > 0)
            {
                if (btnSignoUnitario.IsEnabled)
                {
                    btnSignoUnitario.IsEnabled = false;
                }
                switch (nDatos)
                {
                    case 1:
                        operandos[nDatos++] = ((Button)sender).Content.ToString();
                        break;
                    case 2:
                        operandos[nDatos - 1] = ((Button)sender).Content.ToString();
                        break;
                }

            }
        }

        void Calcular()
        {
            if (nDatos == 3)
            {
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
            }
        }

        private void btlLimpiarTodo_Click(object sender, RoutedEventArgs e)
        {
            nDatos = 0;
            resultado = string.Empty;
            tbxCalculo.Text = "0";
        }

        private void btnCero_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Calcular();
        }

        private void btnSignoUnitario_Click(object sender, RoutedEventArgs e)
        {
            switch (nDatos)
            {
                case 0:
                case 1:

                    break;
                case 2:
                    break;
            }
        }
    }
}
