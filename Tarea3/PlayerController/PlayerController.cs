using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea3;



namespace PlayerController
{

    public class PlayerController
    {
        static public int[,] numeros;
        public BreakableWall[] rompibles;
        public FixedWall[] fijas;
        static public Nodo[,] mapa;
        /*Este metodo es el que se llamara en cada tick del juego. 
         *Se les entrega el estado del juego y el arreglo de tamano 1 "move".
         *Este arreglo contendra la movida final que realizara su personaje en el tick actual.
         *La idea es que modifiquen el arreglo move cuanto sea necesario durante la ejecucion de este metodo,
         *ya que el juego siempre realizara la ultima movida almacenada en este arreglo, y puede que el juego
         *termine el tick antes de que termine el metodo MakeMove, por lo que realizaria la ultima movida 
         *almacenada en este.
         *La idea de el resto de los parametros es que vuelvan a armar su estructura de datos de acuerdo a los
         *cambios en el mapa desde el tick anterior.
         * El metodo MakeMove que se entrega a continuacion, a modo de ejemplo, realiza
         *una movida aleatorea.
         */
        public int jy = 0;
        public void MakeMove(Bomb[] bombasEnMapa, BreakableWall[] murallasDestruidasEnTickAnterior, PowerUp[] powerupsEnMapa, Character miAgente, Character agenteEnemigo, Game.Move[] move)
        {
            
            for (int i = 0; i < bombasEnMapa.Length; i++)
            {
                ingresarObjetoAlMapa(bombasEnMapa[i], bombasEnMapa[i].PosX, bombasEnMapa[i].PosY, "bomba", mapa.GetLength(0), mapa.GetLength(1));
            }
            for (int i = 0; i < murallasDestruidasEnTickAnterior.Length; i++)
            {
                ingresarObjetoAlMapa(murallasDestruidasEnTickAnterior[i], murallasDestruidasEnTickAnterior[i].PosX, murallasDestruidasEnTickAnterior[i].PosY, "destriuda", mapa.GetLength(0), mapa.GetLength(1));
            }
            for (int i = 0; i < powerupsEnMapa.Length; i++)
            {
                ingresarObjetoAlMapa(powerupsEnMapa[i], powerupsEnMapa[i].PosX, powerupsEnMapa[i].PosY, "power", mapa.GetLength(0), mapa.GetLength(1));
            }

            Character mio = miAgente;
            Character otro = agenteEnemigo;
            mapa[mio.PosX, mio.PosY] = new Nodo(mio, mio.PosX, mio.PosY, "yo", mapa.GetLength(0), mapa.GetLength(1));
            mapa[otro.PosX, otro.PosY] = new Nodo(otro, otro.PosX, otro.PosY, "enemigo", mapa.GetLength(0), mapa.GetLength(1));

            //Game.Move[] queMov = new Game.Move[6];
            //queMov[0] = Game.Move.Left;
            //queMov[1] = Game.Move.Right;
            //queMov[2] = Game.Move.Down;
            //queMov[3] = Game.Move.Up;
            //queMov[4] = Game.Move.Bomb;
            //queMov[5] = Game.Move.None;
 
                switch (Tools.Random.Next(0, 4))
                {
                    case 0:
                        move[0] = Game.Move.Left;
                        if (NoHayRompible(mio.PosX, mio.PosY) == false && bombasEnMapa.Length==0)
                        {
                            TimeSpan au = new TimeSpan(3);
                            move[0] = Game.Move.Bomb;
                            bombasEnMapa = new Bomb[1];
                            bombasEnMapa[0] = new Bomb(mio.PosX,mio.PosY,Bomb.initialRadius);
                            //TimeSpan au = new TimeSpan(3);
                            switch (Tools.Random.Next(0, 4))
                            {
                                case 0:
                                    move[0] = Game.Move.Left;
                                    break;
                                case 1:
                                    move[0] = Game.Move.Right;
                                    break;
                                case 2:
                                    move[0] = Game.Move.Down;
                                    break;
                                case 3:
                                    move[0] = Game.Move.Up;
                                    break;
                            }
                            break;
                        }
                        break;
                    case 1:
                        move[0] = Game.Move.Right;
                        if (NoHayRompible(mio.PosX, mio.PosY) == false && bombasEnMapa.Length == 0)
                        {
                            TimeSpan au = new TimeSpan(3);
                            move[0] = Game.Move.Bomb;
                            bombasEnMapa = new Bomb[1];
                            bombasEnMapa[0] = new Bomb(mio.PosX,mio.PosY,Bomb.initialRadius);
                            //TimeSpan au = new TimeSpan(1);
                            switch (Tools.Random.Next(0, 4))
                            {
                                case 0:
                                    move[0] = Game.Move.Left;
                                    break;
                                case 1:
                                    move[0] = Game.Move.Right;
                                    break;
                                case 2:
                                    move[0] = Game.Move.Down;
                                    break;
                                case 3:
                                    move[0] = Game.Move.Up;
                                    break;
                            }
                            break;
                        }
                        break;
                    case 2:
                        move[0] = Game.Move.Down;
                        if (NoHayRompible(mio.PosX, mio.PosY) == false && bombasEnMapa.Length == 0)
                        {
                            TimeSpan au = new TimeSpan(3);
                            move[0] = Game.Move.Bomb; bombasEnMapa = new Bomb[1];
                            bombasEnMapa[0] = new Bomb(mio.PosX,mio.PosY,Bomb.initialRadius);
                            //TimeSpan au = new TimeSpan(3);
                            switch (Tools.Random.Next(0, 4))
                            {
                                case 0:
                                    move[0] = Game.Move.Left;
                                    break;
                                case 1:
                                    move[0] = Game.Move.Right;
                                    break;
                                case 2:
                                    move[0] = Game.Move.Down;
                                    break;
                                case 3:
                                    move[0] = Game.Move.Up;
                                    break;
                            }
                            break;
                        }
                        break;
                    case 3:
                        move[0] = Game.Move.Up;
                        if (NoHayRompible(mio.PosX, mio.PosY) == false && bombasEnMapa.Length == 0)
                        {
                            TimeSpan au = new TimeSpan(3);
                            move[0] = Game.Move.Bomb; bombasEnMapa = new Bomb[1];
                            bombasEnMapa[0] = new Bomb(mio.PosX,mio.PosY,Bomb.initialRadius);
                            //TimeSpan au = new TimeSpan(3);
                            switch (Tools.Random.Next(0, 4))
                            {
                                case 0:
                                    move[0] = Game.Move.Left;
                                    break;
                                case 1:
                                    move[0] = Game.Move.Right;
                                    break;
                                case 2:
                                    move[0] = Game.Move.Down;
                                    break;
                                case 3:
                                    move[0] = Game.Move.Up;
                                    break;
                            }
                            break;
                        }
                        break;
                }
                      
                //switch (Tools.Random.Next(0, 4))
                //{
                //    case 0:
                //        move[0] = Game.Move.Left;
                //        break;
                //    case 1:
                //        move[0] = Game.Move.Right;
                //        break;
                //    case 2:
                //        move[0] = Game.Move.Down;
                //        break;
                //    case 3:
                //        move[0] = Game.Move.Up;
                //        break;
                //}
            

            

        
            //int[] camino = RevisarCaminoAseguir(mapa,miAgente.PosX,agenteEnemigo.PosY, agenteEnemigo.PosX,agenteEnemigo.PosY);
            //if (jy < camino.Length)
            //{
            //    move[0] = queMov[camino[jy]];
            //    jy++;
            //}


        }

