using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Text;

namespace BackEnd
{
    public class Server
    {
        public List<Jugada> jugadasServidor;
        public List<Jugada> jugadasUno;
        public List<Jugada> jugadasDos;
        public List<Jugada> jugadasTres;

        public int[,] yaAtacado;

        public bool uno=false;
        public bool dos=false;
        public bool tres=false;
        public Socket[] usuarios;
        public Socket host;
        public Program p;
        IPEndPoint Ep;
        int maxConect;

        public TcpListener servidor;
        public TcpClient[] cliente;

        public TcpListener ServidorParaResponder;
        public static TcpClient[] ClienteQueReciveRespuesta;

        public List<List<Jugada>> listas;
        List<Jugada> intAEnviara0;
        List<Jugada> intAEnviara1;
        List<Jugada> intAEnviara2;
        List<Jugada> intAEnviara3;

        public Server(int maxConect)
        {
            yaAtacado = new int[40, 40];

            listas = new List<List<Jugada>>();
            //nuevo
            intAEnviara0 = new List<Jugada>();
            intAEnviara1 = new List<Jugada>();
            intAEnviara2 = new List<Jugada>();
            intAEnviara3 = new List<Jugada>();
            listas.Add(intAEnviara0);
            listas.Add(intAEnviara1);
            listas.Add(intAEnviara2);
            listas.Add(intAEnviara3);
            //nuevo


            // INDIAR QUE JUGADOR ES CUAAL
            //cerrar threads cuando cierre

            jugadasServidor = new List<Jugada>();
            jugadasUno = new List<Jugada>();
            jugadasDos = new List<Jugada>();
            jugadasTres = new List<Jugada>();


            this.maxConect = maxConect;
            p = new Program(maxConect);
            usuarios = new Socket[maxConect];
        
            Ep = new IPEndPoint(IPAddress.Any, 8000);

            cliente = new TcpClient[maxConect];
            servidor = new TcpListener(IPAddress.Any, 5000);
            servidor.Start();

            ClienteQueReciveRespuesta = new TcpClient[maxConect];
            ServidorParaResponder = new TcpListener(IPAddress.Any, 13000);
            ServidorParaResponder.Start();

            #region
            try
            {
                host = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                host.Bind(Ep);
                host.Listen(maxConect);

                if (maxConect == 2)
                {
                    Thread thread1 = new Thread(new ParameterizedThreadStart(ConnectionProc1));

                    thread1.Start(host);
                }
                if (maxConect == 3)
                {
                    Thread thread1 = new Thread(new ParameterizedThreadStart(ConnectionProc2));

                    thread1.Start(host);
                }
                if (maxConect == 4)
                {
                    Thread thread1 = new Thread(new ParameterizedThreadStart(ConnectionProc3));

                    thread1.Start(host);
                }
            }
            catch { }
            #endregion
        }

