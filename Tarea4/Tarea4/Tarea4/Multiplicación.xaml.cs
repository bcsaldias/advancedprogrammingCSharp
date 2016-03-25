using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BackEnd;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea4
{
    /// <summary>
    /// Lógica de interacción para Multiplicación.xaml
    /// </summary>
    public partial class Multiplicación : UserControl
    {
        public Input paraPrimero;
        public Input paraSegundo;
        public OutputIntermedio output;
        public OutputFinal outFinal;
        
        MultiplicacionBackEnd logica;
        public Multiplicación()
        {
            InitializeComponent();
            logica = new MultiplicacionBackEnd();
            logica.actualizarResultado += new Action<double>(log_actualResultados);
            
        }

        public void a(object sender , RoutedEventArgs e)
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
            if (pprim != null)
            {
                prim.Text = pprim.textBlock1.Text;
            }
            if (pseg != null)
            {
                seg.Text = pprim.textBlock1.Text;
            }
            if (Double.TryParse(prim.Text, out num1) && Double.TryParse(seg.Text, out num2))
            {
                logica.multiplicar(num1, num2);
            }

        }
        public void b(object sender, RoutedEventArgs e)
        {
            MainWindow.ufu.Children.Remove(this);
        }
        void log_actualResultados(double multiplicacion)
        {
            textB.Text = "" + multiplicacion;
        }
        OutputIntermedio paraPrimeroO;
        OutputIntermedio paraSegundoO;

        Separador pprim;
        Separador pseg;

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
            else if (MainWindow.inicia is Separador)
            {
                Separador ini = (Separador)MainWindow.inicia;
                pprim = ini;

            }
        }

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
            else if (MainWindow.inicia is Separador)
            {
                Separador ini = (Separador)MainWindow.inicia;
                pseg = ini;

            }
        }

        private void textB_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            MainWindow.inicia = this;
        }

    }

}
