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

namespace Ejercicio_04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSumar_Click(object sender, RoutedEventArgs e)
        {
            string tbxIni = string.Empty;
            string tbxFin = string.Empty;
            int numIni = 0;
            int numFin = 0;
            bool exitoIni = false;
            bool exitoFin = false;
            double resultado = 0;

            tbxIni = tbxInput.Text;
            tbxFin = tbxOutput.Text;
            exitoIni = int.TryParse(tbxIni, out numIni);
            exitoFin = int.TryParse(tbxFin, out numFin);
            if (exitoIni && exitoFin)
            {
                if(numIni <= numFin)
                {
                    resultado = SumaEnteros(numIni, numFin);
                    lblBarraEstado.Content = "La suma de los enteros entre "
                        + numIni + " y " + numFin + " es: " + resultado;
                }
                else
                {
                    lblBarraEstado.Content = "El número final es mayor que el inicial";
                }
            }
            else
            {
                lblBarraEstado.Content = "Numero(s) introducido(s) no válido(s)";
            }
        }

        private static double SumaEnteros(int inicial, int final)
        {
            double resultado = 0;
            for (int i = inicial; i <= final; i++)
            {
                resultado += i; 
            }
            return resultado;
        }

    }
}
