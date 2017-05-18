using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace Ejercicio_02
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

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> operandos = SepararComandos();
                double resultado = HallarResultado(operandos);
                txtResultado.Text = resultado.ToString();
                txtResultado.Opacity = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private static double HallarResultado(List<string> operandos)
        {
            double resultado = double.Parse(operandos[0]);
            int i = 0;
            while (i < operandos.Count)
            {
                if (i % 2 != 0)
                {
                    switch (operandos[i])
                    {
                        case "*":
                            resultado = resultado * double.Parse(operandos[++i]);
                            break;
                        case "+":
                            resultado = resultado + double.Parse(operandos[++i]);
                            break;
                        case "-":
                            resultado = resultado - double.Parse(operandos[++i]);
                            break;
                        case "/":
                            resultado = resultado / double.Parse(operandos[++i]);
                            break;
                    }
                }
                i++;
            }
            return resultado;
        }

        private List<string> SepararComandos()
        {
            string contenido = tbxCalculadora.Text;
            bool operadorPrevio = false;
            string tmp = string.Empty;
            List<string> operaciones = new List<string>();

            foreach (char caracter in contenido)
            {
                if (char.IsDigit(caracter) || caracter==',')
                {
                    
                    if (!operadorPrevio && operaciones.Count > 0)
                    {
                        tmp = operaciones[operaciones.Count - 1] + caracter;
                        operaciones[operaciones.Count - 1] = tmp;
                        tmp = string.Empty;
                    }
                    else
                    {
                        operaciones.Add(caracter.ToString());
                    }
                    operadorPrevio = false;
                }
                else if (!operadorPrevio && operaciones.Count > 0)
                {
                    switch (caracter)
                    {
                        case '*':
                        case '/':
                        case '+':
                        case '-':
                            operaciones.Add(caracter.ToString());
                            break;
                        default:
                            throw new ExpresionMalFormadaException();
                    }
                    operadorPrevio = true;
                }
                else
                {
                    throw new ExpresionMalFormadaException();
                }
            }
            if (operadorPrevio) // Si el ultimo caracter es un operador se eleva la excepcion
            {
                throw new ExpresionMalFormadaException();
            }
            return operaciones;
        }

    }

    public class ExpresionMalFormadaException : Exception 
    {
        public override string Message
        {
            get
            {
                return "Se han introducido mal los datos";
            }
        }
    }
}
