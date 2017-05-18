using System;
using System.Windows;

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
            CrearJarras();
        }

        private void CrearJarras()
        {
            string capacidadA = tbxJarraA.Text;
            string capacidadB = tbxJarraB.Text;

            try
            {
                if (!string.IsNullOrEmpty(capacidadA) && !(string.IsNullOrEmpty(capacidadB)))
                {
                    jarraA = new Jarra(int.Parse(capacidadA));
                    jarraB = new Jarra(int.Parse(capacidadB));
                    pgbJarraA.Maximum = jarraA.Capacidad;
                    pgbJarraA.Value = jarraA.Cantidad;
                    pgbJarraB.Maximum = jarraB.Capacidad;
                    pgbJarraB.Value = jarraB.Cantidad;
                    tbxPasos.Text = "Se llenan las jarras\r\n";
                    btnCrear.IsEnabled = false;
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnLlenarJarraA_Click(object sender, RoutedEventArgs e)
        {
            if (jarraA != null)
            {
                LlenarJarraA();
            }
        }

        private void LlenarJarraA()
        {
            jarraA.Llenar();
            pgbJarraA.Value = jarraA.Cantidad;
            tbxPasos.Text += "Lleno la jarra A \r\n";
        }

        private void btnVaciarJarraA_Click(object sender, RoutedEventArgs e)
        {
            if (jarraA != null && jarraA.Cantidad > 0)
            {
                VaciarJarraA();
            }
        }

        private void VaciarJarraA()
        {
            jarraA.Vaciar();
            pgbJarraA.Value = jarraA.Cantidad;
            tbxPasos.Text += "Vacío la jarra A \r\n";
        }

        private void btnLlenarJarraB_Click(object sender, RoutedEventArgs e)
        {
            if (Iniciadas())
            {
                LlenarJarraB();
            }
        }

        private void LlenarJarraB()
        {
            jarraB.Llenar();
            pgbJarraB.Value = jarraB.Cantidad;
            tbxPasos.Text += "Lleno la jarra B \r\n";
        }

        private void btnVaciarJarraB_Click(object sender, RoutedEventArgs e)
        {
            if (Iniciadas() && jarraB.Cantidad > 0)
            {
                VaciarJarraB();
            }
        }

        private void VaciarJarraB()
        {
            jarraB.Vaciar();
            pgbJarraB.Value = jarraB.Cantidad;
            tbxPasos.Text += "Vacío la jarra B \r\n";
        }

        private void btnJarraBJarraA_Click(object sender, RoutedEventArgs e)
        {
            if (Iniciadas() && jarraA.Capacidad > jarraA.Cantidad && jarraB.Cantidad > 0)
            {
                VolcarJarraBJarraA();
            }
        }

        private void VolcarJarraBJarraA()
        {
            jarraA.LLenarDesde(jarraB);
            pgbJarraB.Value = jarraB.Cantidad;
            pgbJarraA.Value = jarraA.Cantidad;
            tbxPasos.Text += "Vuelco la jarra B a la jarra A \r\n";
        }

        private void btnJarraAJarraB_Click(object sender, RoutedEventArgs e)
        {
            if (Iniciadas() && jarraB.Capacidad > jarraB.Cantidad && jarraA.Cantidad > 0)
            {
                VolcarJarraAJarraB();
            }
        }

        private void VolcarJarraAJarraB()
        {
            jarraB.LLenarDesde(jarraA);
            pgbJarraB.Value = jarraB.Cantidad;
            pgbJarraA.Value = jarraA.Cantidad;
            tbxPasos.Text += "Vuelco la jarra A a la jarra B \r\n";
        }

        private bool Iniciadas()
        {
            return jarraA != null && jarraB != null;
        }

        private void btnDemo_Click(object sender, RoutedEventArgs e)
        {
            string capacidadA = "5";
            string capacidadB = "7";
            tbxJarraA.Text = capacidadA;
            tbxJarraB.Text = capacidadB;
            CrearJarras();
            VaciarJarraB();
            VolcarJarraAJarraB();
            LlenarJarraA();
            VolcarJarraAJarraB();
            VaciarJarraB();
            VolcarJarraAJarraB();
            LlenarJarraA();
            VolcarJarraAJarraB();
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            if (Iniciadas())
            {
                jarraA = null;
                jarraB = null;
                tbxPasos.Text = string.Empty;
                btnCrear.IsEnabled = true;
            }
        }
    }
}
