using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using BackEnd;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea4
{
    /// <summary>
    /// Lógica de interacción para Coseno.xaml
    /// </summary>
    /// 

    public partial class Coseno : UserControl
    {
        public Input paraPrimero;
        public Input paraSegundo;
        public OutputIntermedio output;
        public OutputFinal outFinal;
        CosenoBackEnd logica;
        public Coseno()
        {
            InitializeComponent();
            logica = new CosenoBackEnd();
            logica.actualizarResultado += new Action<double>(log_actualResultados);
        }

        public void b(object sender, RoutedEventArgs e)
        {

            MainWindow.ufu.Children.Remove(this);

        }

        public void a(object sender, RoutedEventArgs e)
        {
            double num1 = 0;
            double num2 = 0;

            if (paraPrimero != null)
            {
                textBox1.Text = paraPrimero.prim.Text;
            }
            if (paraPrimeroO != null)
            {
                textBox1.Text = paraPrimeroO.textBlock2.Text;
            }
            if (pprim != null)
            {
                textBox1.Text = pprim.textBlock1.Text;
            }

            if (Double.TryParse(textBox1.Text, out num1))
            {
                logica.calcular(num1);
            }

        }

        Separador pprim;
        void log_actualResultados(double suma)
        {
            textBlock1.Text = "" + suma;
        }
        OutputIntermedio paraPrimeroO;

        private void textBox1_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.finaliza = this;
            if (MainWindow.inicia is Input)
            {
                Input ini = (Input)MainWindow.inicia;
                paraPrimero = ini;
            }
            else if (MainWindow.inicia is OutputIntermedio)
            {
                OutputIntermedio ini = (OutputIntermedio)MainWindow.inicia;
                paraPrimeroO = ini;
            }
            else if (MainWindow.inicia is Separador)
            {
                Separador ini = (Separador)MainWindow.inicia;
                pprim = ini;

            }
        }

        private void textBlock1_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.inicia = this;
        }


    }
}
