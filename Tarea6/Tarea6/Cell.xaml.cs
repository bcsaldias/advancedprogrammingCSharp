using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea6
{
    /// <summary>
    /// Lógica de interacción para Cell.xaml
    /// </summary>
    public partial class Cell : UserControl
    {
        public CeldasBarcoBackend logica;
        Barco barco;
        public Brush color;
        Brush colorAUX;
        public int posX;
        public int posY;
        Dictionary<int, Brush> dic;

        Dictionary<int, LinearGradientBrush> ataqueAotro;
        Server servidor;
        Jugador jugador;



        private void pintarBarco(Barco b) {
            //this.Dispatcher.BeginInvoke(new Action<Barco>(pintarBarcoDispatcher), b);
            pintarBarcoDispatcher(b);
        }

        private void pintarBarcoDispatcher(Barco b) {

            //lock (b)
            //{
                for (int i = 0; i < b.celdasDelBarco.Length; i++)
                {
                    if (posX == b.celdasDelBarco[i].posX && posY == b.celdasDelBarco[i].posY)
                    {
                            color = dic[b.celdasDelBarco[i].atacado];
                            cambiarColor(color);
                        
                    }
                }
            //}
        }

        public Cell(int i, int j, Barco b, CeldasBarcoBackend logica, Jugador jugador, Server servidor)
        {
            if (servidor != null)
            {
                servidor.p.jugada += cambiarC;
                
                servidor.p.jug += cambiarCo;

                servidor.p.jiji += pintarBarco;
            }

            this.jugador = jugador;
            this.servidor = servidor;
            barco = b;
            dic = new Dictionary<int, Brush>();
            ataqueAotro = new Dictionary<int, LinearGradientBrush>();

            #region
            //rojo
            LinearGradientBrush uno = new LinearGradientBrush();
            uno.EndPoint = new Point(1,0.5);
            uno.StartPoint = new Point(0,0.5);
            uno.GradientStops = new GradientStopCollection(2);
            GradientStop aa = new GradientStop(Colors.Black, 0);
            GradientStop ab = new GradientStop(Colors.Red, 1);
            uno.GradientStops.Add(aa);
            uno.GradientStops.Add(ab);
            
            //violet
            LinearGradientBrush dos = new LinearGradientBrush();
            dos.EndPoint = new Point(1, 0.5);
            dos.StartPoint = new Point(0, 0.5);
            dos.GradientStops = new GradientStopCollection(2);
            GradientStop aaa = new GradientStop(Colors.Black, 0);
            GradientStop aab = new GradientStop(Colors.Green, 1);
            dos.GradientStops.Add(aaa);
            dos.GradientStops.Add(aab);
            

            //pink
            LinearGradientBrush tres = new LinearGradientBrush();
            tres.EndPoint = new Point(1, 0.5);
            tres.StartPoint = new Point(0, 0.5);
            tres.GradientStops = new GradientStopCollection(2);
            GradientStop aaaa = new GradientStop(Colors.Black, 0);
            GradientStop aaab = new GradientStop(Colors.Yellow, 1);
            tres.GradientStops.Add(aaaa);
            tres.GradientStops.Add(aaab);
            
            //coral
            LinearGradientBrush cuatro = new LinearGradientBrush();
            cuatro.EndPoint = new Point(1, 0.5);
            cuatro.StartPoint = new Point(0, 0.5);
            cuatro.GradientStops = new GradientStopCollection(2);
            GradientStop aaaaa = new GradientStop(Colors.Black, 0);
            GradientStop aaaab = new GradientStop(Colors.Coral, 1);
            cuatro.GradientStops.Add(aaaaa);
            cuatro.GradientStops.Add(aaaab);


            ataqueAotro.Add(1, uno);
            ataqueAotro.Add(2, dos);
            ataqueAotro.Add(3, tres);
            ataqueAotro.Add(4, cuatro);

            #endregion


            #region
            dic.Add(1, Brushes.Red);
            dic.Add(2, Brushes.Green);
            dic.Add(3, Brushes.Yellow);
            dic.Add(4, Brushes.Coral);
            dic.Add(11, Brushes.Red);
            dic.Add(12, Brushes.Green);
            dic.Add(13, Brushes.Yellow);
            dic.Add(14, Brushes.Coral);
            #endregion
            this.logica = logica;
            posX = i;
            posY = j;
            InitializeComponent();

            if (logica==null)
            {
                color = Brushes.Transparent;
            }
            else {
                color = Brushes.Gray;//Brushes.BlanchedAlmond; 
                #region
                if (logica.dueño == 1)
                {
                    colorAUX = Brushes.Red;
                }
                else if (logica.dueño == 2)
                {
                    colorAUX = Brushes.Violet;
                }
                else if (logica.dueño == 3)
                {
                    colorAUX = Brushes.Pink;
                }
                else if (logica.dueño == 4)
                {
                    colorAUX = Brushes.Coral;
                }
                #endregion
            }

            cambiarColor(color);
        }

        public void cambiarCo(Jugada j)
        {
            //lock (j)
            //{
                if (posX == j.posX && posY == j.posY)
                {
                    int aux = servidor.p.matrizJuego[posX, posY].atacado;

                    int aux3 = servidor.p.matrizJuego[posX, posY].atacaCeldaBarco(j.dueño);

                            color = dic[servidor.p.matrizJuego[posX, posY].atacado]; //
                            cambiarColor(color);

                }
            //}
        }
        public void cambiarlr(int n)
        {
            int a = n;
                color = dic[n];
                cambiarColor(color);

         }

        private void cambiarCoDispatcher(Brush color)
        {
            cell.Background = (Brush)color;
        }
        public void cambiarC(Jugada j)
        {
            if (posX == j.posX && posY == j.posY)
            {
                color = Brushes.AliceBlue;
                this.Dispatcher.BeginInvoke(new Action<Brush>(cambiarCDispatcher), color);
            }
        }
        private void cambiarCDispatcher(Brush color)
        {
            cell.Background = (Brush)color;
        }
        public void cambiarColor(object cr)
        {
            this.Dispatcher.BeginInvoke(new Action<object>(cambiarColorDispatcher), color);
        }
        private void cambiarColorDispatcher(object color)
        {
            cell.Background = (Brush)color;
        }
        public void cambiarCol(Brush cr)
        {
            this.Dispatcher.BeginInvoke(new Action<Brush>(cambiarColDispatcher), cr);
        }
        private void cambiarColDispatcher(Brush cor)
        {
            cell.Background = (Brush)cor;
        }

        public void revisarCambio(Jugada ju)
        {
            if (ju != null)
                {
                    int[] a = { ju.posX, ju.posY };
                    int aux = logica.atacado;
                    logica.atacaCeldaBarco(ju.dueño);
                    int aux2 = logica.atacado;
                    if (aux != aux2)
                    {
                        color = dic[ju.dueño];
                        cambiarCol(color);
                        cambiarColor("s");
                    }
            }
           
        }
        private void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
           

           if (jugador != null)
           {
               Jugada jugada = new Jugada(posX, posY, jugador.misBarcos[0].celdasDelBarco[0].dueño,-2);
               if (puedeEnviarJugada())
               {
                   Jugador.Enviar(jugador.cliente, jugada);
                   int n = (int)Jugador.Recibir_Objeto(jugador.cliente); // retorna quién lo atacó
                   MW.ultimoDisparo = DateTime.Now;
                   
                   if (n == 0)
                   {
                       color = Brushes.AliceBlue;
                       cambiarC(jugada);
                       if (MW.delay <= 5) // lo maximo que puede esperar es 5 segundos !!
                       {
                           MW.delay += 1;
                       }
                       MW.canonConBarra.progressBar1.Maximum = MW.delay;
                   }
                   else if (n < 10)
                   {   
                       color = ataqueAotro[n];
                       cambiarColor(color);
                       
                       MW.delay = 2;
                       MW.canonConBarra.progressBar1.Maximum = MW.delay;
                   }
                   else if(n>10)
                   {

                           color = dic[n - 10];
                           cambiarColor(color);
                       MW.delay = 2;
                       MW.canonConBarra.progressBar1.Maximum = MW.delay;
                   }
               }
           }
           else if (servidor != null)
           {
               Jugada jugada = new Jugada(posX, posY, 1, -2);
               if (puedeEnviarJugada())
               {
                   MW.ultimoDisparo = DateTime.Now;
                   servidor.jugadasServidor.Add(jugada);
                   Jugada jug = servidor.jugadasServidor.ElementAt(0);
                   int n = servidor.p.revisarJugada(jug); //me avisa quien lo atacó
                   //servidor.p.dpsDeRevisarJugada();
                   if (n != 0 && n < 10)//&& jugada.atacoAntes==-2
                   {
                       //if (this.color == Brushes.Transparent)
                       //{
                       color = ataqueAotro[n];
                       cambiarColor(color);
                       //}
                       MW.delay = 2;
                       MW.canonConBarra.progressBar1.Maximum = MW.delay;
                       servidor.listas.ElementAt(n - 1).Add(jug);

                   }
                   else if (n > 10)
                   {
                           color = dic[n - 10];
                           cambiarColor(color);
                       MW.delay = 2;
                       MW.canonConBarra.progressBar1.Maximum = MW.delay;
                   }
               else
                   {
                       if (MW.delay <= 5) // lo maximo que puede esperar es 5 segundos !! se alenta cuando hay muchos conectadoos
                       {
                           MW.delay += 1;
                       }
                       MW.canonConBarra.progressBar1.Maximum = MW.delay;
                   }
                   servidor.jugadasServidor.Remove(servidor.jugadasServidor.ElementAt(0));
               }
           }
        }

        private bool puedeEnviarJugada()
        {

            if ((DateTime.Now - MW.ultimoDisparo).Seconds >= MW.delay)
            {
               
                return true;
            }
            return false;
            
        }
    }
}
