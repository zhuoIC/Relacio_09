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
        bool ejeX = true;
        bool ejeY = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            Ellipse bola = new Ellipse();
            temporizador = new DispatcherTimer();
            temporizador.Interval = new TimeSpan((long)Math.Pow(10,9));
            temporizador.Tick += temporizador_Tick;
            temporizador.Start();
        }

        void temporizador_Tick(object sender, EventArgs e)
        {
            MoverBola();
        }


        void MoverBola()
        {
            if (ejeY)
            {
                elpBola.SetValue(Canvas.LeftProperty, elpBola.Height++);
            }
            else
            {
                elpBola.SetValue(Canvas.LeftProperty, elpBola.Height--);
            }

            if (ejeX)
            {
                elpBola.SetValue(Canvas.LeftProperty, elpBola.Width++);
            }
            else
            {
                elpBola.SetValue(Canvas.LeftProperty, elpBola.Width--);
            }
            if (ejeY)
            {
                if (cnvJuego.MaxHeight == elpBola.ActualHeight)
                {
                    temporizador.Stop();
                    MessageBox.Show("Perdiste");
                }
                else if (Canvas.GetBottom(elpBola) == Canvas.GetTop(rctBarra))
                {
                    ejeY = !ejeY;
                }
            }
            else
            {
                if (cnvJuego.MinHeight == elpBola.ActualHeight)
                {
                    ejeY = !ejeY;
                }
            }

            if (ejeX)
            {
                if (cnvJuego.MaxWidth ==  elpBola.ActualWidth)
                {
                    ejeX = !ejeX;
                }
            }
            else
            {
                if (cnvJuego.MinWidth == elpBola.ActualWidth)
                {
                    ejeX = !ejeX;
                }
            }
        }
    }
}
