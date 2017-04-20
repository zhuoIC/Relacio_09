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

namespace Ejercicio_03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int num;
        static Random rnd = new Random();
        static int intentos = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lblNum.Opacity = 100;
        }

        private void cbxVerNumero_Unchecked(object sender, RoutedEventArgs e)
        {
            lblNum.Opacity = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            num = rnd.Next(1,101);
            lblNum.Content = num;
            btnGenerar.IsEnabled = false;
            btnProbar.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int candidato = int.Parse(tbxAcertar.Text);
                intentos++;
                if (candidato > 100 || candidato < 0)
                {
                    MessageBox.Show("El número a buscar es entre 0 y 100 incluidos", "¡Cuidado!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (candidato == num)
                    {
                        lblResultado.Content = "";
                        MessageBox.Show("¡Has acertado el número en " + intentos + " intentos!", "¡ENHORABUENA!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        btnGenerar.IsEnabled = true;
                        btnProbar.IsEnabled = false;
                    }
                    else if (candidato < num)
                    {
                        lblResultado.Content = "NO, el número buscado es MAYOR";
                        tbxAcertar.Focus();
                    }
                    else
                    {
                        lblResultado.Content = "NO, el número buscado es MENOR";
                        tbxAcertar.Focus();
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vuelve a intentarlo");
            }
        }
    }
}
