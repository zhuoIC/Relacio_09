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
            if (temporizador == null || !(temporizador.IsEnabled))
            {
                Canvas.SetLeft(elpBola, 265);
                Canvas.SetTop(elpBola, 60);
                temporizador = new DispatcherTimer();
                temporizador.Interval = new TimeSpan((long)Math.Pow(10, 4));
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
                Canvas.SetLeft(elpBola, Canvas.GetLeft(elpBola)+1);
            }
            else
            {
                Canvas.SetLeft(elpBola, Canvas.GetLeft(elpBola)-1);
            }

            if (ejeY)
            {
                Canvas.SetTop(elpBola, Canvas.GetTop(elpBola)+1);
            }
            else
            {
                Canvas.SetTop(elpBola, Canvas.GetTop(elpBola) -1);
            }
            //-------------------------------------------------------------------

            if (ejeY)
            {
                if (cnvJuego.ActualHeight == Canvas.GetTop(elpBola)+elpBola.Height)
                {
                    temporizador.Stop();
                    MessageBox.Show("Perdiste");
                }
                else
                {
                    Punto ExtremoIzq = new Punto(Canvas.GetLeft(rctBarra), Canvas.GetTop(rctBarra));
                    Punto ExtremoDer = new Punto(Canvas.GetLeft(rctBarra) + rctBarra.Width, Canvas.GetTop(rctBarra));
                    Punto baseBola = new Punto(Canvas.GetLeft(elpBola)+ elpBola.Width, Canvas.GetTop(elpBola)+ elpBola.Height);

                    if (ExtremoIzq.Y == baseBola.Y && (baseBola.X >= ExtremoIzq.X && baseBola.X <= ExtremoDer.X))
                    {
                        ejeY = !ejeY;
                    }
                    
                }
            }
            else
            {
                if (0 == Canvas.GetTop(elpBola))
                {
                    ejeY = !ejeY;
                }
            }

            if (ejeX)
            {
                if (cnvJuego.ActualWidth == Canvas.GetLeft(elpBola) + elpBola.Width)
                {
                    ejeX = !ejeX;
                }
            }
            else
            {
                if (0 == Canvas.GetLeft(elpBola))
                {
                    ejeX = !ejeX;
                }
            }
        }
        

        private void btnPausa_Click(object sender, RoutedEventArgs e)
        {
            if (temporizador != null && temporizador.IsEnabled)
            {
                temporizador.Stop();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (temporizador != null && temporizador.IsEnabled)
            {
                MoverBarra(e.Key);
            }
        }

        private void MoverBarra(Key tecla)
        {
            Punto ExtremoIzq = new Punto(Canvas.GetLeft(rctBarra), Canvas.GetTop(rctBarra));
            Punto ExtremoDer = new Punto(Canvas.GetLeft(rctBarra) + rctBarra.Width, Canvas.GetTop(rctBarra));

            if (Key.Left == tecla)
            {
                if (ExtremoIzq.X >= 0)
                {
                    Canvas.SetLeft(rctBarra, Canvas.GetLeft(rctBarra) -10);
                }
            }
            else if (Key.Right == tecla)
            {
                if (ExtremoDer.X <= cnvJuego.ActualWidth)
                {
                    Canvas.SetLeft(rctBarra, Canvas.GetLeft(rctBarra) + 10);
                }
            }
        }


        
    }
}
