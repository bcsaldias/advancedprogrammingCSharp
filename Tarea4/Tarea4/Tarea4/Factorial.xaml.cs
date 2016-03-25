﻿using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd;
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
    /// Lógica de interacción para Factorial.xaml
    /// </summary>
    public partial class Factorial : UserControl
    {
        FactorialBackEnd logica;
        public Factorial()
        {
            logica = new FactorialBackEnd();
            InitializeComponent();
            logica.actualizarResultado += new Action<int>(log_actualResultados);
        }
        public void b(object sender, RoutedEventArgs e)
        {

            MainWindow.ufu.Children.Remove(this);

        }

        public void a(object sender, RoutedEventArgs e)
        {
            int num1 = 0;

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

            if (Int32.TryParse(textBox1.Text, out num1))
            {
                logica.calcular(num1);
            }

        }
        OutputIntermedio paraPrimeroO;
        Input paraPrimero;
        Separador pprim;
        void log_actualResultados(int suma)
        {
            textB.Text = "" + suma;
        }

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

        private void textB_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.inicia = this;
        }
    }
}
