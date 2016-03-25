using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using BackEnd;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Threading;
using System.Windows.Shapes;

namespace Tarea5
{
    /// <summary>
    /// Lógica de interacción para Cell.xaml
    /// </summary>
    public partial class Cell : UserControl
    {
        public Celdas logica;
        public Brush color;
        Thread t1;
        public int timeEscape;
        public int posX;
        public int posY;
        Dictionary<string, Brush> dic;
        public Cell(int i, int j, Material mat, Celdas logica)
        {
            InitializeComponent();
            this.logica = logica;
            dic = new Dictionary<string, Brush>();
            dic.Add("Acero",Brushes.LightSlateGray);
            dic.Add("Cemento",Brushes.Gray);
            dic.Add("Ladrillo",Brushes.OrangeRed);
            dic.Add("Madera",Brushes.Chocolate);
            dic.Add("Piedra",Brushes.Black);
            dic.Add("Special",Brushes.Goldenrod);
            posX = i;
            posY = j;
            timeEscape = 0;

            color = dic[mat.nombreMaterial];
            cambiarColor(color);

            //t1= new Thread(new ParameterizedThreadStart(ver));
            //t1.Start();
            
        }

        //private void ver(object o)
        //{
        //    MainWindow.ejecutarAccidente(this);
        //}
        ManualResetEvent mr = new ManualResetEvent(false);

        //public static Image FromFile(string filename,bool useEmbeddedColorManagement);

        public void verAccidente(object ob)
        {
            this.Dispatcher.BeginInvoke(new Action<object>(verAccidenteDispatcher), ob);
        }
        private void verAccidenteDispatcher(object color)
        {
            lock (this)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@".\..\..\accidente.PNG", UriKind.Relative);
                bi3.EndInit();
                image1.Stretch = Stretch.Fill;
                image1.Source = BitmapFrame.Create(bi3);
                //MessageBox.Show("accidente");
            }
        }

        //public void actualizarMenu(object o)
        //{
        //    this.Dispatcher.BeginInvoke(new Action<object>(actualizarMenuDispatcher), o);
        //}
        //private void actualizarMenuDispatcher(object o)
        //{
        //    Asalto asal = (Asalto)o;
        //    MenuItem tiempoDeEscape = new MenuItem();
        //    tiempoDeEscape.Header = "_Tiempo escape " + asal.numero ;
        //    this.ContextMenu.Items.Add(tiempoDeEscape);
        //}

        public void verAsalto(object ob)
        {
            this.Dispatcher.BeginInvoke(new Action<object>(verAsaltoDispatcher), ob);
        }
        private void verAsaltoDispatcher(object color)
        {
            lock (this)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@".\..\..\pistola.PNG", UriKind.Relative);
                bi3.EndInit();
                image1.Stretch = Stretch.Fill;
                image1.Source = BitmapFrame.Create(bi3);
                //MessageBox.Show("pistol");
                //MenuItem tiempoDeEscape = new MenuItem();
                //tiempoDeEscape.Header = "_Tiempo escape " + timeEscape;
                //this.ContextMenu.Items.Add(tiempoDeEscape);
            }
        }
        public void verEnfermedad(object ob)
        {
            this.Dispatcher.BeginInvoke(new Action<object>(verEnfermedadDispatcher), ob);
        }
        private void verEnfermedadDispatcher(object color)
        {
            lock (this)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@".\..\..\enfermo.PNG", UriKind.Relative);
                bi3.EndInit();
                image1.Stretch = Stretch.Fill;
                image1.Source = BitmapFrame.Create(bi3);
                //MessageBox.Show("enfermo");
            }
        }

        public void verIncendio(object ob)
        {
            this.Dispatcher.BeginInvoke(new Action<object>(verIncendioDispatcher), ob);
        }
        private void verIncendioDispatcher(object color)
        {
            lock (this)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@".\..\..\fuego.PNG", UriKind.Relative);
                bi3.EndInit();
                image1.Stretch = Stretch.Fill;
                image1.Source = BitmapFrame.Create(bi3);
                //MessageBox.Show("incendio");
            }
        }

        public void cambiarColor(object color)
        {
            this.Dispatcher.BeginInvoke(new Action<object>(cambiarColorDispatcher), color);
        }
        private void cambiarColorDispatcher(object color)
        {
            cell.Background = (Brush)color;
        }

        public void sacarImagen(object ob)
        {
            this.Dispatcher.BeginInvoke(new Action<object>(sacarImagenDispatcher), ob);
        }
        private void sacarImagenDispatcher(object color)
        {
            lock (this)
            {
                image1.Source = null;
                //MessageBox.Show("saque imagen");
            }
        }


        private void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
