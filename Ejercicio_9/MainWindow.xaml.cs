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
//---------------------------------------------

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
            TirarDado(1);
        }

        private void TirarDado(int nVeces)
        {
            int contador = 0;
            int resultado = 0;
            while (nVeces > contador)
            {
                resultado = rnd.Next(dado.Length);
                dado[resultado]++;
                MostrarResuLtado(resultado);
                MostrarImagen(resultado);
                contador++;
            }
            MostrarEstadistica();
        }

        private void MostrarImagen(int resultado)
        {
            BitmapImage img = new BitmapImage(new Uri(System.IO.Path.GetFullPath(imagenes[resultado])));
            imgDado.Source = img;
        }

        private void MostrarResuLtado(int resultado)
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
                TirarDado(nTiradas);
            }
        }

    }
}
