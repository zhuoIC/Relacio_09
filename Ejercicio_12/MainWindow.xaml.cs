using System.Windows;
using System.Windows.Media;

namespace Ejercicio_12
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

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            const byte ALPHA = 255;
            byte colorRojo = (byte)(sldRojo.Value);
            byte colorVerde = (byte)(sldVerde.Value);
            byte colorAzul = (byte)(sldAzul.Value);
            stcPanel.Background = new SolidColorBrush(Color.FromArgb(ALPHA, colorRojo, colorVerde, colorAzul));
        }
    }
}
