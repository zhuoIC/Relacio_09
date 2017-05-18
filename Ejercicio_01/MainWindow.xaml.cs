using System.Windows;

namespace Ejercicio_01
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txbNumero.MaxLines = 1;
            txbNumero.MaxLength = 10;
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            bool exito = false;
            long numero = 0;
            long resultado = 0;
            exito = long.TryParse(txbNumero.Text, out numero);
            if (exito && numero >= 0)
            {
                resultado = NPrimerosNumeros(numero);
                MessageBox.Show("Resultado: " + resultado, "Suma");
            }
            else
            {
                MessageBox.Show("Valor introducido no válido", "Error");
            }
        }

        private static long NPrimerosNumeros(long numero)
        {
            long resultado = 0;
            long contador = 1;
            while (contador <= numero)
            {
                resultado += contador;
                contador++;
            }
            return resultado;
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
