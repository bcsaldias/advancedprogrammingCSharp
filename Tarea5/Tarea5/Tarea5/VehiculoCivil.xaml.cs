using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using BackEnd;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea5
{
    /// <summary>
    /// Lógica de interacción para VehiculoCivil.xaml
    /// </summary>
    public partial class VehiculoCivil : UserControl
    {
        Thread t1;
        VehiculoBackEnd logica;
        int posX;
        int posY;
        public VehiculoCivil(int i, int j, VehiculoBackEnd logica)
        {
            InitializeComponent();
            this.logica = logica;
            posX = i;
            posY = j;
            t1 = new Thread(new ParameterizedThreadStart(andar));
            t1.Start(this);
        }

        private void andar(object pos)
        {
            while (true)
            {
                this.Dispatcher.BeginInvoke(new Action<object>(andarDispatcher), pos);
                Thread.Sleep(400);
            }
        }
        private void andarDispatcher(object pos)
        {
                
                Grid.SetColumn(this, logica.andarX());
                Grid.SetRow(this, logica.andarY());
                
        }

    }
}
