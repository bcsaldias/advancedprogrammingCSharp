using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using BackEnd;
using System.Windows.Controls;
using System.Net;
using System.Windows.Data;
using System.Collections;
using System.Windows.Documents;
using System.Windows.Input;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Windows.Shapes;

namespace Tarea6
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MW : Window
    {
        Server servidor;
        Jugador jugador;
        string nickName;
        string pathAvatar;

        DispatcherTimer timer;

        public List<string> pathAvatares;
        public static List<BitmapImage> imagenes;

        Thread escucha1;
        Thread escucha2;
        Thread escucha3;
        Thread habla;
        private event Action<int,int> Agranda;
        Tablero tablero;
        Chat chat;
        Instrucciones instrucciones;
        int maxConectados;
        public static CanonConBarra canonConBarra;

        public static DateTime ultimoDisparo;
        public static int delay;

        public MW(int a, string nickName, string PathAvatar, int maxConectados, string ip)
        {
            ultimoDisparo = DateTime.Now;
            delay = 2;//000; // tiempo en milisegundos a esperar
            this.maxConectados = maxConectados;
            this.nickName = nickName;
            pathAvatar = PathAvatar;
   
            if (a == 1)
            {
                InitializeComponent();
                
                pathAvatares = new List<string>();
                imagenes = new List<BitmapImage>();



                servidor = new Server(maxConectados);
                tablero = new Tablero(servidor, null);
                Canvas.SetLeft(tablero, this.Width / 2 - this.Height / 2);
                Canvas.SetTop(tablero, 0);
                canvas.Children.Add(tablero);
                Agranda += tablero.Agrandar;

                canonConBarra = new CanonConBarra();
                Canvas.SetLeft(canonConBarra, this.Width / 2 - this.Height / 2);
                Canvas.SetTop(canonConBarra, tablero.Height);
                canvas.Children.Add(canonConBarra);
                Agranda += canonConBarra.Agrandar;

                pathAvatares.Add(pathAvatar); //

                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(pathAvatar, UriKind.Relative);
                bi3.EndInit();

                imagenes.Add(bi3);
                //

                chat = new Chat(pathAvatar);
                Canvas.SetRight(chat, this.Width / 2 + this.Height / 2);
                Canvas.SetTop(chat, 0);
                canvas.Children.Add(chat);
                Agranda += chat.Agrandar;

                instrucciones = new Instrucciones(maxConectados);
                Canvas.SetLeft(instrucciones, this.Width);
                Canvas.SetTop(instrucciones, 0);
                canvas.Children.Add(instrucciones);
                Agranda += instrucciones.Agrandar;



                escucha1 = new Thread(new ParameterizedThreadStart(oir1));
                escucha2 = new Thread(new ParameterizedThreadStart(oir2));
                escucha3 = new Thread(new ParameterizedThreadStart(oir3));
                habla = new Thread(new ParameterizedThreadStart(hablar));

                escucha1.Start();
                escucha2.Start();
                escucha3.Start();
                habla.Start();

                
            }
            else if (a == 2)
            {

                
                Thread.Sleep(4000);
                jugador = new Jugador(ip);
                InitializeComponent();

                ventana.Title = nickName;
                
                
                tablero = new Tablero(null,jugador);
                Canvas.SetLeft(tablero, this.Width / 2 - this.Height / 2);
                Canvas.SetTop(tablero, 0);
                canvas.Children.Add(tablero);
                Agranda += tablero.Agrandar;

                canonConBarra = new CanonConBarra();
                Canvas.SetLeft(canonConBarra, this.Width / 2 - this.Height / 2);
                Canvas.SetTop(canonConBarra, tablero.Height);
                canvas.Children.Add(canonConBarra);
                Agranda += canonConBarra.Agrandar;

                chat = new Chat(pathAvatar);
                Canvas.SetLeft(chat, this.Width / 2 + this.Height / 2);
                Canvas.SetTop(chat, 0);
                canvas.Children.Add(chat);
                Agranda += chat.Agrandar;

                instrucciones = new Instrucciones(jugador.numeroJugadores);
                Canvas.SetLeft(instrucciones, this.Width);
                Canvas.SetTop(instrucciones, 0);
                canvas.Children.Add(instrucciones);
                Agranda += instrucciones.Agrandar;



                escucha1 = new Thread(new ParameterizedThreadStart(oir0));
                habla = new Thread(new ParameterizedThreadStart(hablar2));

                escucha1.Start();
                habla.Start();

                //BitmapImage bi3 = new BitmapImage();
                //bi3.BeginInit();
                //bi3.UriSource = new Uri(pathAvatar, UriKind.Relative);
                //bi3.EndInit();

                //Jugador.Enviar(jugador.cliente, bi3);
                
            }
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0,1);
            timer.Start();
            canonConBarra.progressBar1.Minimum = 0;
            canonConBarra.progressBar1.Maximum = delay;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (canonConBarra.progressBar1.Value <= delay)
            {
                canonConBarra.progressBar1.Value = DateTime.Now.Second-ultimoDisparo.Second;
            }
        }

        private void ventana_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Agranda != null)
            {
                this.Dispatcher.BeginInvoke(new Action<object, SizeChangedEventArgs>(ventanaDispatcher), sender, e);
            }
        }

        private void ventanaDispatcher(object sender, SizeChangedEventArgs e)
        {
            Agranda((int)e.NewSize.Height, (int)e.NewSize.Width);
        }


        private void oir0(object o)
        {
            //imagenes = (List<BitmapImage>)Jugador.Recibir_Objeto(jugador.cliente);

            //MensajeChat m = 
            string mesage;
            byte[] data;
            int length;
            while (true)
            {
                data = new byte[256];
                length = jugador.socket.Receive(data);
                mesage = Encoding.UTF8.GetString(data, 0, length);
                if (mesage != null&&mesage != "")
                {
                    chat.ReciveMensaje(mesage);
                }


            }
        }
        bool a = true;
        private void oir1(object o)
        {

            string mesage;
            byte[] data;
            int length;
            while (true)
            {
                try
                {
                    data = new byte[256];
                    length = servidor.usuarios[1].Receive(data);
                    byte[] nodata = new byte[length];
   
                    mesage = Encoding.UTF8.GetString(data, 0, length);
                    
                    nodata = Encoding.UTF8.GetBytes("1"+mesage);

                    if (mesage != null && mesage != "")
                    {
                            chat.ReciveMensaje("1"+mesage);
                       try{
                            servidor.usuarios[2].Send(nodata);
                        }catch{}
                       try
                       {
                           servidor.usuarios[3].Send(nodata);
                       }
                       catch { }
                    }
                }catch{
                }
            }
        }
        private void oir2(object o)
        {
            string mesage;
            byte[] data;
            int length;
            while (true)
            {
                try
                {
                    data = new byte[256];
                    length = servidor.usuarios[2].Receive(data);
                    mesage = Encoding.UTF8.GetString(data, 0, length);
                    byte[] nodata = new byte[length];
                    for (int i = 0; i < length; i++)
                    {
                        nodata[i] = data[i];
                    }
                    if (mesage != null && mesage != "")
                    {
                        chat.ReciveMensaje("2"+mesage);
                        nodata = Encoding.UTF8.GetBytes("2" + mesage);
                        try
                        {
                            servidor.usuarios[1].Send(nodata);
                        }
                        catch { }
                        try
                        {
                            servidor.usuarios[3].Send(nodata);
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
        private void oir3(object o)
        {

            string mesage;
            byte[] data;
            int length;
            while (true)
            {
                try
                {
                    data = new byte[256];
                    length = servidor.usuarios[3].Receive(data);
                    mesage = Encoding.UTF8.GetString(data, 0, length);
                    byte[] nodata = new byte[length];
                    for (int i = 0; i < length; i++)
                    {
                        nodata[i] = data[i];
                    }
                    if (mesage != null && mesage != "")
                    {   nodata = Encoding.UTF8.GetBytes("3"+mesage);
                        chat.ReciveMensaje(mesage);
                        try
                        {
                            servidor.usuarios[1].Send(nodata);
                        }
                        catch { }
                        try
                        {
                            servidor.usuarios[2].Send(nodata);
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }

        private void hablar(object o)
        {
            while (true)
            {
                if (chat.aEnviar != null && chat.aEnviar != "")
                {
                    byte[] data2 = Encoding.UTF8.GetBytes("0"+nickName + " : " + chat.aEnviar);

                    if (data2 != null)
                    {
                        if (servidor.uno)
                        {
                            servidor.usuarios[1].Send(data2);
                        }
                        if (servidor.dos)
                        {
                            servidor.usuarios[2].Send(data2);
                        }
                        if (servidor.tres)
                        {
                            servidor.usuarios[3].Send(data2);
                        }
                         chat.aEnviar = null;
                    }
                }
            }
        }

        private void hablar2(object o)
        {
            while (true)
            {
                if (chat.aEnviar != null && chat.aEnviar != "")
                {
                    byte[] data2 = Encoding.UTF8.GetBytes(nickName + " : " + chat.aEnviar);

                    if (data2 != null)
                    {
                        jugador.socket.Send(data2);
                        chat.aEnviar = null;
                    }
                }
            }
        }

        private void ventana_Closed(object sender, EventArgs e)
        {
            if (servidor != null)
            {
                servidor.usuarios[1] = servidor.host;
            }
        }
    }
}