        public void esconderse()
        {
            // moverse random hasta que esté lejos del peligro de bombaa
        }

        public bool NoHayRompible(int x, int y)
        {
            bool ret = true;
            if (mapa[x, y].Derecha.deOb == "rompible")
            {
                ret = false;
            }
            else if (mapa[x, y].Izquierda.deOb == "rompible")
            {
                ret = false;
            }
            else if (mapa[x, y].Abajo.deOb == "rompible")
            {
                ret = false;
            }
            else if (mapa[x, y].Arriba.deOb == "rompible")
            {
                ret = false;
            }
            return ret;
        }

        public int[] RevisarCaminoAseguir(Nodo[,] mapa, int x, int y, int x2, int y2)
        {
            //int[] toRet = new int[17]; // 0 Izquierda, 1 derecha, 2 abajo, 3 arriba, 4 bomba,5.. nada.
            int[] toRet = new int[15];

            MyLista movimientos = new MyLista();

            //int movimiento = esfuerzo + herística;
            int ortogonal = 14;
            int diagonal = 10;

            int[,] solucion = new int[mapa.GetLength(0), mapa.GetLength(1)];
            int[,] generado = new int[mapa.GetLength(0), mapa.GetLength(1)];
            for (int i = 0; i < mapa.GetLength(1); i++)
            {
                for (int j = 0; j < mapa.GetLength(0); j++)
                {
                    if (mapa[j, i].deOb != "fija")
                    {
                        generado[j, i] = 1;
                    }
                    else
                    {
                        generado[j, i] = 0;
                    }
                }
            }
            int am = 0;

            if (PuedoMover(x + 1, y))
            {
                toRet[am] = 1;
                am++;
            }


            return toRet;
        }

