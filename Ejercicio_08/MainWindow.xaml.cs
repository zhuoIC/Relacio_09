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

namespace Ejercicio_08
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

        private void btnCalcSumPrimos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int entrada = int.Parse(tbxPrimos.Text);
                List<int> resultado = NPrimos(entrada);
                MostrarResultado(resultado);
            }
            catch (ArgumentNullException exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("No has introducido un entero válido...", "ERROR", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Número introducido demasiado grande...", "ERROR", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void MostrarResultado(List<int> resultado)
        {
            int contador = 1;
            foreach (int primo in resultado)
            {
                lblPrimos.Content = "{" + contador++ + "} → " + primo;
            }
        }

        List<int> NPrimos(int numFin)
        {
            List<int> resultado = new List<int>();
            int contador = 2;

            while (contador <= numFin)
            {
                if (EsPrimo(contador))
                {
                    resultado.Add(contador);
                }
                contador++;
            }
            return resultado;
        }

        bool EsPrimo(int candidato)
        {
            if (candidato > 1)
            {
                for (int i = 1; i < candidato/2; i++)
                {
                    if (i % 2 == 0) 
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
