using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class Program
    {
        public CeldasBarcoBackend[,] matrizJuego;
        public Barco[][] todosBarcos;
        public Barco[] una;
        public Barco[] dos;
        public Barco[] tres;
        public Barco[] cuatro;
        Random r;

        List<Barco> listaDeBarcosHundidosParaDeterminarGanador;
        List<Barco> listaDeTodosLosBarcosParaDeterminarGanador;

        int m;
        public List<Barco> barcosMuertos;
        static void Main(string[] args)
        {
            
        }
        public Program(int m)
        {
            listaDeBarcosHundidosParaDeterminarGanador = new List<Barco>();
            listaDeTodosLosBarcosParaDeterminarGanador = new List<Barco>();
            barcosExtra = new List<Barco>();
            this.m = m;
            barcosMuertos = new List<Barco>();
            r = new Random();
            matrizJuego = new CeldasBarcoBackend[40, 40];
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    matrizJuego[i, j] = null;
                }
            }
            if (m == 1) { una = Barcos(1); }else
                if (m == 2) { una = Barcos(1); dos = Barcos(2); } else
                    if (m == 3) { una = Barcos(1); dos = Barcos(2); tres = Barcos(3); }else
                        if (m == 4) { una = Barcos(1); dos = Barcos(2); tres = Barcos(3); cuatro = Barcos(4); }

           
            #region
            todosBarcos = new Barco[m][];
            if (m == 1)
            {
                todosBarcos[0] = una;
            }
            else if (m == 2) {
                todosBarcos[0] = una;
                todosBarcos[1] = dos;
            }
            else if (m == 3) {
                todosBarcos[0] = una;
                todosBarcos[1] = dos;
                todosBarcos[2] = tres;
            }
            else if (m == 4) {
                todosBarcos[0] = una;
                todosBarcos[1] = dos;
                todosBarcos[2] = tres;
                todosBarcos[3] = cuatro;
            }
            #endregion

            for (int i = 0; i < todosBarcos.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    listaDeTodosLosBarcosParaDeterminarGanador.Add(todosBarcos[i][j]);
                }
            }
        }

        public int revisarGanador()
        {
            if (listaDeTodosLosBarcosParaDeterminarGanador.Count == 1)
            {
                return listaDeTodosLosBarcosParaDeterminarGanador.ElementAt(0).celdasDelBarco[0].dueño;
            }
            else if (listaDeTodosLosBarcosParaDeterminarGanador.Count <= 5)
            {
                return revisarBarcos();
            }
            return 0;
        }

        private int revisarBarcos()
        {
            List<int> dueños = new List<int>();
            for (int i = 0; i < listaDeTodosLosBarcosParaDeterminarGanador.Count; i++)
            {
                dueños.Add(listaDeTodosLosBarcosParaDeterminarGanador.ElementAt(i).celdasDelBarco[0].dueño);
            }
            for (int i = 0; i < dueños.Count; i++)
            {
                for (int j = 0; j < dueños.Count; j++)
                {
                    if (dueños.ElementAt(j) != dueños.ElementAt(i))
                    {
                        return 0;
                    }
                }
            }
            return dueños.ElementAt(0);
        }
        public List<Barco> barcosExtra;
        public List<Barco> barcosMs()
        {
            List<Barco> toret = new List<Barco>();
            for (int i = 0; i < todosBarcos.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (todosBarcos[i][j].BarcoMuerto())
                    {
                       toret.Add(todosBarcos[i][j]);
                       listaDeTodosLosBarcosParaDeterminarGanador.Remove(todosBarcos[i][j]); // revisar desde que queden 5 pa abajo
                       //listaDeBarcosHundidosParaDeterminarGanador.Add(todosBarcos[i][j]);
                   }
                }
            }
            for (int i = 0; i < barcosExtra.Count; i++)
            {
                toret.Add(barcosExtra.ElementAt(i));   
            }
            //agregara ret la lista extra
            return toret;
        }
        //cuando se recibe un ataque ver primero si ya es atacado. si atacado !=null retornar el numero del dueño +5
        // o si respuesta es >0 usar dic :)

        private Barco[] Barcos(int dueño)
        {
            Barco[] toRet = {crearTitanic(dueño),crearMerril(dueño),crearTrololo(dueño),crearPerna(dueño),crearHolandes(dueño)};
            return toRet;
        }
        private Tytanic crearTitanic(int dueño)
        {
            
            CeldasBarcoBackend[] misCeldas = new CeldasBarcoBackend[5];
            while(true){
            int posInicialX = r.Next(40); 
            int posInicialY = r.Next(40);
            int horizontalOvertical = r.Next(2);

            if(puedePonerse(posInicialX,posInicialY,5,horizontalOvertical)){
                if (horizontalOvertical == 0) //horizontal
                {
                    for (int i = 0; i < 5; i++)
                    {
                        misCeldas[i] = new CeldasBarcoBackend(posInicialX + i, posInicialY, Tytanic.nombreBarco,dueño,-2);
                        matrizJuego[posInicialX + i, posInicialY] = misCeldas[i];
                    }
                    Tytanic aux = new Tytanic(misCeldas);

                    return aux;
                }
                else if (horizontalOvertical == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        misCeldas[i] = new CeldasBarcoBackend(posInicialX, posInicialY + i, Tytanic.nombreBarco,dueño,-2);
                        matrizJuego[posInicialX, posInicialY + i] = misCeldas[i];
                    }
                    Tytanic aux = new Tytanic(misCeldas);

                    return aux;
                }
            }
            }
            //return null;
        }
        private MerrilMarineForce crearMerril(int dueño)
        {
            CeldasBarcoBackend[] misCeldas = new CeldasBarcoBackend[4];
            while (true)
            {
                int posInicialX = r.Next(40);
                int posInicialY = r.Next(40);
                int horizontalOvertical = r.Next(2);

                if (puedePonerse(posInicialX, posInicialY, 4, horizontalOvertical))
                {
                    if (horizontalOvertical == 0) //horizontal
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            misCeldas[i] = new CeldasBarcoBackend(posInicialX + i, posInicialY,MerrilMarineForce.nombreBarco,dueño,-2);
                            matrizJuego[posInicialX + i, posInicialY] = misCeldas[i];
                        }
                        MerrilMarineForce aux = new MerrilMarineForce(misCeldas);
                        return aux;
                    }
                    else if (horizontalOvertical == 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            misCeldas[i] = new CeldasBarcoBackend(posInicialX, posInicialY + i, MerrilMarineForce.nombreBarco,dueño,-2);
                            matrizJuego[posInicialX, posInicialY + i] = misCeldas[i];
                        }
                        MerrilMarineForce aux = new MerrilMarineForce(misCeldas);

                        return aux;
                    }
                }
            }
        }
        private Trololo crearTrololo(int dueño)
        {
           
            CeldasBarcoBackend[] misCeldas = new CeldasBarcoBackend[3];
            while (true)
            {
                int posInicialX = r.Next(40);
                int posInicialY = r.Next(40);
                int horizontalOvertical = r.Next(2);

                if (puedePonerse(posInicialX, posInicialY, 3, horizontalOvertical))
                {
                    if (horizontalOvertical == 0) //horizontal
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            misCeldas[i] = new CeldasBarcoBackend(posInicialX + i, posInicialY,Trololo.nombreBarco,dueño,-2);
                            matrizJuego[posInicialX + i, posInicialY] = misCeldas[i];
                        }
                        Trololo aux = new Trololo(misCeldas);
                        return aux;
                    }
                    else if (horizontalOvertical == 1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            misCeldas[i] = new CeldasBarcoBackend(posInicialX, posInicialY + i,Trololo.nombreBarco,dueño,-2);
                            matrizJuego[posInicialX, posInicialY + i] = misCeldas[i];
                        }
                        Trololo aux = new Trololo(misCeldas);

                        return aux;
                    }
                }
            }
        }
        private PernaNegra crearPerna(int dueño)
        {
           
            CeldasBarcoBackend[] misCeldas = new CeldasBarcoBackend[3];
            while (true)
            {
                int posInicialX = r.Next(40);
                int posInicialY = r.Next(40);
                int horizontalOvertical = r.Next(2);

                if (puedePonerse(posInicialX, posInicialY, 3, horizontalOvertical))
                {
                    if (horizontalOvertical == 0) //horizontal
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            misCeldas[i] = new CeldasBarcoBackend(posInicialX + i, posInicialY,PernaNegra.nombreBarco,dueño,-2);
                            matrizJuego[posInicialX + i, posInicialY] = misCeldas[i];
                        }
                        PernaNegra aux = new PernaNegra(misCeldas);
                        return aux;
                    }
                    else if (horizontalOvertical == 1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            misCeldas[i] = new CeldasBarcoBackend(posInicialX, posInicialY + i,PernaNegra.nombreBarco,dueño,-2);
                            matrizJuego[posInicialX, posInicialY + i] = misCeldas[i];
                        }
                        PernaNegra aux = new PernaNegra(misCeldas);

                        return aux;
                    }
                }
            }
        }
        private HolandesVolador crearHolandes(int dueño)
        {
          
            CeldasBarcoBackend[] misCeldas = new CeldasBarcoBackend[2];
            while (true)
            {
                int posInicialX = r.Next(40);
                int posInicialY = r.Next(40);
                int horizontalOvertical = r.Next(2);

                if (puedePonerse(posInicialX, posInicialY, 2, horizontalOvertical))
                {
                    if (horizontalOvertical == 0) //horizontal
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            misCeldas[i] = new CeldasBarcoBackend(posInicialX + i, posInicialY,HolandesVolador.nombreBarco,dueño,-2);
                            matrizJuego[posInicialX + i, posInicialY] = misCeldas[i];
                        }
                        HolandesVolador aux = new HolandesVolador(misCeldas);
                        return aux;
                    }
                    else if (horizontalOvertical == 1)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            misCeldas[i] = new CeldasBarcoBackend(posInicialX, posInicialY + i,HolandesVolador.nombreBarco,dueño,-2);
                            matrizJuego[posInicialX, posInicialY + i] = misCeldas[i];
                        }
                        HolandesVolador aux = new HolandesVolador(misCeldas);

                        return aux;
                    }
                }
            }
        }

        private bool puedePonerse(int x, int y, int largo, int lado)
        {
            if (lado == 1)
            {
                for (int j = 0; j < largo; j++)
                {
                    if ( j + y > 39|| matrizJuego[x, y + j] != null )
                    {
                        return false;
                    }
                }
            }
            else if (lado == 0)
            {
                for (int j = 0; j < largo; j++)
                {
                    if (j + x > 39||matrizJuego[x + j, y] != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public event Action<Jugada> jugada;
        public event Action<Jugada> jug;
        public event Action<Barco> jiji;

        public void juge(Jugada j1)
        {
            if (j1 != null)
            {
                if (matrizJuego[j1.posX, j1.posY] != null)
                {
                    jug(j1);
                }
            }
        }
        public void barquito(Barco b)
        {
            if (b != null)
            {
                jiji(b);
            }
        }

        public void dpsDeRevisarJugada1()
        {
            barcosMuertos = barcosMs();
            lock (barcosMuertos)
            {
                if (barcosMuertos.Count > 0)
                {
                    for (int i = 0; i < barcosMuertos.Count; i++)
                    {
                        Barco auxiliar = barcosMuertos.ElementAt(0);
                        Server.Enviar(Server.ClienteQueReciveRespuesta[1], auxiliar);
                        barquito(auxiliar);
                        barcosMuertos.Remove(barcosMuertos.ElementAt(0));
                    }

                }
            }
            int ganador = revisarGanador();
            if (ganador != 0)
            {
                Server.Enviar(Server.ClienteQueReciveRespuesta[1], ganador);
                hayGanador(ganador);
            }
        }
        public void dpsDeRevisarJugada2()
        {
            barcosMuertos = barcosMs();
            lock (barcosMuertos)
            {
                if (barcosMuertos.Count > 0)
                {
                    for (int i = 0; i < barcosMuertos.Count; i++)
                    {
                        Barco auxiliar = barcosMuertos.ElementAt(0);
                        Server.Enviar(Server.ClienteQueReciveRespuesta[1], auxiliar);
                        Server.Enviar(Server.ClienteQueReciveRespuesta[2], auxiliar);
                        barquito(auxiliar);
                        barcosMuertos.Remove(barcosMuertos.ElementAt(0));
                    }

                }
            }
            int ganador = revisarGanador();
            if (ganador != 0)
            {
                Server.Enviar(Server.ClienteQueReciveRespuesta[1], ganador);
                Server.Enviar(Server.ClienteQueReciveRespuesta[2], ganador);
                hayGanador(ganador);
            }
        }
        public void dpsDeRevisarJugada3()
        {
            barcosMuertos = barcosMs();
            lock (barcosMuertos)
            {
                if (barcosMuertos.Count > 0)
                {
                    for (int i = 0; i < barcosMuertos.Count; i++)
                    {
                        Barco auxiliar = barcosMuertos.ElementAt(0);
                        Server.Enviar(Server.ClienteQueReciveRespuesta[1], auxiliar);
                        Server.Enviar(Server.ClienteQueReciveRespuesta[2], auxiliar);
                        Server.Enviar(Server.ClienteQueReciveRespuesta[3], auxiliar);
                        barquito(auxiliar);
                        barcosMuertos.Remove(barcosMuertos.ElementAt(0));
                    }

                }
            }
            int ganador = revisarGanador();
            if (ganador != 0)
            {
                Server.Enviar(Server.ClienteQueReciveRespuesta[1], ganador);
                Server.Enviar(Server.ClienteQueReciveRespuesta[2], ganador);
                Server.Enviar(Server.ClienteQueReciveRespuesta[3], ganador);
                hayGanador(ganador);
            }
        }
        public int revisarJugada(Jugada j)
        {
            lock (j)
            {
                int n;
                if (matrizJuego[j.posX, j.posY] == null)
                {
                    jugada(j);
                    return 0;
                }
                else if (matrizJuego[j.posX, j.posY].atacado != -2)
                {
                    n = matrizJuego[j.posX, j.posY].atacado;
                    return n;
                }
                n = matrizJuego[j.posX, j.posY].dueño;
                matrizJuego[j.posX, j.posY].atacado = j.dueño + 10;
                return n;
            }

        }
        public event Action<int> hayGanador;
        public int revisarJugada2(Jugada j)
        {
            int n;
            if (matrizJuego[j.posX, j.posY] == null)
            {
                return 0;
            }
            else if (matrizJuego[j.posX, j.posY].atacado != -2)
            {
                n = matrizJuego[j.posX, j.posY].atacado;
                return n;
            }
            n = matrizJuego[j.posX, j.posY].dueño;
            matrizJuego[j.posX, j.posY].atacado = j.dueño+10;
            return n;
        }

     public bool hayJugada(Jugada j){
            return true;
        }


        //public void RevisarBarcoHundido()
        //{

        //    if(else barco está hundido) enviar a todos las celdas con colores !
            
        //}

    }
}
