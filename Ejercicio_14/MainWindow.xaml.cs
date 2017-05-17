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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog abrirDoc = new OpenFileDialog();
            abrirDoc.Multiselect = false;
            
            abrirDoc.ShowDialog();
            if (abrirDoc.CheckFileExists)
            {
                int nLineas = 0;
                int nPalabras = 0;
                FileInfo archivo = new FileInfo(abrirDoc.FileName);
                long tamanio = archivo.Length/1024;
                using (StreamReader flujo = new StreamReader(archivo.OpenRead()))
                {
                    string linea = string.Empty;
                    
                    while ((linea = flujo.ReadLine()) != null)
                    {
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
            }
        }
    }
}
