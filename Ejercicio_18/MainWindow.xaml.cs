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

namespace Ejercicio_18
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Jarra jarraA = null;
        Jarra jarraB = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            string capacidadA = tbxJarraA.Text;
            string capacidadB = tbxJarraB.Text;

            if (!string.IsNullOrEmpty(capacidadA) && !(string.IsNullOrEmpty(capacidadB)))
            {
                jarraA = new Jarra(int.Parse(capacidadA));
                jarraB = new Jarra(int.Parse(capacidadB));
                pgbJarraA.Maximum = jarraA.Capacidad;
                pgbJarraA.Value = jarraA.Cantidad;
                pgbJarraB.Maximum = jarraB.Capacidad;
                pgbJarraB.Value = jarraB.Cantidad;
                btnCrear.IsEnabled = false;
            }

        }

        private void btnLlenarJarraA_Click(object sender, RoutedEventArgs e)
        {
            if (jarraA != null)
            {
                jarraA.Llenar();
                pgbJarraA.Value = jarraA.Cantidad;
            }
        }

        private void btnVaciarJarraA_Click(object sender, RoutedEventArgs e)
        {
            if (jarraA != null)
            {
                jarraA.Vaciar();
                pgbJarraA.Value = jarraA.Cantidad;
            }
        }

        private void btnLlenarJarraB_Click(object sender, RoutedEventArgs e)
        {
            if (jarraB != null)
            {
                jarraB.Llenar();
                pgbJarraB.Value = jarraB.Cantidad;
            }
        }

        private void btnVaciarJarraB_Click(object sender, RoutedEventArgs e)
        {
            if (jarraB != null)
            {
                jarraB.Vaciar();
                pgbJarraB.Value = jarraB.Cantidad;
            }
        }

        private void btnJarraBJarraA_Click(object sender, RoutedEventArgs e)
        {
            if (jarraA != null && jarraB != null)
            {
                jarraA.LLenarDesde(jarraB);
                pgbJarraB.Value = jarraB.Cantidad;
                pgbJarraA.Value = jarraA.Cantidad;
            }
        }

        private void btnJarraAJarraB_Click(object sender, RoutedEventArgs e)
        {
            if (jarraA != null && jarraB != null)
            {
                jarraB.LLenarDesde(jarraA);
                pgbJarraB.Value = jarraB.Cantidad;
                pgbJarraA.Value = jarraA.Cantidad;
            }
        }
    }
}
