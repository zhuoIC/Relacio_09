using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
//-------------------------------
using System.Windows.Threading;

namespace NHJ.Ejercicio_15
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer temporizador = null;
        bool ejeX = true;
        bool ejeY = false;
        decimal puntuacion = 0;
        int velocidadBola = 1;
        int velocidadBarra = 10;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            if (temporizador == null || !(temporizador.IsEnabled))
            {
                    IniciarJuego();
            }
            else if (temporizador.IsEnabled)
	        {
                temporizador.Stop();
		        if (MessageBoxResult.Yes == MessageBox.Show("¿Seguro que quiere empezar una nueva partida?", "Ya hay una partida empezada", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    temporizador = null;
                    IniciarJuego();
                }
                else
                {
                    temporizador.Start();
                }
	        }
        }

        private void IniciarJuego()
        {
            puntuacion = 0;
            lbl.Content = (object)puntuacion.ToString("000");
            Canvas.SetLeft(elpBola, Canvas.GetLeft(elpBola));
            Canvas.SetTop(elpBola, elpBola.Height);
            temporizador = new DispatcherTimer();
            temporizador.Interval = new TimeSpan(10000);
            temporizador.Start();
            temporizador.Tick += temporizador_Tick;
        }

        void temporizador_Tick(object sender, EventArgs e)
        {
            MoverBola();
            ComprobarChoques();
        }

        void MoverBola()
        {
            if (ejeX)
            {
                Canvas.SetLeft(elpBola, Canvas.GetLeft(elpBola)+velocidadBola);
            }
            else
            {
                Canvas.SetLeft(elpBola, Canvas.GetLeft(elpBola) - velocidadBola);
            }

            if (ejeY)
            {
                Canvas.SetTop(elpBola, Canvas.GetTop(elpBola) + velocidadBola);
            }
            else
            {
                Canvas.SetTop(elpBola, Canvas.GetTop(elpBola) - velocidadBola);
            }
        }

        private void ComprobarChoques()
        {
            if (ejeY)
            {
                if (cnvJuego.ActualHeight <= Canvas.GetTop(elpBola) + elpBola.ActualHeight) // Choca suelo
                {
                    temporizador.Stop();
                    temporizador = null;
                    MessageBox.Show("Puntuación = "+puntuacion, "¡Has perdido!", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else
                {
                    Punto ExtremoIzq = new Punto(Canvas.GetLeft(rctBarra), Canvas.GetTop(rctBarra));
                    Punto ExtremoDer = new Punto(Canvas.GetLeft(rctBarra) + rctBarra.ActualWidth, Canvas.GetTop(rctBarra));
                    Punto basebola = new Punto(Canvas.GetLeft(elpBola) + elpBola.ActualWidth / 2, Canvas.GetTop(elpBola) + elpBola.ActualHeight);
                    Punto lateralIzqBola = new Punto(Canvas.GetLeft(elpBola), Canvas.GetTop(elpBola) + elpBola.Height / 2);
                    // Choque barra
                    if (ExtremoIzq.Y == basebola.Y)
                    {
                        if (basebola.X > ExtremoIzq.X && basebola.X < ExtremoDer.X)
                        {
                            ejeY = false;
                            puntuacion += 1;
                            Victoria();
                            lbl.Content = (object)puntuacion.ToString("000");
                        }
                    }
                    else if (ExtremoIzq.Y < basebola.Y) // Por debajo barra
                    {
                        if (Canvas.GetLeft(elpBola) + elpBola.ActualWidth == ExtremoIzq.X) //Lado Izq
                        {
                            ejeX = !ejeX;
                        }

                        else if (Canvas.GetLeft(elpBola) == ExtremoDer.X) //Lado Der
                        {
                            ejeX = !ejeX;
                        }
                        if (ExtremoIzq.Y > lateralIzqBola.Y && lateralIzqBola.X <= ExtremoDer.X && lateralIzqBola.X + elpBola.ActualWidth >= ExtremoIzq.X)// choque esquinas
                        {
                            if (lateralIzqBola.X  >= ExtremoIzq.X) // Esquina derecha
                            {
                                ejeX = true;
                            }
                            else // Esquina izquierda
                            {
                                ejeX = false;  
                            }
                            ejeY = !ejeY;
                            puntuacion += 5;
                            Victoria();
                            lbl.Content = (object)puntuacion.ToString("000");            
                        }
                    }
                }
            }
            else
            {
                // Choque techo
                if (0 >= Canvas.GetTop(elpBola))
                {
                    ejeY = !ejeY;
                }
            }

            if (ejeX)
            {
                // Choque pared derecha
                if (cnvJuego.ActualWidth <= Canvas.GetLeft(elpBola) + elpBola.ActualWidth)
                {
                    ejeX = !ejeX;
                }
            }
            else
            {
                // Choque pared izquierda
                if (0 >= Canvas.GetLeft(elpBola))
                {
                    ejeX = !ejeX;
                }
            }
        }

        private void Victoria()
        {
            if (puntuacion >= 999)
            {
                temporizador.Stop();
                temporizador = null;
                MessageBox.Show("Puntuación = " + puntuacion, "¡Has ganado!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnPausa_Click(object sender, RoutedEventArgs e)
        {
            if (temporizador != null)
            {
                if (temporizador.IsEnabled)
                {
                    temporizador.Stop();
                }
                else
                {
                    temporizador.Start();
                }
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
            Punto ExtremoDer = new Punto(Canvas.GetLeft(rctBarra) + rctBarra.ActualWidth, Canvas.GetTop(rctBarra));
            Punto baseBola = new Punto(Canvas.GetLeft(elpBola) + elpBola.ActualWidth, Canvas.GetTop(elpBola) + elpBola.ActualHeight);

            if (baseBola.Y <= ExtremoIzq.Y)
            {
                if (Key.Left == tecla)
                {
                    if (ExtremoIzq.X >= 0)
                    {
                        Canvas.SetLeft(rctBarra, Canvas.GetLeft(rctBarra) - velocidadBarra);
                    }
                }
                else if (Key.Right == tecla)
                {
                    if (ExtremoDer.X <= cnvJuego.ActualWidth)
                    {
                        Canvas.SetLeft(rctBarra, Canvas.GetLeft(rctBarra) + velocidadBarra);
                    }
                } 
            }
        }

        private void Finalizar_Click(object sender, RoutedEventArgs e)
        {
            if (temporizador != null)
            {
                temporizador.Stop();
                if (MessageBoxResult.No == MessageBox.Show("¿Terminar partida?", "Pausa", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    temporizador.Start();
                }
                else
                {
                    temporizador = null;
                } 
            }
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            if (temporizador == null)
            {
                velocidadBarra = 15;
                velocidadBola = 3;
                rctBarra.Width = 60;
            }
        }

        private void Experto_Click(object sender, RoutedEventArgs e)
        {
            if (temporizador == null)
            {
                velocidadBarra = 20;
                velocidadBola = 5;
                rctBarra.Width = 24;
            }
        }

        private void Principiante_Click(object sender, RoutedEventArgs e)
        {
            if (temporizador == null)
            {
                velocidadBarra = 10;
                velocidadBola = 1;
                rctBarra.Width = 85;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (temporizador != null)
            {
                temporizador.Stop();
            }
            if (MessageBoxResult.No == MessageBox.Show("¿Seguro que quiere salir?", "Pausa", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                e.Cancel = true;
                if (temporizador != null)
                    temporizador.Start();
            }
        }
    }
}
