using System;
using System.Windows;
//-------------------------------------
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;

namespace Ejercicio_21
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

        void abrirDoc_FileOk(object sender, CancelEventArgs e)
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
            const int TAMANIO = 100;
            string[] palabras;
            int nPalabras;
            string palabraMax = "";
            string palabraMin = "".PadRight(200);
            int lineaMax = 0;
            int lineaMin = 0;
            char caracter;
            bool EsLetraoDig;
            int nVeces;
            int nMasVeces = 0;
            int nMenosVeces = int.MaxValue;
            string palabraMasVeces = string.Empty;
            string palabraMenosVeces = string.Empty;

            using (StreamReader flujo = new StreamReader(ruta))
            {
                string linea = string.Empty;

                while ((linea = flujo.ReadLine()) != null)
                {
                    nLineas++;
                    EsLetraoDig = false;
                    palabras = new string[TAMANIO];
                    nPalabras = -1;
                    for (int indice = 0; indice < linea.Length; indice++)
                    {
                        if (char.IsLetterOrDigit(caracter=linea[indice]))
                        {
                            if (!EsLetraoDig)
                            {
                                EsLetraoDig = true;
                                nPalabras++;
                            }
                            palabras[nPalabras] += caracter;
                        }
                        else
                        {
                            EsLetraoDig = false;
                        }
                    }
                    for (int indice = 0; indice < nPalabras+1; indice++)
                    {
                        if (palabras[indice].Length > palabraMax.Length)
                        {
                            palabraMax = palabras[indice];
                            lineaMax = nLineas;
                        }
                        if (palabras[indice].Length < palabraMin.Length)
                        {
                            palabraMin = palabras[indice];
                            lineaMin = nLineas;
                        }
                        nVeces = 0;
                        for (int i = 0; i < nPalabras+1; i++)
                        {
                            if (palabras[indice] == palabras[i])
                            {
                                nVeces++;
                            }
                        }
                        if (nVeces > nMasVeces)
                        {
                            palabraMasVeces = palabras[indice];
                            nMasVeces = nVeces;
                        }
                        if (nVeces < nMenosVeces)
                        {
                            palabraMenosVeces = palabras[indice];
                            nMenosVeces = nVeces;
                        }
                    }
                }
            }

            MostrarDatos(palabraMax, lineaMax, palabraMin, lineaMin, nMasVeces, palabraMasVeces, nMenosVeces, palabraMenosVeces);
        }

        private void MostrarDatos(string palabraMax, int lineaMax, string palabraMin, int lineaMin, int nMasVeces, string palabraMasVeces, int nMenosVeces, string palabraMenosVeces)
        {
            lblPalabraMax.Content = palabraMax;
            lblLongitudMax.Content = "Longitud: "+palabraMax.Length;
            lblLineaMax.Content = "Línea: "+lineaMax;
            lblPalabraMin.Content = palabraMin;
            lblLongitudMin.Content = "Longitud: " + palabraMin.Length;
            lblLineaMin.Content = "Línea: " + lineaMin;
            lblPalabraMasVeces.Content = palabraMasVeces;
            lblMasVeces.Content = nMasVeces + " veces";
            lblPalabraMenosVeces.Content = palabraMenosVeces;
            lblMenosVeces.Content = nMenosVeces + " veces";
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
                else
                {
                    MessageBox.Show("No se pudo encontrar el archivo en la ruta especificada", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo encontrar el archivo", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
