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
using BackEnd;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea4
{
    /// <summary>
    /// Lógica de interacción para Linea.xaml
    /// </summary>
    public partial class Linea : UserControl
    {
        public LineaBackEnd logica;
        public Linea()
        {
            InitializeComponent();
            logica = new LineaBackEnd();
            
        }

        public void b(object sender, RoutedEventArgs e)
        {
            
            MainWindow.ufu.Children.Remove(this);
            logica.borraTe(MainWindow.ufu);

        }

        public bool CreateALine(Point positi, Point position, int u, Canvas uf/*, Canvas operacion*/)
        {

            return logica.CreateALine(positi, position, u, uf/*, operacion*/);
            //operacion.Children.Add(this);
        }

    }
}
