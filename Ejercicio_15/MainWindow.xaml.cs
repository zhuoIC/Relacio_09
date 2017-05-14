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
        DispatcherTimer temporizador = new DispatcherTimer();
        bool ejeX = true;
        bool ejeY = true;
        Bola nuevaPelota;
        Barra nuevaBarra;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            if (!(temporizador.IsEnabled))
            {
                nuevaPelota = new Bola((int)elpBola.ActualWidth, (int)elpBola.ActualHeight);
                nuevaBarra = new Barra((int)rctBarra.ActualWidth, 259);
                temporizador.Interval = new TimeSpan((long)Math.Pow(10, 5));
                temporizador.Start();
                temporizador.Tick += temporizador_Tick; 
            }
        }

        void temporizador_Tick(object sender, EventArgs e)
        {
            MoverBola();
        }


        void MoverBola()
        {
            if (ejeX)
            {
                Canvas.SetTop(elpBola, ++nuevaPelota.Top.X);
                Canvas.SetLeft(elpBola, ++nuevaPelota.Left.X);
                Canvas.SetRight(elpBola, ++nuevaPelota.Right.X);
                Canvas.SetBottom(elpBola, ++nuevaPelota.Bottom.X);
            }
            else
            {
                Canvas.SetTop(elpBola, --nuevaPelota.Top.X);
                Canvas.SetLeft(elpBola, --nuevaPelota.Left.X);
                Canvas.SetRight(elpBola, --nuevaPelota.Right.X);
                Canvas.SetBottom(elpBola, --nuevaPelota.Bottom.X);
            }

            if (ejeY)
            {
                Canvas.SetTop(elpBola, ++nuevaPelota.Top.Y);
                Canvas.SetLeft(elpBola, ++nuevaPelota.Left.Y);
                Canvas.SetRight(elpBola, ++nuevaPelota.Right.Y);
                Canvas.SetBottom(elpBola, ++nuevaPelota.Bottom.Y);
            }
            else
            {
                Canvas.SetTop(elpBola, --nuevaPelota.Top.Y);
                Canvas.SetLeft(elpBola, --nuevaPelota.Left.Y);
                Canvas.SetRight(elpBola, --nuevaPelota.Right.Y);
                Canvas.SetBottom(elpBola, --nuevaPelota.Bottom.Y);
            }

            if (ejeY)
            {
                if (Math.Round(cnvJuego.ActualHeight) == nuevaPelota.Bottom.Y)
                {
                    temporizador.Stop();
                    MessageBox.Show("Perdiste");
                }
                else
                {
                    int contador = nuevaBarra.ExtremoIzq.X;
                    while (contador < nuevaBarra.ExtremoDer.X)
                    {
                        if (nuevaPelota.Bottom.Y >= nuevaBarra.ExtremoIzq.Y && ((nuevaPelota.Bottom.X >=nuevaBarra.ExtremoIzq.X) &&  (nuevaPelota.Bottom.X <= nuevaBarra.ExtremoIzq.X)))
                        {
                            ejeY = !ejeY;
                            break;
                        }
                        contador++;
                    }
                }
            }
            else
            {
                if (0 == elpBola.ActualHeight)
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

        private void btnPausa_Click(object sender, RoutedEventArgs e)
        {
            if (temporizador.IsEnabled)
            {
                temporizador.Stop();
            }
        }
    }
}
