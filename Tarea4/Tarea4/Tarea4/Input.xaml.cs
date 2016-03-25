using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd;
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
    /// Lógica de interacción para Input.xaml
    /// </summary>
    public partial class Input : UserControl
    {
        InputBackEnd logica;
        public Input()
        {
            logica = new InputBackEnd();
            InitializeComponent();
            logica.actualizarResultado += new Action<double>(log_actualResultados);

        }
        void log_actualResultados(double suma)
        {
            prim.Text = "" + suma;
        }
        public void b(object sender, RoutedEventArgs e)
        {
            MainWindow.ufu.Children.Remove(this);
        }
        
        public void a(object sender, RoutedEventArgs e)
        {
            double num1 = 0;

            if (Double.TryParse(prim.Text, out num1))
            {
                            
                logica.numero(num1);
            }

        }

        private void UserControl_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.inicia = this;
        }

    }
}
