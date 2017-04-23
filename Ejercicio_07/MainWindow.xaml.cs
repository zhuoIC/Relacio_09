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

namespace Ejercicio_07
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            VaciarGrid();
        }

        private void RellenarGrid()
        {
            int i = 0;
            int j = 0;
            try
            {
                for (int fila = 0; fila < grdMatriz.ColumnDefinitions.Count; fila++)
                {
                    for (int columna = 0; columna < grdMatriz.RowDefinitions.Count; columna++)
                    {
                        switch (fila)
                        {
                            case 0:
                                i = int.Parse(tbxA.Text);
                                break;
                            case 1:
                                i = int.Parse(tbxB.Text);
                                break;
                            case 2:
                                i = int.Parse(tbxC.Text);
                                break;
                        }
                        switch (columna)
                        {
                            case 0:
                                j = int.Parse(tbx1.Text);
                                break;
                            case 1:
                                j = int.Parse(tbx2.Text);
                                break;
                            case 2:
                                j = int.Parse(tbx3.Text);
                                break;
                        }
                        TextBox tbx = new TextBox();

                        tbx.Text = (i * j).ToString();
                        tbx.Foreground = new SolidColorBrush(Colors.Black);
                        Grid.SetRow(tbx, fila);
                        Grid.SetColumn(tbx, columna);
                        grdMatriz.Children.Add(tbx);
                    }
                }
            }
            catch (ArgumentNullException)
            {
                VaciarGrid();
                MessageBox.Show("Las matrices no están rellenas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException exp)
            {
                VaciarGrid();
                MessageBox.Show("Has introducido uno o más carácteres no válidos"+ exp.HResult, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OverflowException)
            {
                VaciarGrid();
                MessageBox.Show("Número introducido demasiado grande", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                VaciarGrid();
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VaciarGrid()
        {

            for (int fila = 0; fila < grdMatriz.ColumnDefinitions.Count; fila++)
            {
                for (int columna = 0; columna < grdMatriz.RowDefinitions.Count; columna++)
                {
                    TextBox tbx = new TextBox();
                    tbx.Foreground = new SolidColorBrush(Colors.White);
                    Grid.SetRow(tbx, fila);
                    Grid.SetColumn(tbx, columna);
                    tbx.Text = fila + " " + columna;

                    grdMatriz.Children.Add(tbx);
                }
            }
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            RellenarGrid();
        }

    }
}
