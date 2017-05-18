using System;
using System.Windows;
//----------------------------------
using System.IO;
using Microsoft.Win32;

namespace Ejercicio_14
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

        private void btnExaminar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog abrirDoc = new OpenFileDialog();
            abrirDoc.Multiselect = false;

            abrirDoc.FileOk += abrirDoc_FileOk;
            abrirDoc.ShowDialog();
        }

        void abrirDoc_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenFileDialog doc = ((OpenFileDialog)sender);
            if (doc.CheckFileExists)
            {
                string ruta = doc.FileName;
                tbxRuta.Text = ruta;
                AccederArchivo(ruta);
            }
        }

        private void AccederArchivo(string ruta)
        {
            int nLineas = 0;
            int nPalabras = 0;
            FileInfo archivo = new FileInfo(ruta);
            string tamanio = ((double)archivo.Length / 1024).ToString("0.000") + " kB";
            using (StreamReader flujo = new StreamReader(archivo.OpenRead()))
            {
                string linea = string.Empty;

                while ((linea = flujo.ReadLine()) != null)
                {
                    nLineas++;
                    bool EsLetraoDig = false;
                    for (int i = 0; i < linea.Length; i++)
                    {
                        if (char.IsLetterOrDigit(linea[i]))
                        {
                            if (!EsLetraoDig)
                            {
                                EsLetraoDig = true;
                                nPalabras++;
                            }
                        }
                        else
                        {
                            EsLetraoDig = false;
                        }
                    }
                }
            }

            MostrarDatos(nLineas, nPalabras, archivo, tamanio);
        }

        private void MostrarDatos(int nLineas, int nPalabras, FileInfo archivo, string tamanio)
        {
            lblAtributos.Content = archivo.Attributes;
            lblLineas.Content = nLineas;
            lblPalabras.Content = nPalabras;
            lblTamanio.Content = tamanio;
        }

        private void btnAbrir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ruta = Path.GetFullPath(tbxRuta.Text);

                if (File.Exists(ruta))
                {
                    AccederArchivo(ruta);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo encontrar el archivo", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
