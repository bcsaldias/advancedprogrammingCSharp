using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using BibliotecaT2;
using System.Text;

namespace Tarea2
{
    class Program
    {

        public int au = 0;
        static void Main(string[] args)
        {
 
            string[] rutas = new string[4];
            rutas[0] = "..\\..\\MapasIniciales\\mapa1.bmp";
            rutas[1] = "..\\..\\MapasIniciales\\mapa2.bmp";
            rutas[2] = "..\\..\\MapasIniciales\\mapa3.bmp";
            rutas[3] = "..\\..\\MapasIniciales\\mapa4.bmp";
            Biblioteca.EsconderBitmaps(rutas);  

            LlaveAmarilla llaveAm = new LlaveAmarilla();
            LlaveAzul llaveAz = new LlaveAzul();
            LlaveRoja llaveRoj = new LlaveRoja();
            LlaveVerde llaveVer = new LlaveVerde();
            ILlave[] llaves = new ILlave[4];
            llaves[0]=llaveRoj; 
            llaves[1]=llaveVer;
            llaves[2]=llaveAz;
            llaves[3] = llaveAm;
            Biblioteca.EntregarLlaves(llaves);

            Antesala a1 = new Antesala();
            a1.mapaAntesala = a1.trabajarConMapa("..\\..\\MapasIniciales\\mapa1.bmp");
            Biblioteca.EntregarMapa(a1.mapaAntesala);
            a1.recorrerMapa0();

            int[][,] aDevolver = new int[4][,];
            aDevolver[0] = a1.mapaAntesala;

            int a = 0;
            for (int y = 0; y < 4; y++)
            {
                if (a < 3)
                {
                    string roja = Biblioteca.AbrirPuertaRoja();
                    string amarilla = Biblioteca.AbrirPuertaAmarilla();
                    string verde = Biblioteca.AbrirPuertaVerde();
                    string azul = Biblioteca.AbrirPuertaAzul();
                    a1.mapaAntesala = a1.trabajarConMapa(roja + verde + azul + amarilla);
                    Biblioteca.EntregarMapa(a1.mapaAntesala);
                    aDevolver[a + 1] = a1.recorrerMapa0();
                    a++;
                }
                else
                {
                    string roja = Biblioteca.AbrirPuertaRoja();
                    string amarilla = Biblioteca.AbrirPuertaAmarilla();
                    string verde = Biblioteca.AbrirPuertaVerde();
                    string azul = Biblioteca.AbrirPuertaAzul();
                    StreamReader sr2 = new StreamReader(roja + verde + azul + amarilla);
                    string aDescrip = sr2.ReadToEnd();

                    Console.WindowWidth = 159;
                    Console.WriteLine("     ENCONTRASTE EL TESORO     ");
                    Console.WriteLine(aDescrip);
                }
            }

            Program.imprimirMapa(aDevolver[0],1);
            Program.imprimirMapa(aDevolver[1],2);
            Program.imprimirMapa(aDevolver[2],3);
            Program.imprimirMapa(aDevolver[3],4);
            Console.ReadKey();


        }

        public static void imprimirMapa(int[,] map, int numero)
        {

            byte[] bytes = File.ReadAllBytes("..\\..\\MapasIniciales\\mapa" + numero + ".bmp");
            byte[] mapa = new byte[bytes.Length];

            for (int t = 0; t < 54; t++)
            {
                mapa[t] = bytes[t];
            }

            int basura = (map.GetLength(0))%4;
            int[] aux = new int[bytes.Length];
            int a = 0;

            for(int i =map.GetLength(1)-1; i>=0 ;i--){
                for (int j = 0; j<map.GetLength(0) ;j++)
                {
                    aux[54 + a] = map[j, i];
                    aux[54 + a+1] = map[j, i];
                    aux[54 + a+2] = map[j, i];
                    a+=3;

                }
                for (int yu = 0; yu < basura; yu++)
                {
                    aux[54 + a] = 2;
                    a++;
                }
            }

            byte lulu = 0;
            byte hu = 255;
            int f = 0;
            int ya = 0;
            for (int t = 54; t+2< bytes.Length; t++)
            {

                if (aux[t]<0)
                {
                    f++;
                    ya = f%2;
                    lulu = (byte)(lulu+=(byte)ya);
                    bytes[t] = (byte)(lulu);
                    t++;
                    bytes[t] = 0;
                    t++;
                    bytes[t] = (byte)(hu-=1) ;
                }

            }
            File.WriteAllBytes("..\\..\\MapasFinales\\mapa" + numero + "Final.bmp", bytes);
            
            }

    }
}
