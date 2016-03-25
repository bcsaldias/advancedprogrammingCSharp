using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BackEnd;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Shapes;

namespace Tarea5
{
    /// <summary>
    /// Lógica de interacción para Reloj.xaml
    /// </summary>
    public partial class Reloj : UserControl
    {

        DispatcherTimer Relo;
        int minuto = 0;
        int hora = 0;
        int segundo =0;
        public Reloj()
        {
            InitializeComponent();
            Relo = new DispatcherTimer();
            Relo.Interval = new TimeSpan(0, 0, 1);
            Relo.Tick += new EventHandler(dispatcherTimer_Tick);
            Relo.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            label1.Content = segundo;
            label4.Content = minuto;
            label5.Content = hora;

            if (segundo == 59)
            {
                segundo = 0;
            }
            else
            {
                segundo++;
            }
            label1.Content = segundo ;
            if (Convert.ToInt32(label1.Content) % 60 == 0)
            {
                if (minuto == 59)
                {
                    minuto = 0;
                }
                else
                {
                    minuto++;
                }
                label4.Content = minuto;
                if (Convert.ToInt32(label4.Content) % 60 == 0)
                {
                    hora++;
                    label5.Content = hora;
                }
            }
            
            CommandManager.InvalidateRequerySuggested();
        }

    }
}
