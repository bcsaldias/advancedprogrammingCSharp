using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace BackEnd
{
    public class Jugador
    {
        public Socket socket;
        public Barco[] misBarcos;
        Server servidor;
        public int[,] yaAtacado;
        public Socket socketServidor;

        public List<int> listaDeRespuestas;

        public int numeroJugadores;
        public TcpClient cliente;
        public TcpClient clienteRespueta;

        public List<Jugada> jugadaRecivida;
        public List<Barco> barcoRecivido;

        public Jugador(string respuesta)
        {
            barcosMuertos = new List<Barco>();
            yaAtacado = new int[40, 40];
            barcoRecivido = new List<Barco>();
            jugadaRecivida = new List<Jugada>();
            listaDeRespuestas = new List<int>();
            IPAddress direc ;//= IPAddress.Loopback;

            //string respuesta = "127.0.0.1";
            if (IPAddress.TryParse(respuesta, out direc)) // a = texbox  1. text mcd ipconfig 127.0.0.1
            {
            }
            else
            {
                direc = IPAddress.Parse("127.0.0.1"); // solo para q no se caiga
            }
                IPEndPoint Ep = new IPEndPoint(direc, 8000);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
                cliente = new TcpClient();
                clienteRespueta = new TcpClient();
                try
                {
                    socket.Connect(Ep);
                    cliente.Connect(direc, 5000);
                    //nuevo
                    clienteRespueta.Connect(direc, 13000);
                    //nuevo
                    misBarcos = (Barco[])Recibir_Objeto(cliente);
                    numeroJugadores = (int)Recibir_Objeto(cliente);
                }
                catch
                {
                }

                Thread thread1 = new Thread(new ParameterizedThreadStart(ConnectionProc));

                thread1.Start();

            
        }


        private void ConnectionProc(object ob)
        {
            while (true)
            {
                try
                {
                    object aux = Recibir_Objeto(clienteRespueta);
                    if (aux != null && aux is Jugada)
                    {
                        Jugada a = (Jugada)aux;
                        jugadaRecivida.Add(a);
                    }
                    else if (aux != null && aux is Barco)
                    {
                        Barco b = (Barco)aux;
                        barcoRecivido.Add(b);
                    }
                    else if (aux != null && aux is int)
                    {
                        int i = (int)aux;
                        hayGanador(i);
                    }

                }
                catch { }


                barcosMuertos = barcosMs();
                lock (barcosMuertos)
                {
                    if (barcosMuertos.Count > 0)
                    {
                        for (int i = 0; i < barcosMuertos.Count; i++)
                        {
                            Barco auxiliar = barcosMuertos.ElementAt(0);
                            Jugador.Enviar(clienteRespueta, auxiliar);
                            barcosMuertos.Remove(barcosMuertos.ElementAt(0));
                        }

                    }
                }

            }

        }

        List<Barco> barcosMuertos;
        public List<Barco> barcosMs()
        {
            List<Barco> toret = new List<Barco>();
                for (int j = 0; j < 5; j++)
                {
                    if (misBarcos[j].BarcoMuerto())
                    {
                        toret.Add(misBarcos[j]);
                        //listaDeTodosLosBarcosParaDeterminarGanador.Remove(todosBarcos[i][j]); // revisar desde que queden 5 pa abajo
                        //listaDeBarcosHundidosParaDeterminarGanador.Add(todosBarcos[i][j]);
                    }
                }
            
            //agregara ret la lista extra
            return toret;
        }





        public event Action<int> hayGanador;

        public static void Enviar(TcpClient cliente, object Dato)
        {
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

        public static Object Recibir_Objeto(TcpClient cliente)
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
                throw;
            }
        }

    }
}
