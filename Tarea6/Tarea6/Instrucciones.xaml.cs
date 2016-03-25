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

namespace Tarea6
{
    /// <summary>
    /// Lógica de interacción para Instrucciones.xaml
    /// </summary>
    public partial class Instrucciones : UserControl
    {
        public int numeroJugadores;
        public Instrucciones(int numeroJugadores)
        {
            this.numeroJugadores = numeroJugadores;
            
            InitializeComponent();
            agregarCosas();
        }

        public void agregarCosas()
        {
            if (numeroJugadores == 1)
            {
#region
                rectangle1.Visibility = Visibility.Visible;
                rectangle2.Visibility = Visibility.Collapsed;
                rectangle3.Visibility = Visibility.Collapsed;
                rectangle4.Visibility = Visibility.Collapsed;
                rectangle5.Visibility = Visibility.Visible;
                rectangle6.Visibility = Visibility.Collapsed;
                rectangle7.Visibility = Visibility.Collapsed;
                rectangle8.Visibility = Visibility.Collapsed;

                label1.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Collapsed;
                label3.Visibility = Visibility.Collapsed;
                label4.Visibility = Visibility.Collapsed;
                label5.Visibility = Visibility.Visible;
                label6.Visibility = Visibility.Collapsed;
                label7.Visibility = Visibility.Collapsed;
                label8.Visibility = Visibility.Collapsed;
#endregion
            }
            else if (numeroJugadores == 2)
            {
                #region
                rectangle1.Visibility = Visibility.Visible;
                rectangle2.Visibility = Visibility.Visible;
                rectangle3.Visibility = Visibility.Collapsed;
                rectangle4.Visibility = Visibility.Collapsed;
                rectangle5.Visibility = Visibility.Visible;
                rectangle6.Visibility = Visibility.Visible;
                rectangle7.Visibility = Visibility.Collapsed;
                rectangle8.Visibility = Visibility.Collapsed;

                label1.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Visible;
                label3.Visibility = Visibility.Collapsed;
                label4.Visibility = Visibility.Collapsed;
                label5.Visibility = Visibility.Visible;
                label6.Visibility = Visibility.Visible;
                label7.Visibility = Visibility.Collapsed;
                label8.Visibility = Visibility.Collapsed;
                #endregion
            }
            else if (numeroJugadores == 3)
            {
                #region
                rectangle1.Visibility = Visibility.Visible;
                rectangle2.Visibility = Visibility.Visible;
                rectangle3.Visibility = Visibility.Visible;
                rectangle4.Visibility = Visibility.Collapsed;
                rectangle5.Visibility = Visibility.Visible;
                rectangle6.Visibility = Visibility.Visible;
                rectangle7.Visibility = Visibility.Visible;
                rectangle8.Visibility = Visibility.Collapsed;

                label1.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Visible;
                label3.Visibility = Visibility.Visible;
                label4.Visibility = Visibility.Collapsed;
                label5.Visibility = Visibility.Visible;
                label6.Visibility = Visibility.Visible;
                label7.Visibility = Visibility.Visible;
                label8.Visibility = Visibility.Collapsed;
                #endregion
            }
            else if (numeroJugadores == 4)
            {
                #region
                rectangle1.Visibility = Visibility.Visible;
                rectangle2.Visibility = Visibility.Visible;
                rectangle3.Visibility = Visibility.Visible;
                rectangle4.Visibility = Visibility.Visible;
                rectangle5.Visibility = Visibility.Visible;
                rectangle6.Visibility = Visibility.Visible;
                rectangle7.Visibility = Visibility.Visible;
                rectangle8.Visibility = Visibility.Visible;

                label1.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Visible;
                label3.Visibility = Visibility.Visible;
                label4.Visibility = Visibility.Visible;
                label5.Visibility = Visibility.Visible;
                label6.Visibility = Visibility.Visible;
                label7.Visibility = Visibility.Visible;
                label8.Visibility = Visibility.Visible;
                #endregion
            }
        }

        public void Agrandar(int alto, int ancho)
        {
            this.Dispatcher.BeginInvoke(new Action<int, int>(AgrandarDispatcher), alto, ancho);
        }
        private void AgrandarDispatcher(int alto, int ancho)
        {
            try
            {
                this.Height = alto - 40;
                this.Width = (ancho - (alto - 40)) / 2;
                Canvas.SetLeft(this, ancho / 2 - alto / 2 + 21 + alto-80);  
            }
            catch { }
        }
    }
}
