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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using BackEnd;
using System.Windows.Shapes;

namespace Tarea4
{
    /// <summary>
    /// Lógica de interacción para SeparadorIgual.xaml
    /// </summary>
    public partial class ComparadorIgual : UserControl
    {
        public Input paraPrimero;
        public Input paraSegundo;
        public OutputIntermedio output;
        public OutputFinal outFinal;
        ComparadorIgualBackEnd logica;
        public ComparadorIgual()
        {
            InitializeComponent();
            logica = new ComparadorIgualBackEnd();
            logica.actualizarResultado += new Action<string>(log_actualResultados);

        }

        public void b(object sender, RoutedEventArgs e)
        {

            MainWindow.ufu.Children.Remove(this);

        }
        private void prim_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
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
        }
        public void a(object sender, RoutedEventArgs e)
        {
            double num1 = 0;
            double num2 = 0;

            if (paraPrimero != null)
            {
                prim.Text = paraPrimero.prim.Text;
            }
            if (paraSegundo != null)
            {
                seg.Text = paraSegundo.prim.Text;
            }
            if (paraPrimeroO != null)
            {
                prim.Text = paraPrimeroO.textBlock2.Text;
            }
            if (paraSegundoO != null)
            {
                seg.Text = paraSegundoO.textBlock2.Text;
            }



            if (Double.TryParse(prim.Text, out num1) && Double.TryParse(seg.Text, out num2))
            {
                logica.comparar(num1, num2);
            }

        }

        void log_actualResultados(string suma)
        {
            textB.Text = "" + suma;
        }
        OutputIntermedio paraPrimeroO;
        OutputIntermedio paraSegundoO;


        private void seg_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.finaliza = this;
            if (MainWindow.inicia is Input)
            {
                Input ini = (Input)MainWindow.inicia;
                paraSegundo = ini;
            }
            else if (MainWindow.inicia is OutputIntermedio)
            {
                OutputIntermedio ini = (OutputIntermedio)MainWindow.inicia;
                paraSegundoO = ini;
            }
        }

        private void textB_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow.inicia = this;
        }
    }
}
