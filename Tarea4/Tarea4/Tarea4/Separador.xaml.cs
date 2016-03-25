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
    /// Lógica de interacción para Separador.xaml
    /// </summary>
    public partial class Separador : UserControl
    {
        SeparadorBackEnd logica;
        public Separador()
        {
            InitializeComponent();
            logica = new SeparadorBackEnd();
        }

        public void b(object sender, RoutedEventArgs e)
        {
            MainWindow.ufu.Children.Remove(this);
        }
        OutputIntermedio paraPrimeroO;
        Input paraPrimero;
        Separador pprim;
        public void a(object sender, RoutedEventArgs e)
        {
            double num1 = 0;

            if (paraPrimero != null)
            {
                textBlock1.Text = paraPrimero.prim.Text;
            }
            if (paraPrimeroO != null)
            {
                textBlock1.Text = paraPrimeroO.textBlock2.Text;
            }
            if (pprim != null)
            {
                textBlock1.Text = pprim.textBlock1.Text;
            }



            if (Double.TryParse(textBlock1.Text, out num1))
            {
                            
                logica.numero(num1);
            }

        }

 

        

        private void label1_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
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

        private void label2_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.inicia = this;
        }

        private void Ellipse_PreviewMouseRightButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow.inicia = this;
        }

        private void Ellipse_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
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
        

    }
}
