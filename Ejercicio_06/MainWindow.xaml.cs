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
using System.Windows.Threading;

namespace Ejercicio_06
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DateTime fecha = DateTime.Now;
        int hora = fecha.Hour;
        int minuto = fecha.Minute;
        int segundo = fecha.Second;
        DispatcherTimer temporizador;
        public MainWindow()
        {
            InitializeComponent();
            
            lblFecha.Content = fecha.ToLongDateString();
            MostrarHora();
            Encender();
        }

        private void Encender()
        {
            temporizador = new DispatcherTimer();
            temporizador.Interval = new TimeSpan(10000000);
            temporizador.Start();
            temporizador.Tick += temporizador_Tick;             
        }

        void temporizador_Tick(object sender, EventArgs e)
        {
            segundo++;
            if (segundo == 60)
            {
                segundo = 0;
                minuto++;
                if (minuto == 60)
                {
                    minuto = 0;
                    hora++;
                    if (hora == 24)
                    {
                        hora = 0;
                    }
                }
            }
            MostrarHora();
            if (segundo == 0 && minuto == 0 && hora == 0)
            {
                lblFecha.Content = fecha.AddDays(1).ToLongDateString();
            }
        }

        void MostrarHora()
        {
            lblHora.Content = hora.ToString("00") + ":" + minuto.ToString("00") + ":" + segundo.ToString("00");
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
            temporizador.Stop();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