        public static void Enviar(TcpClient cliente, object Dato)
        {
            if(cliente!=null){
            NetworkStream netstream = cliente.GetStream();
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(netstream, Dato);
                netstream.Flush();
            }
            catch
            {
            }
            }
        }
        public static Object Recibir_Objeto(TcpClient cliente)
        {
            if (cliente != null)
            {
                NetworkStream netstream = cliente.GetStream();
                object obj = null;

                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    obj = formatter.Deserialize(netstream);

                    return obj;
                }
                catch
                {
                    
                }
            }
            return null;
        }



        private void ConnectionParaRespuesta1() {
            while (true)
            {
                if (listas.ElementAt(0).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(0).ElementAt(0);
                    j1.atacoAntes = p.matrizJuego[j1.posX, j1.posY].atacado;
                    p.juge(j1);
                    listas.ElementAt(0).Remove(listas.ElementAt(0).ElementAt(0));
                }
                 
                if (listas.ElementAt(1).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(1).ElementAt(0);
                    Server.Enviar(ClienteQueReciveRespuesta[1], j1);
                    listas.ElementAt(1).Remove(listas.ElementAt(1).ElementAt(0));
                }
                p.dpsDeRevisarJugada1();
            }
        }
        private void ConnectionParaRespuesta2() {
            while (true)
            {
                if (listas.ElementAt(0).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(0).ElementAt(0);
                    j1.atacoAntes = p.matrizJuego[j1.posX, j1.posY].atacado;
                    p.juge(j1);
                    listas.ElementAt(0).Remove(listas.ElementAt(0).ElementAt(0));
                }
                if (listas.ElementAt(1).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(1).ElementAt(0);
                    Server.Enviar(ClienteQueReciveRespuesta[1], j1);
                    listas.ElementAt(1).Remove(listas.ElementAt(1).ElementAt(0));
                }
                if (listas.ElementAt(2).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(2).ElementAt(0);
                    Server.Enviar(ClienteQueReciveRespuesta[2], j1);
                    listas.ElementAt(2).Remove(listas.ElementAt(2).ElementAt(0));
                }
                p.dpsDeRevisarJugada2();
            }
        }
        private void ConnectionParaRespuesta3() {

            while (true)
            {
                if (listas.ElementAt(0).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(0).ElementAt(0);
                    j1.atacoAntes = p.matrizJuego[j1.posX, j1.posY].atacado;
                    p.juge(j1);
                    listas.ElementAt(0).Remove(listas.ElementAt(0).ElementAt(0));
                }
                if (listas.ElementAt(1).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(1).ElementAt(0);
                    Server.Enviar(ClienteQueReciveRespuesta[1], j1);
                    listas.ElementAt(1).Remove(listas.ElementAt(1).ElementAt(0));
                }
                if (listas.ElementAt(2).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(2).ElementAt(0);
                    Server.Enviar(ClienteQueReciveRespuesta[2], j1);
                    listas.ElementAt(2).Remove(listas.ElementAt(2).ElementAt(0));
                }
                if (listas.ElementAt(3).Count > 0)
                {
                    Jugada j1 = listas.ElementAt(3).ElementAt(0);
                    Server.Enviar(ClienteQueReciveRespuesta[3], j1);
                    listas.ElementAt(3).Remove(listas.ElementAt(3).ElementAt(0));
                }
                p.dpsDeRevisarJugada3();
            }
        }
        
        private void Connection1() {
            while (true)
            {
                if (cliente[1].Available > 0)
                {
                    try
                    {
                        Jugada j1 = j1 = (Jugada)Recibir_Objeto(cliente[1]);
                        if (j1 != null)
                        {
                            //j1.atacoAntes = p.matrizJuego[j1.posX, j1.posY].atacado;
                            jugadasUno.Add(j1);
                            Server.Enviar(cliente[1], p.revisarJugada2(j1));
                            int j = p.matrizJuego[j1.posX, j1.posY].dueño;
                            if (p.matrizJuego[j1.posX, j1.posY].atacado < 0)
                            {
                                p.matrizJuego[j1.posX, j1.posY].atacado = j1.dueño + 10;
                            }

                            listas.ElementAt(j - 1).Add(j1); // prueba
                            jugadasUno.Remove(jugadasUno.ElementAt(0));

                        }
                    }
                    catch { }
                }
                recibirBarcoMuerto1();
            }
        }
        private void Connection2(object ob) {

            while (true)
            {
                if (cliente[1].Available > 0)
                {
                    try
                    {
                        Jugada j1 = j1 = (Jugada)Recibir_Objeto(cliente[1]);
                        if (j1 != null)
                        {
                            jugadasUno.Add(j1);
                            Server.Enviar(cliente[1], p.revisarJugada2(j1));
                            int j = p.matrizJuego[j1.posX, j1.posY].dueño;
                            if (p.matrizJuego[j1.posX, j1.posY].atacado < 0)
                            {
                                p.matrizJuego[j1.posX, j1.posY].atacado = j1.dueño + 10;
                            }

                            listas.ElementAt(j - 1).Add(j1); // prueba
                            jugadasUno.Remove(jugadasUno.ElementAt(0));

                        }
                    }
                    catch { }
                }
                if (cliente[2].Available > 0)
                {
                    try
                    {
                        Jugada j1 = j1 = (Jugada)Recibir_Objeto(cliente[2]);
                        if (j1 != null)
                        {
                            jugadasUno.Add(j1);
                            Server.Enviar(cliente[2], p.revisarJugada2(j1));
                            int j = p.matrizJuego[j1.posX, j1.posY].dueño;
                            if (p.matrizJuego[j1.posX, j1.posY].atacado < 0)
                            {
                                p.matrizJuego[j1.posX, j1.posY].atacado = j1.dueño + 10;
                            }

                            listas.ElementAt(j - 1).Add(j1); // prueba
                            jugadasUno.Remove(jugadasUno.ElementAt(0));

                        }
                    }
                    catch { }
                }
                recibirBarcoMuerto2();
            }

        }
        private void Connection3(object ob) {
         
            while (true)
            {
                if (cliente[1].Available > 0)
                {
                    try
                    {
                        Jugada j1 = j1 = (Jugada)Recibir_Objeto(cliente[1]);
                        if (j1 != null)
                        {
                            jugadasUno.Add(j1);
                            Server.Enviar(cliente[1], p.revisarJugada2(j1));
                            int j = p.matrizJuego[j1.posX, j1.posY].dueño;
                            if (p.matrizJuego[j1.posX, j1.posY].atacado < 0)
                            {
                                p.matrizJuego[j1.posX, j1.posY].atacado = j1.dueño + 10;
                            }

                            listas.ElementAt(j - 1).Add(j1); // prueba
                            jugadasUno.Remove(jugadasUno.ElementAt(0));

                        }
                    }
                    catch { }
                }
                if (cliente[2].Available > 0)
                {
                    try
                    {
                        Jugada j1 = j1 = (Jugada)Recibir_Objeto(cliente[2]);
                        if (j1 != null)
                        {
                            jugadasUno.Add(j1);
                            Server.Enviar(cliente[2], p.revisarJugada2(j1));
                            int j = p.matrizJuego[j1.posX, j1.posY].dueño;
                            if (p.matrizJuego[j1.posX, j1.posY].atacado < 0)
                            {
                                p.matrizJuego[j1.posX, j1.posY].atacado = j1.dueño + 10;
                            }

                            listas.ElementAt(j - 1).Add(j1); // prueba
                            jugadasUno.Remove(jugadasUno.ElementAt(0));

                        }
                    }
                    catch { }
                }
                if (cliente[3].Available > 0)
                {
                    try
                    {
                        Jugada j1 = j1 = (Jugada)Recibir_Objeto(cliente[3]);
                        if (j1 != null)
                        {
                            jugadasUno.Add(j1);
                            Server.Enviar(cliente[3], p.revisarJugada2(j1));
                            int j = p.matrizJuego[j1.posX, j1.posY].dueño;
                            if (p.matrizJuego[j1.posX, j1.posY].atacado < 0)
                            {
                                p.matrizJuego[j1.posX, j1.posY].atacado = j1.dueño + 10;
                            }
                            listas.ElementAt(j - 1).Add(j1); // prueba
                            jugadasUno.Remove(jugadasUno.ElementAt(0));

                        }
                    }
                    catch { }
                }
                recibirBarcoMuerto3();
            }
        }

        public void recibirBarcoMuerto1()
        {
            //while (true)
            //{
                if (ClienteQueReciveRespuesta[1].Available > 0)
                {
                    try
                    {

                        Barco b = (Barco)Server.Recibir_Objeto(ClienteQueReciveRespuesta[1]);
                        if (b != null && b is Barco)
                        {
                            p.barcosExtra.Add(b);
                        }
                    }

                    catch { }
                }
            //}
        }
        public void recibirBarcoMuerto2()
        {
            //while (true)
            //{
                if (ClienteQueReciveRespuesta[1].Available > 0)
                {
                    try
                    {

                        Barco b = (Barco)Server.Recibir_Objeto(ClienteQueReciveRespuesta[1]);
                        if (b != null && b is Barco)
                        {
                            p.barcosExtra.Add(b);
                        }
                    }

                    catch { }
                }
                if (ClienteQueReciveRespuesta[2].Available > 0)
                {
                    try
                    {

                        Barco b = (Barco)Server.Recibir_Objeto(ClienteQueReciveRespuesta[2]);
                        if (b != null && b is Barco)
                        {
                            p.barcosExtra.Add(b);
                        }
                    }

                    catch { }
                }
           // }
        }
        public void recibirBarcoMuerto3()
        {
            //while (true)
            //{
                if (ClienteQueReciveRespuesta[1].Available > 0)
                {
                    try
                    {

                        Barco b = (Barco)Server.Recibir_Objeto(ClienteQueReciveRespuesta[1]);
                        if (b != null && b is Barco)
                        {
                            p.barcosExtra.Add(b);
                        }
                    }

                    catch { }
                }
                if (ClienteQueReciveRespuesta[2].Available > 0)
                {
                    try
                    {

                        Barco b = (Barco)Server.Recibir_Objeto(ClienteQueReciveRespuesta[2]);
                        if (b != null && b is Barco)
                        {
                            p.barcosExtra.Add(b);
                        }
                    }

                    catch { }
                }
                if (ClienteQueReciveRespuesta[3].Available > 0)
                {
                    try
                    {

                        Barco b = (Barco)Server.Recibir_Objeto(ClienteQueReciveRespuesta[3]);
                        if (b != null && b is Barco)
                        {
                            p.barcosExtra.Add(b);
                        }
                    }

                    catch { }
                }
            //}
        }

        private void ConnectionProc3(object ob)
        {
                    usuarios[1] = host.Accept();
                    cliente[1] = servidor.AcceptTcpClient();
                    Enviar(cliente[1], p.dos);
                    Enviar(cliente[1], 4);
                    uno = true;

                    usuarios[2] = host.Accept();
                    cliente[2] = servidor.AcceptTcpClient();
                    Enviar(cliente[2], p.tres);
                    Enviar(cliente[2], 4);
                    dos = true;

                    usuarios[3] = host.Accept();
                    cliente[3] = servidor.AcceptTcpClient();
                    Enviar(cliente[3], p.cuatro);
                    Enviar(cliente[3], 4);
                    tres = true;

                    ClienteQueReciveRespuesta[1] = ServidorParaResponder.AcceptTcpClient();
                    ClienteQueReciveRespuesta[2] = ServidorParaResponder.AcceptTcpClient();
                    ClienteQueReciveRespuesta[3] = ServidorParaResponder.AcceptTcpClient();

                    Thread thread2 = new Thread(new ParameterizedThreadStart(Connection3));
                    Thread t = new Thread(new ThreadStart(ConnectionParaRespuesta3));
                    //Thread u = new Thread(new ThreadStart(recibirBarcoMuerto3));
                    //u.Start();
                    t.Start();
                    thread2.Start();


        }
        private void ConnectionProc2(object ob)
        {
            usuarios[1] = host.Accept();
            cliente[1] = servidor.AcceptTcpClient();
            Enviar(cliente[1], p.dos);
            Enviar(cliente[1], 3);
            uno = true;

            usuarios[2] = host.Accept();
            cliente[2] = servidor.AcceptTcpClient();
            Enviar(cliente[2], p.tres);
            Enviar(cliente[2], 3);
            dos = true;

            ClienteQueReciveRespuesta[1] = ServidorParaResponder.AcceptTcpClient();
            ClienteQueReciveRespuesta[2] = ServidorParaResponder.AcceptTcpClient();

            Thread thread2 = new Thread(new ParameterizedThreadStart(Connection2));
            Thread t = new Thread(new ThreadStart(ConnectionParaRespuesta2));
            //Thread u = new Thread(new ThreadStart(recibirBarcoMuerto2));
            //u.Start();
            t.Start();
            thread2.Start();
        }
        private void ConnectionProc1(object ob)
        {
            usuarios[1] = host.Accept();
            cliente[1] = servidor.AcceptTcpClient();
            Enviar(cliente[1], p.dos);
            Enviar(cliente[1], 2);

            ClienteQueReciveRespuesta[1] = ServidorParaResponder.AcceptTcpClient();//nuevo

            uno = true;
            Thread thread2 = new Thread(new ThreadStart(Connection1));

            Thread t = new Thread(new ThreadStart(ConnectionParaRespuesta1));//nuevo
            //Thread u = new Thread(new ThreadStart(recibirBarcoMuerto1));
            //u.Start();
            thread2.Start();
            t.Start();//nuevo
        }




    }
}
