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
            tbxResultado.Text = "";
            foreach (int primo in resultado)
            {
                tbxResultado.Text += "{" + contador++ + "} → " + primo+"\r\n";
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
            bool encontrado = false;
            if (candidato > 1)
            {
                for (int i = 2; i <= candidato/2; i++)
                {
                    if (candidato % i == 0) 
                    {
                        encontrado = true;
                    }
                }
            }
            else
            {
                encontrado = true;
            }
            return !encontrado;
        }

        private void btnPalindromo_Click(object sender, RoutedEventArgs e)
        {
            if (tbxPalindromo.Text.Length > 0)
            {
                if (EsPalidromo(tbxPalindromo.Text))
                {
                    MessageBox.Show("Es palíndromo", "Resultado", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("No es palíndromo", "Resultado", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            } 
        }

        bool EsPalidromo(string texto)
        {
            char[] separador = new char[]{',', ';',' ','.'};
            string[] cadenas = texto.ToUpper().Split(separador);
            string contenido = string.Empty;
            string candidato = string.Empty;
            string reves = string.Empty;
            foreach (string palabra in cadenas)
            {
                contenido += palabra;
            }
            foreach (char letra in contenido)
            {
                switch (letra)
                {
                    case 'Á':
                        candidato += 'A';
                        break;
                    case 'É':
                        candidato += 'E';
                        break;
                    case 'Í':
                        candidato += 'I';
                        break;
                    case 'Ó':
                        candidato += 'O';
                        break;
                    case 'Ú':
                        candidato += 'U';
                        break;
                    default:
                        candidato += letra;
                        break;
                }
            }
            for (int i = candidato.Length - 1; i >= 0; i--)
            {
                reves += candidato[i];
            }
            return candidato == reves;
        }

        private void cbxPalindromo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem seleccion = (ComboBoxItem) cbxPalindromo.Items[cbxPalindromo.SelectedIndex];
            tbxPalindromo.Text = seleccion.Content.ToString();
        }
    }
}
