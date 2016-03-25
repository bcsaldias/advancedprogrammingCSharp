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
using System.Windows.Shapes;

namespace Tarea4
{
    /// <summary>
    /// Lógica de interacción para Plotter.xaml
    /// </summary>
    public partial class Gráfico : Window
    {
        double[,] listaDePuntos;
        Plotter plot;
        public Gráfico(Plotter plot)
        {
            InitializeComponent();
            MainWindow.cerrarTodo += new Action(this.Close);
            this.plot = plot;
            listaDePuntos = plot.logica.graficar();
            dibujar();
        }

        void dibujar()
        {
            double separacion = this.Width/listaDePuntos.Length;
            titulo.Text = plot.logica.toPlot;
            for (int i = 0; i < listaDePuntos.GetLength(1); i++)
            {
                if ((titulo.Text == "fibonacci" || titulo.Text == "factorial") && listaDePuntos[0, i] < 0)
                {
                }
                else{
                    Linea a = new Linea();
                    Canvas.SetLeft(a, 247 + 10 * listaDePuntos[0, i]);
                    Canvas.SetTop(a, 247 - 10 * listaDePuntos[1, i]);
                    yiju.Children.Add(a);
                }
            }


            this.Show();
        }

        


    }
}
