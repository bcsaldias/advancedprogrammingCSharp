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
    /// Lógica de interacción para Chat.xaml
    /// </summary>
    public partial class Chat : UserControl
    {
        public StackPanel ad;
        public string aEnviar;
        public string pathAvatar;
        public Chat(string pathAvatar)
        {
            this.pathAvatar = pathAvatar;
            ad = new StackPanel();
            InitializeComponent();
        }

        public void ReciveMensaje(string mensaje)
        {
            this.Dispatcher.BeginInvoke(new Action<string>(ReciveMensajeDispatcher),mensaje);
        }
        private void ReciveMensajeDispatcher(string mensaje)
        {
            MensajeChat men = new MensajeChat(mensaje);
            scrollViewer1.Content = ad;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(pathAvatar, UriKind.Relative);
            bi3.EndInit();
            men.image1.Stretch = Stretch.Fill;
            try
            {
                men.image1.Source = BitmapFrame.Create(bi3);
            }
            catch { }
            ad.Children.Add(men);
            textBox1.Text = null;
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
                scrollViewer1.Height = alto - 250;
                scrollViewer1.Width = (ancho - (alto - 40)) / 2;
                Canvas.SetLeft(this, 0/*ancho / 2 - alto / 2 + alto-40 +1*/);
                textBox1.Margin = new Thickness(0, scrollViewer1.Height - 100, 0, 0);
                textBox1.Width = (ancho - (alto - 40)) / 2 - 50;
                textBox1.Height = 50;
                button1.Margin = new Thickness(-60, scrollViewer1.Height - 100, 0, 0);
                
            }
            catch { }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            aEnviar = textBox1.Text;
            MensajeChat men = new MensajeChat(aEnviar);
            scrollViewer1.Content = ad;
            ad.Children.Add(men);
            textBox1.Text = null;
        }
    }
}