        public Boolean PuedoMover(int x, int y)
        {
            if(mapa[x,y].deOb!="fija"){
                return true;
            }
            return false;
        }

        public int[,] camino_matriz(int f1, int c1, int f2, int c2, int[,] listaNodos){
            return null;
        }


        public void ingresarObjetoAlMapa(object toIn, int x, int y,string tipo, int ancho, int alto)
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    if (x == j && y == i)
                    {
                        PlayerController.mapa[x, y] = new Nodo(toIn, x, y, tipo, ancho, alto);
                    }
                }
            }

        }

        /*
         *  Este metodo es el que usaran para armar su estructura inicial del mapa. 
         *  Se llama al inicio del juego y luego de 5 segundos empieza la partida, por lo que deben realizar este metodo en menos 
         *  de 5 segundos.
         *  Se recibe como parametro un objeto Stage, que tiene los siguientes elementos que ustedes pueden utilizar:
         *  ReadOnlyCollection<FixedWall> FixedWalls: Es simplemente una lista que contiene todas las murallas solidas en el mapa.
         *  ReadOnlyCollection<BreakableWall> BreakableWalls: Una lista que contiene todas las murallas rompibles en el mapa.
         *  int Width: El ancho del mapa.
         *  int Height: El alto del mapa.
         *    
         * */
        public void ArmarMapa(Stage mapaInicial, Character miAgente, Character agenteEnemigo)
        {
            mapa = new Nodo[mapaInicial.Width, mapaInicial.Height];
            for (int i = 0; i < mapaInicial.Width; i++)
            {
                for (int j = 0; j < mapaInicial.Height; j++)
                {
                    object pasillo = new object();
                    PlayerController.mapa[i, j] = new Nodo(pasillo, i, j, "", mapaInicial.Width, mapaInicial.Height);
                }
            }


            Character mio = miAgente;
            Character otro = agenteEnemigo;
            int a, b;


            PlayerController.mapa[mio.PosX, mio.PosY] = new Nodo(mio, mio.PosX, mio.PosY, "yo", mapaInicial.Width, mapaInicial.Height);
            PlayerController.mapa[otro.PosX, otro.PosY] = new Nodo(otro, otro.PosX, otro.PosY, "enemigo", mapaInicial.Width, mapaInicial.Height);

            rompibles = new BreakableWall[mapaInicial.BreakableWalls.Count];
            mapaInicial.BreakableWalls.CopyTo(rompibles, 0);
            fijas = new FixedWall[mapaInicial.FixedWalls.Count];
            mapaInicial.FixedWalls.CopyTo(fijas, 0);


            for (int u = 0; u < mapaInicial.FixedWalls.Count; u++)
            {
                a = mapaInicial.FixedWalls[u].PosX;
                b = mapaInicial.FixedWalls[u].PosY;


                for (int i = 0; i < mapaInicial.Height; i++)
                {
                    for (int j = 0; j < mapaInicial.Width; j++)
                    {
                        if (j == a && i == b)
                        {
                            PlayerController.mapa[j, i] = new Nodo(mapaInicial.FixedWalls[u], a, b, "fija", mapaInicial.Width, mapaInicial.Height);
                        }
                    }
                }

            }

            for (int u = 0; u < mapaInicial.BreakableWalls.Count; u++)
            {
                a = mapaInicial.BreakableWalls[u].PosX;
                b = mapaInicial.BreakableWalls[u].PosY;


                for (int i = 0; i < mapaInicial.Height; i++)
                {
                    for (int j = 0; j < mapaInicial.Width; j++)
                    {
                        if (j == a && i == b)
                        {
                            PlayerController.mapa[j, i] = new Nodo(mapaInicial.BreakableWalls[u], a, b, "rompible", mapaInicial.Width, mapaInicial.Height);
                        }
                    }
                }

            }


        }

        /*
         * Simplemente cambia el valor de nombre[0] por tu nombre o sobrenombre, para darle mas personalizacion al juego.
         * */
        public void PonerMiNombre(string[] nombre)
        {
            nombre[0] = "SAPALDIAS";
        }
    }

}
