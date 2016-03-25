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
using System.Windows.Shapes;

namespace Tarea4
{
    /// <summary>
    /// Lógica de interacción para OutputFinal.xaml
    /// </summary>
    public partial class OutputFinal : UserControl
    {
        public OutputFinal()
        {
            InitializeComponent();
        }
        public Input paraPrimero;

        public void a(object sender, RoutedEventArgs e)
        {

            if (suma != null)
            {
                Suma i = (Suma)suma;
                //paraPrimero.prim.Text = i.textB.Text;
                textBlock1.Text = i.textB.Text;
            }
            else if (resta != null)
            {
                Resta i = (Resta)resta;
                //paraPrimero.prim.Text = i.textB.Text;
                textBlock1.Text = i.textB.Text;
            }
            else if (multiplicacion != null)
            {
                Multiplicación i = (Multiplicación)multiplicacion;
                //paraPrimero.prim.Text = i.textB.Text;
                textBlock1.Text = i.textB.Text;
            }
            else if (division != null)
            {
                División i = (División)division;
                textBlock1.Text = i.textB.Text;
            }
            else if (seno != null)
            {
                Seno i = (Seno)seno;
                textBlock1.Text = i.textBlock1.Text;
            }
            else if (coseno != null)
            {
                Coseno i = (Coseno)coseno;
                textBlock1.Text = i.textBlock1.Text;

            }
            else if (factorial != null)
            {
                Factorial i = (Factorial)factorial;
                textBlock1.Text = i.textB.Text;
            }
            else if (comparadorIgual != null)
            {
                ComparadorIgual i = (ComparadorIgual)comparadorIgual;
                textBlock1.Text = i.textB.Text;
            }
            else if (comparadorMeIgual != null)
            {
                ComparadorMenorIgual i = (ComparadorMenorIgual)comparadorMeIgual;
                textBlock1.Text = i.textB.Text;
            }
            else if (comprMenor != null)
            {
                ComparadorMenor i = (ComparadorMenor)comprMenor;
                textBlock1.Text = i.textB.Text;
            }
            else if (compDist != null)
            {
                ComparadorDistinto i = (ComparadorDistinto)compDist;
                textBlock1.Text = i.textB.Text;
            }
            else if (compMayor != null)
            {
                ComparadorMayor i = (ComparadorMayor)compMayor;
                textBlock1.Text = i.textB.Text;
            }
            else if (compMayorIguaL != null)
            {
                ComparadorMayorIgual i = (ComparadorMayorIgual)compMayorIguaL;
                textBlock1.Text = i.textB.Text;
            }
            else if (fibo != null)
            {
                Fibonacci i = (Fibonacci)fibo;
                textBlock1.Text = i.textBlock1.Text;
            }

        }
        Fibonacci fibo;
        Factorial factorial;
        Coseno coseno;
        ComparadorIgual comparadorIgual;
        ComparadorMenorIgual comparadorMeIgual;
        ComparadorMenor comprMenor;
        ComparadorDistinto compDist;
        ComparadorMayor compMayor;
        ComparadorMayorIgual compMayorIguaL;
        Seno seno;
        public void b(object sender, RoutedEventArgs e)
        {
            MainWindow.ufu.Children.Remove(this);
        }
        Resta resta;
        Multiplicación multiplicacion;
        Suma suma;
        División division;

        private void textBlock1_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.inicia != null)
            {
                MainWindow.finaliza = this;

                if (MainWindow.inicia is Suma)
                {
                    suma = (Suma)MainWindow.inicia;
                }
                else if (MainWindow.inicia is Resta)
                {
                    resta = (Resta)MainWindow.inicia;
                }
                else if (MainWindow.inicia is Multiplicación)
                {
                    multiplicacion = (Multiplicación)MainWindow.inicia;
                }
                else if (MainWindow.inicia is División)
                {

                    division = (División)MainWindow.inicia;
                }
                else if (MainWindow.inicia is Factorial)
                {
                    factorial = (Factorial)MainWindow.inicia;
                }
                else if (MainWindow.inicia is Seno)
                {
                    seno = (Seno)MainWindow.inicia;
                }
                else if (MainWindow.inicia is Coseno)
                {
                    coseno = (Coseno)MainWindow.inicia;
                }
                else if (MainWindow.inicia is ComparadorDistinto)
                {
                    compDist = (ComparadorDistinto)MainWindow.inicia;
                }
                else if (MainWindow.inicia is ComparadorIgual)
                {
                    comparadorIgual = (ComparadorIgual)MainWindow.inicia;
                }

                else if (MainWindow.inicia is ComparadorMayor)
                {
                    compMayor = (ComparadorMayor)MainWindow.inicia;
                }
                else if (MainWindow.inicia is ComparadorMayorIgual)
                {
                    compMayorIguaL = (ComparadorMayorIgual)MainWindow.inicia;
                }
                else if (MainWindow.inicia is ComparadorMenor)
                {
                    comprMenor = (ComparadorMenor)MainWindow.inicia;
                }
                else if (MainWindow.inicia is ComparadorMenorIgual)
                {
                    comparadorMeIgual = (ComparadorMenorIgual)MainWindow.inicia;
                }
                else if (MainWindow.inicia is Fibonacci)
                {
                    fibo = (Fibonacci)MainWindow.inicia;
                }

            }
        }

    }
}
