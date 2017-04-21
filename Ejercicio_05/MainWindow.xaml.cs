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

namespace Ejercicio_05
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static string EncriptarCesar(int nCaracteres, string texto)
        {
            string encriptado = string.Empty;
            foreach (char letra in texto)
            {
                encriptado += (char)(letra + nCaracteres);
            }
            return encriptado;
        }

        private static string DesencriptarCesar(int nCaracteres, string texto)
        {
            string desencriptado = string.Empty;
            foreach (char letra in texto)
            {
                desencriptado += (char)(letra - nCaracteres);
            }
            return desencriptado;
        }


        private void btnEncrip_Click(object sender, RoutedEventArgs e)
        {
            string frase = string.Empty;
            string encriptado = string.Empty;
            string desencriptado = string.Empty;
            int nCaracteres = int.Parse(cmbNCaracteres.Text);

            frase = tbxIni.Text;
            if (frase.Length > 0)
            {
                tbxOri.Text = frase;
                encriptado = EncriptarCesar(nCaracteres, frase);
                tbxEncrip.Text = encriptado;
                desencriptado = DesencriptarCesar(nCaracteres, encriptado);
                tbxDesencrip.Text = desencriptado;
            }
        }
    }
}
