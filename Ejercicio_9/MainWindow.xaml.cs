using System;
using System.Windows;
using System.Windows.Media.Imaging;
//---------------------------------------------
using System.Windows.Threading;
using System.Threading;

namespace Ejercicio_9
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int[] dado = new int[6];
        static Random rnd = new Random();
        int nTiradas = 0;

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

        private void btnTirar_Click(object sender, RoutedEventArgs e)
        {
            TirarDado();
        }

        private void TirarDado()
        {
            int resultado = 0;
            if (cbxSimular.IsChecked == true)
            {
                SimularTirada();
            }
            resultado = rnd.Next(dado.Length);
            dado[resultado]++;
            MostrarResultado(resultado);
            MostrarImagen(resultado);
            MostrarEstadistica();
        }

        private void MostrarImagen(int indice)
        {
            BitmapImage img = new BitmapImage(new Uri(imagenes[indice]));
            imgDado.Source = img;
        }

        private void MostrarResultado(int resultado)
        {
            tbxResultado.Text += ++nTiradas + "→" + (resultado+1)+"\r\n";
        }

        private void MostrarEstadistica()
        {
            int contador = 1;
            tbxEstadistica.Text = "";
            foreach (int cara in dado)
            {
                tbxEstadistica.Text += contador + "→" + cara + "→"+(cara*100)/nTiradas+"%\r\n";
                contador++;
            }
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            if (tbxNTiradas.Text.Length > 0)
            {
                int nTiradas = int.Parse(tbxNTiradas.Text);
                for (int i = 0; i < nTiradas; i++)
                {
                    TirarDado();
                }
            }
        }

        void temporizador_Tick(object sender, EventArgs e)
        {
            int alea = rnd.Next(dado.Length);
            MostrarImagen(alea);
        }

        void SimularTirada()
        {
            for (int i = 0; i < dado.Length; i++)
            {
                MostrarImagen(i);
                Thread.Sleep(1);
            }
        }
    }
}
