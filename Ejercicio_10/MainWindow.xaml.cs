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
        StringBuilder contenido = new StringBuilder();
        bool esNumero = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            ActualizarTextbox(sender);
        }

        private void ActualizarTextbox(object sender)
        {

            contenido.Append(((Button)sender).Content.ToString());
            tbxCalculo.Text = contenido.ToString();
        }

        private void Operador_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCero_Click(object sender, RoutedEventArgs e)
        {
            int num = -1;
            if (contenido.Length > 0)
            {
                esNumero = int.TryParse(contenido[contenido.Length - 1].ToString(), out num);
            }
            if (num > 0 || esNumero)
            {
                ActualizarTextbox(sender);
                if (!esNumero)
                {
                    esNumero = true;
                }
            }


        }

    }
}
