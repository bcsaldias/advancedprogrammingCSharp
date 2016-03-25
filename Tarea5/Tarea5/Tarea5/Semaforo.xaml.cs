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
using BackEnd;
using System.Threading;
using System.Windows.Shapes;

namespace Tarea5
{
    /// <summary>
    /// Lógica de interacción para Semaforo.xaml
    /// </summary>
    public partial class Semaforo : UserControl
    {
        Thread t1;
        public SemaforoBackEnd logica;
        int posX;
        int posY;

        public Brush color;
        Dictionary<string, Brush> dic;

        public Semaforo(int posX, int posY, SemaforoBackEnd logica)
        {
            InitializeComponent();
            this.logica = logica;
            this.posX = posX;
            this.posY = posY;

            dic = new Dictionary<string, Brush>();
            dic.Add("Rojo", Brushes.Red);
            dic.Add("Verde", Brushes.Green);
            color = dic["Rojo"]; // por mientras

            ContextMenu = new ContextMenu();
            MenuItem Semaforo = new MenuItem();
            MenuItem Semaforo2 = new MenuItem();
            Semaforo.Header = "_Lus Activada Horizontal" + " Roja";
            Semaforo2.Header = "_Lus Activada Vertical" + " Verde";
            ContextMenu.Items.Add(Semaforo);
            ContextMenu.Items.Add(Semaforo2);

        }
        //llamarlo desde un evento
        public void cambiarColor(object col)
        {
            Brush c;
            if (color == Brushes.Red)
            {
                c = dic["Verde"];
                color = Brushes.Green;
            }
            else{
                c = dic["Rojo"];
                color = Brushes.Red;
            }
                
            this.Dispatcher.BeginInvoke(new Action<object>(cambiarColorDispatcher), c);
        }
        private void cambiarColorDispatcher(object cor)
        {
            Background = color;
            ContextMenu = new ContextMenu();
            MenuItem Semaforo = new MenuItem();
            MenuItem Semaforo2 = new MenuItem();
            if (color == Brushes.Red)
            {
                Semaforo.Header = "_Lus Activada Horizontal" + " Roja";
                Semaforo2.Header = "_Lus Activada Vertical" + " Verde";
            }
            else
            {
                Semaforo.Header = "_Lus Activada Horizontal" + " Verde";
                Semaforo2.Header = "_Lus Activada Vertical" + " Roja";
            }
            
            ContextMenu.Items.Add(Semaforo);
            ContextMenu.Items.Add(Semaforo2);
            //logica.time = logica.original;
        }
    }
}
