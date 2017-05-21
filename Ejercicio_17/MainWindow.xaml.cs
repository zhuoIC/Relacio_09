using System;
using System.Windows;
using System.Windows.Media.Imaging;
//---------------------------
using System.IO;

namespace Ejercicio_17
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int LADOS  = 6;
        int _dado1 = LADOS;
        int _dado2 = LADOS;
        int _punto = -1;
        static Random rnd = new Random();

        static string[] imagenes = new string[] 
        { 
            @"..\..\Imagenes\1.png",
            @"..\..\Imagenes\2.png",
            @"..\..\Imagenes\3.png",
            @"..\..\Imagenes\4.png",
            @"..\..\Imagenes\5.png",
            @"..\..\Imagenes\6.png"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private int TirarDados()
        {
            int resultado = 0;
            resultado += MostrarDado1(rnd.Next(_dado1)) + 1;
            resultado += MostrarDado2(rnd.Next(_dado2)) + 1;
            return resultado;
        }

        private int MostrarDado1(int indice)
        {
            BitmapImage img = new BitmapImage(new Uri(Path.GetFullPath(imagenes[indice])));
            imgDado1.Source = img;
            return indice;
        }

        private int MostrarDado2(int indice)
        {
            BitmapImage img = new BitmapImage(new Uri(Path.GetFullPath(imagenes[indice])));
            imgDado2.Source = img;
            return indice;
        }

        /// ComprobarResultado
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sumaDados">1 Victoria, 0 Derrota, -1 Sigue jugando</param>
        /// <returns></returns>
        private int ComprobarResultado(int sumaDados)
        {
            int EsVictoria = -1;
            if (_punto == -1)
            {
                if (sumaDados == 7 || sumaDados == 11)
                {
                    EsVictoria = 1;
                }
                else if (sumaDados == 2 || sumaDados == 3 ||sumaDados == 12)
                {
                    EsVictoria = 0;
                }
                _punto = sumaDados;
                lblPunto.Content = "Tu punto: " + _punto;
            }
            else
            {
                if (sumaDados == 7)
                {
                    EsVictoria = 0;
                }
                else if (_punto == sumaDados)
                {
                    EsVictoria = 1;
                }
            }
            return EsVictoria;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int sumaDados = 0;
            int resultado = ComprobarResultado(sumaDados=TirarDados());

            lblResultado.Content = "Resultado: " + sumaDados;

            if (resultado == 1)
            {
                MessageBox.Show("¡Has ganado!", "Enhorabuena", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                _punto = -1;
            }
            else if (resultado == 0)
            {
                MessageBox.Show("Has perdido...", "Lo sentimos", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                _punto = -1;
            }
        }
    }
}
