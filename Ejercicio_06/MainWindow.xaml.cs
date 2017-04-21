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
//--------------------------------------
using System.Threading;

namespace Ejercicio_06
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DateTime fecha = DateTime.Now;
        static int hora = fecha.Hour;
        static int minuto = fecha.Minute;
        static int segundo = fecha.Second;

        public MainWindow()
        {
            InitializeComponent();
            
            lblFecha.Content = fecha.ToLongDateString();
            lblHora.Content = hora + ":" + minuto + ":" + segundo;
        }

        private void Encender()
        {
            do
            {
                while (hora <24)
	            {
                        while (minuto < 60)
                        {
                            while (segundo < 60)
                            {
                                if (btnMarcha.IsEnabled)
                                {
                                    break;
                                }
                                lblHora.Content = hora + ":" + minuto + ":" + segundo;
                                Thread.Sleep(1000);
                                segundo++;
                            }
                            minuto++;
                        }
                        hora++;
                }                               
            } while (btnParo.IsEnabled);
        }

        private void btnMarcha_Click(object sender, RoutedEventArgs e)
        {
            btnParo.IsEnabled = true;
            btnMarcha.IsEnabled = false;
            Encender();
        }

        private void btnParo_Click(object sender, RoutedEventArgs e)
        {
            btnParo.IsEnabled = false;
            btnMarcha.IsEnabled = true;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
