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
    /// Lógica de interacción para OutputIntermedio.xaml
    /// </summary>
    public partial class OutputIntermedio : UserControl
    {
        public OutputIntermedio()
        {
            InitializeComponent();
        }
        public string paraPrimero;
        ComparadorIgual comparadorIgual;
        ComparadorMenorIgual comparadorMeIgual;
        ComparadorMenor comprMenor;
        ComparadorDistinto compDist;
        ComparadorMayor compMayor;
        ComparadorMayorIgual compMayorIguaL;
        public void a(object sender, RoutedEventArgs e)
        {
            
                if (suma !=null)
                {
                    Suma i = (Suma)suma;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }
                else if (resta != null)
                {
                    Resta i = (Resta)resta;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }
                else if (multiplicacion != null)
                {
                    Multiplicación i = (Multiplicación)multiplicacion;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }
                else if (division != null)
                {
                    División i = (División)division;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }
                else if (seno != null)
                {
                    Seno i = (Seno)seno;
                    paraPrimero = i.textBlock1.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }
                else if (coseno != null)
                {
                    Coseno i = (Coseno)coseno;
                    paraPrimero = i.textBlock1.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;

                }
                else if (factorial != null)
                {
                    Factorial i = (Factorial)factorial;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }
                else if(comparadorIgual !=null){
                    ComparadorIgual i = (ComparadorIgual)comparadorIgual;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }                
                else if(comparadorMeIgual !=null){
                    ComparadorMenorIgual i=(ComparadorMenorIgual)comparadorMeIgual;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }                
                else if(comprMenor !=null){
                    ComparadorMenor  i = (ComparadorMenor)comprMenor;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }                
                else if(compDist !=null){
                    ComparadorDistinto   i = (ComparadorDistinto )compDist;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }                
                else if(compMayor !=null){
                    ComparadorMayor  i = (ComparadorMayor )compMayor;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }
                else if (compMayorIguaL != null)
                {
                    ComparadorMayorIgual i = (ComparadorMayorIgual)compMayorIguaL;
                    paraPrimero = i.textB.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }
                else if (fibo != null)
                {
                    Fibonacci i = (Fibonacci)fibo;
                    paraPrimero = i.textBlock1.Text;
                    textBlock2.Text = paraPrimero;
                    textBox1.Text = paraPrimero;
                }

        }
        Factorial factorial;
        Seno seno;
        Coseno coseno;

        public void b(object sender, RoutedEventArgs e)
        {
            MainWindow.ufu.Children.Remove(this);
        }
        Resta resta;
        Multiplicación multiplicacion;
        Suma suma;
        División division;
        private void textBox1_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
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
                else if (MainWindow.inicia is ComparadorDistinto){
                    compDist = (ComparadorDistinto)MainWindow.inicia;
                }
                else if (MainWindow.inicia is ComparadorIgual ){
                    comparadorIgual = (ComparadorIgual)MainWindow.inicia;
                }
                    
                else if(MainWindow.inicia is ComparadorMayor){
                    compMayor = (ComparadorMayor)MainWindow.inicia;
                }
                else if(MainWindow.inicia is ComparadorMayorIgual){
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

        Fibonacci fibo;

        private void textBlock2_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.inicia = this;
        }
    }
}
