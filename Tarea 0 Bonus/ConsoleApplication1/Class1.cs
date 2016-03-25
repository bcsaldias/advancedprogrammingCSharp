using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Class1
    {
        int primI;
        int primJ;
        int segI;
        int segJ;
        int a;
        int b;

        private int[,] matriz = new int[0,0];

        public Class1(int[,] matric)
        {
            matriz = matric;
        }

        public void comenzar()
        {
            System.Console.Title = "Solitario";
            // programación inicial del juego:           
            int[,] matriz = new int[16, 7];
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    matriz[i, j] = 34;
                }
            }
            matriz[3, 3] = -5;
            matriz[0, 0] = 0;
            matriz[1, 0] = 0;
            matriz[5, 0] = 0;
            matriz[6, 0] = 0;
            matriz[7, 0] = 0;
            matriz[8, 0] = 0;
            matriz[9, 0] = 0;
            matriz[10, 0] = 0;
            matriz[14, 0] = 0;
            matriz[15, 0] = 0;
            matriz[0, 1] = 0;
            matriz[1, 1] = 0;
            matriz[5, 1] = 0;
            matriz[6, 1] = 0;
            matriz[7, 1] = 0;
            matriz[8, 1] = 0;
            matriz[9, 1] = 0;
            matriz[10, 1] = 0;
            matriz[14, 1] = 0;
            matriz[15, 1] = 0;
            matriz[0, 5] = 0;
            matriz[1, 5] = 0;
            matriz[5, 5] = 0;
            matriz[6, 5] = 0;
            matriz[7, 5] = 0;
            matriz[8, 5] = 0;
            matriz[9, 5] = 0;
            matriz[10, 5] = 0;
            matriz[14, 5] = 0;
            matriz[15, 5] = 0;
            matriz[0, 6] = 0;
            matriz[1, 6] = 0;
            matriz[5, 6] = 0;
            matriz[6, 6] = 0;
            matriz[7, 6] = 0;
            matriz[8, 6] = 0;
            matriz[9, 6] = 0;
            matriz[10, 6] = 0;
            matriz[14, 6] = 0;
            matriz[15, 6] = 0;
            matriz[7, 2] = 0;
            matriz[8, 2] = 0;
            matriz[7, 3] = 0;
            matriz[8, 3] = 0;
            matriz[7, 4] = 0;
            matriz[8, 4] = 0;
            matriz[11, 0] = 1;
            matriz[12, 0] = 2;
            matriz[13, 0] = 3;
            matriz[11, 1] = 4;
            matriz[12, 1] = 5;
            matriz[13, 1] = 6;
            matriz[9, 2] = 7;
            matriz[10, 2] = 8;
            matriz[11, 2] = 9;
            matriz[12, 2] = 10;
            matriz[13, 2] = 11;
            matriz[14, 2] = 12;
            matriz[15, 2] = 13;
            matriz[9, 3] = 14;
            matriz[10, 3] = 15;
            matriz[11, 3] = 16;
            matriz[12, 3] = 17;
            matriz[13, 3] = 18;
            matriz[14, 3] = 19;
            matriz[15, 3] = 20;
            matriz[9, 4] = 21;
            matriz[10, 4] = 22;
            matriz[11, 4] = 23;
            matriz[12, 4] = 24;
            matriz[13, 4] = 25;
            matriz[14, 4] = 26;
            matriz[15, 4] = 27;
            matriz[11, 5] = 28;
            matriz[12, 5] = 29;
            matriz[13, 5] = 30;
            matriz[11, 6] = 31;
            matriz[12, 6] = 32;
            matriz[13, 6] = 33;

            System.Console.Write("\n\nBienvenido!, Intenta dejar todos los casilleros \nde la izquierda como [ ] jugando al solitario: \n\nEjemplo de jugada: 050017\nSignifica que quieres mover la pieza 05 al lugar de la pieza 17 y comerte la 10.\n\n");
            Class1 obClass1 = new ConsoleApplication1.Class1(matriz);
            obClass1.dibujarMatriz();
            // programación de jugadas

            obClass1.jugada();


            System.Console.ReadKey(true);


        }


        public void revisarTablero()
        {
            int c = 0;

            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (matriz[i,j]==34 && (matriz[i, j] == matriz[i, j + 1] || matriz[i, j] == matriz[i + 1, j] || matriz[i, j] == matriz[i - 1, j] || matriz[i, j] == matriz[i, j-1]))
                    {
                        c = 1;
                    }
                }
            }

            if (c == 0)
            {
                System.Console.Write("\nNO QUEDAN POSIBLE JUGADAS\n\n¿Deseas comenzar una nueva partida?\n\n Digite 1 si desea comenzar una nueva partida\n Haga click en X para salir y cerrar el juego:");
                

                string respuesta = System.Console.ReadLine();

                if (respuesta == "1")
                {
                    System.Console.Clear();
                    comenzar();
                }
            }
            else
            {
                jugada();
            }
        }

        public void hacerJugada(char[] arrayJugada)
        {   
      
            int primero;
            int segundo;
            string inicio = "" + arrayJugada[0] + arrayJugada[1];
            string final = "" + arrayJugada[4] + arrayJugada[5];
            
            int partida = (Convert.ToInt32(new string(arrayJugada[0],1)))*10 + (Convert.ToInt32(new string(arrayJugada[1],1)));
            int llegada = (Convert.ToInt32(new string(arrayJugada[4],1)))*10 + (Convert.ToInt32(new string(arrayJugada[5],1)));
            primero = partida;
            segundo = llegada;

            int[,] aux = new int[7, 7];
            aux[0, 0] =0;
            aux[0, 1] =0;
            aux[0, 2] =7;
            aux[0, 3] =14;
            aux[0, 4] =21;
            aux[0, 5] =0;
            aux[0, 6] =0;
            aux[1, 0] =0;
            aux[1, 1] =0;
            aux[1, 2] =8;
            aux[1, 3] =15;
            aux[1, 4] =22;
            aux[1, 5] =0;
            aux[1, 6] =0;
            aux[2, 0] =1;
            aux[2, 1] =4;
            aux[2, 2] =9;
            aux[2, 3] =16;
            aux[2, 4] =23;
            aux[2, 5] =28;
            aux[2, 6] =31;
            aux[3, 0] =2;
            aux[3, 1] =5;
            aux[3, 2] =10;
            aux[3, 3] =17;
            aux[3, 4] =24;
            aux[3, 5] =29;
            aux[3, 6] =32;
            aux[4, 0] =3;
            aux[4, 1] =6;
            aux[4, 2] =11;
            aux[4, 3] =18;
            aux[4, 4] =25;
            aux[4, 5] =30;
            aux[4, 6] =33;
            aux[5, 0] =0;
            aux[5, 1] =0;
            aux[5, 2] =12;
            aux[5, 3] =19;
            aux[5, 4] =26;
            aux[5, 5] =0;
            aux[5, 6] =0;
            aux[6, 0] =0;
            aux[6, 1] =0;
            aux[6, 2] =13;
            aux[6, 3] =20;
            aux[6, 4] =27;
            aux[6, 5] =0;
            aux[6, 6] = 0;



            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    if (aux[i, j] == primero)
                    {
                       // matriz[i, j] = -5;
                        primI = i;
                        primJ = j;
                    }
                    if (aux[i, j] == segundo)
                    {
                       // matriz[i, j] = 34;
                        segI = i;
                        segJ = j;
                    }
                }
            }

            if ((primI + 2 == segI || primJ + 2 == segJ || primI - 2 == segI || primJ - 2 == segJ) && matriz[primI, primJ] == 34 && matriz[segI, segJ] == -5)
            {

                if (primI + 2 == segI)
                {
                    a = primI + 1;
                    b = primJ;
                }
                if (primJ + 2 == segJ)
                {
                    a = primI;
                    b = primJ + 1;

                }
                if (primI - 2 == segI)
                {
                    a = primI - 1;
                    b = primJ;
                }
                if (primJ - 2 == segJ)
                {
                    a = primI;
                    b = primJ - 1;

                }

                if (matriz[a, b] == 34)
                {
                    matriz[primI, primJ] = -5;
                    matriz[segI, segJ] = 34;
                    matriz[a, b] = -5;
                }

            }
            else
            {
                System.Console.Write("\nMovimiento Inválido\nPresiona 'Enter' para continuar");
                System.Console.ReadKey(true);
            }


            

            System.Console.Clear();
            System.Console.Write("\n\nIntenta dejar todos los casilleros \nde la izquierda como [ ] jugando al solitario: \n\nEjemplo de jugada: 050017\nSignifica que quieres mover la pieza 05 al lugar de la pieza 17 y comerte la 10.\n\n");
            

            dibujarMatriz();
            revisarTablero();
            

            /*
            }*/}
    


        

        public void jugada()
        {
            System.Console.Write("Ingresa tu jugada:");
            string name = System.Console.ReadLine();
            char[] numero = name.ToCharArray();
            if (numero.Length == 6 && "0123456789".Contains(numero[0]) && "0123456789".Contains(numero[1]) && "0".Contains(numero[2]) && "0".Contains(numero[3]) && "0123456789".Contains(numero[4]) && "0123456789".Contains(numero[5]))
            {
                hacerJugada(numero);
            }
            else
            {
                System.Console.Write("\nMovimiento Inválido\nPresiona 'Enter' para continuar");
                System.Console.ReadKey(true);
            }

            System.Console.Clear();
            System.Console.Write("\n\nIntenta dejar todos los casilleros \nde la izquierda como [ ] jugando al solitario: \n\nEjemplo de jugada: 050017\nSignifica que quieres mover la pieza 05 al lugar de la pieza 17 y comerte la 10.\n\n");
            dibujarMatriz();
            revisarTablero();
            

        }

        public void dibujarMatriz(){



            for (int j = 0; j < 7; j++)
            {
                System.Console.Write("\n");
                for (int i = 0; i < 16; i++)
                {
                    if (matriz[i, j] > 0 && matriz[i, j] != 34)
                    {
                        if (i > 8 && matriz[i, j] < 10)
                        {
                            string argumento = "0" + matriz[i, j];
                            if (matriz[i, j] == 1 || matriz[i, j] == 4)
                            {
                                System.Console.Write("  [" + argumento + "]");
                            }
                            else
                            {
                                System.Console.Write("[" + argumento + "]");
                            }
                        }
                        else if (matriz[i, j] >= 10)
                        {
                            if (matriz[i, j] == 28 || matriz[i, j] == 31)
                            {
                                System.Console.Write("  [" + matriz[i, j] + "]");
                            }
                            else
                            {

                                System.Console.Write("[" + matriz[i, j] + "]");
                            }
                        }
                    }

                    else if (matriz[i, j] == 0)
                    {
                        System.Console.Write("   ");
                    }
                    // tablero de juego
                    if (matriz[i, j] == 34)
                    {
                        System.Console.Write("[0]");
                    }
                    if (matriz[i, j] == -5)
                    {
                        System.Console.Write("[ ]");
                    }


                }
            }





        }


    }
}
