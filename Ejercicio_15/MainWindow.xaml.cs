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
//-------------------------------
using System.Windows.Threading;
namespace Ejercicio_15
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer temporizador = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            temporizador = new DispatcherTimer();
            temporizador.Interval = new TimeSpan((long)Math.Pow(10,9));
            temporizador.Tick += temporizador_Tick;
        }

        void temporizador_Tick(object sender, EventArgs e)
        {
            double xE = Canvas.GetLeft(elpBola);
            double yE = Canvas.GetTop(elpBola);
            double xR = Canvas.GetLeft(rctBarra);
            double yR = Canvas.GetTop(rctBarra);
            if (true)
            {
                
            }
            elpBola.Width = xE;
            elpBola.Height = yE;
        }

        private void rctBarra_TouchMove(object sender, TouchEventArgs e)
        {

        }
    }
}
