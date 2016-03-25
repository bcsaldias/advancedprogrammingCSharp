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
    /// Lógica de interacción para CanonConBarra.xaml
    /// </summary>
    public partial class CanonConBarra : UserControl
    {
        public CanonConBarra()
        {
            InitializeComponent();
        }

        public void Agrandar(int alto, int ancho)
        {
            this.Dispatcher.BeginInvoke(new Action<int, int>(AgrandarDispatcher), alto, ancho);
        }
        private void AgrandarDispatcher(int alto, int ancho)
        {
            try
            {
                this.Height = 65;
                this.Width = alto-110;
                Canvas.SetLeft(this, ancho / 2 - alto / 2 + 21);
                Canvas.SetTop(this, alto - 105);
            }
            catch { }
        }
    }
}
