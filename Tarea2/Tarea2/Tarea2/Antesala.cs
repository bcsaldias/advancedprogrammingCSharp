using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using BibliotecaT2;
using System.Text;

namespace Tarea2
{
    public class Antesala
    {
        public bool LRoja = false;
        public bool LAamilla = false;
        public bool LAzul = false;
        public bool LVerde = false;
        static string paths;

        public int[,] mapaAntesala;
        int ancho, alto;
        public int[,] trabajarConMapa(string path)
        {
            paths = path;
                    
                LRoja = false;
                LAamilla = false;
                LAzul = false;
                LVerde = false;
            BinaryReader mapaBytes = new BinaryReader(File.Open(path, FileMode.Open));
            mapaBytes.BaseStream.Seek(18, SeekOrigin.Begin);
            ancho = mapaBytes.ReadInt32();
            alto = mapaBytes.ReadInt32();
            mapaBytes.Close();

            byte[] bytes = File.ReadAllBytes(path);

            int[,] mapa = new int[ancho, alto];

            int fila = alto - 1;
            int columna = 0;
            int num = 0;
            int i = 0;
            if ((ancho * 3) % 4 == 3)
            {
                i = 0;
            }
            for (int u = i; u + 54 < bytes.Length; u += 3)
            {
                if (columna < ancho && columna > -1)
                {
                    if (bytes[(54 + u)] / 200 == 1)
                    {
                        num = 0;
                    }
                    else
                    {
                        num = 1;
                    }
                    mapa[columna, fila] = num;
                }

                columna++;

                if (columna == ancho)
                {
                    if ((3 * ancho) % 4 == 3)
                    {
                        u += ancho % 4;
                        columna = 0;
                    }
                    else
                    {

                        u += ancho % 4;
                        columna = 0;
                    }
                    if (fila > 0)
                    {
                        fila--;
                    }
                }

            }

            return mapa;
            mapaBytes.Close();
        }

        public int[,] recorrerMapa0()
        {
            
            int j = 0, i = 0;
            int a = 0; int b = 0;
            bool partida = false;

            for (i = 0; i < alto && partida == false; i++)
            {
                for (j = 0; j < ancho && partida == false; j++)
                {
                    if (mapaAntesala[j, i] == 0)
                    {
                        mapaAntesala[j, i]--;
                        a = j; b = i;
                        partida = true;
                    }

                }
            }

            Biblioteca.HayLlave(a, b);
            return moverseDesdeMiPos(a,b);
         }


 
        public int[,] moverseDesdeMiPos(int x, int y){
            int desdeX = x;
            int desdeY = y;
            int a = 0;
            while((LAamilla==false||LAzul==false||LRoja==false||LVerde==false)){
                if (a > 15000)
                {
                    trabajarConMapa(paths);
                }
                int dondeIr = dondeMoverse(desdeX,desdeY);
                if (dondeIr == 1)
                {

                    if (puedeMoverse(desdeX + 1, desdeY))
                    {
                        mapaAntesala[desdeX + 1, desdeY]--;
                        verSiHayllave(desdeX + 1, desdeY); 
                        desdeX = desdeX + 1;
                    }

                }
                else if (dondeIr == 2)
                {
                    if (puedeMoverse(desdeX - 1, desdeY))
                    {
                        mapaAntesala[desdeX -1, desdeY]--;
                        verSiHayllave(desdeX - 1, desdeY);
                        desdeX = desdeX - 1;
                    }

                }
                else if (dondeIr == 3)
                {

                    if (puedeMoverse(desdeX, desdeY + 1))
                    {
                        mapaAntesala[desdeX, desdeY+1]--;
                        verSiHayllave(desdeX, desdeY + 1); 
                        desdeY = desdeY + 1;
                    }

                }
                else if (dondeIr == 4)
                {
                    if (puedeMoverse(desdeX, desdeY - 1))
                    {
                        mapaAntesala[desdeX, desdeY-1]--;
                        verSiHayllave(desdeX, desdeY - 1); 
                        desdeY = desdeY - 1;
                    }

                }
            }

            return mapaAntesala;
        }

        public int dondeMoverse(int x, int y){
            int ret1=1,ret2=1, ret3=1, ret4=1;
            try
            {
                ret1 = mapaAntesala[x + 1, y];
            }
            catch
            {
                ret1 = 1;
            }
            try
            {
                ret2 = mapaAntesala[x - 1, y];
            }
            catch { ret2 = 1; }
            try
            {
                ret3 = mapaAntesala[x, y + 1];
            }
            catch { ret3 = 1; }
            try
            {
                ret4 = mapaAntesala[x, y - 1];
            }
            catch { ret4 = 1; }


            int[] array1 = {ret1,ret2,ret3,ret4};

            int c1, c2, aux;
            for (c1 = 0; c1 <= 12; c1++)
            {
                for (c2 = 0; c2 < 3; c2++)
                {
                    if (array1[c2] < array1[c2 + 1])
                    {
                        aux = array1[c2];
                        array1[c2] = array1[c2 + 1];
                        array1[c2 + 1] = aux;
                    }
                }
            }

            int toRet = 0;

            if (array1[0].Equals(ret1)&&ret1!=1)
            {
                toRet = 1;
            }
            else if (array1[0].Equals(ret2) && ret2 != 1)
            {
                toRet = 2;
            }
            else if (array1[0].Equals(ret3) && ret3 != 1)
            {
                toRet = 3;
            }else if (array1[0].Equals(ret4) && ret4 != 1)
            {
                toRet = 4;
            }else             if (array1[1].Equals(ret1)&&ret1!=1)
            {
                toRet = 1;
            }
            else if (array1[1].Equals(ret2) && ret2 != 1)
            {
                toRet = 2;
            }
            else if (array1[1].Equals(ret3) && ret3 != 1)
            {
                toRet = 3;
            } else if (array1[1].Equals(ret4) && ret4 != 1)
            {
                toRet = 4;
            }else                 if (array1[2].Equals(ret1)&&ret1!=1)
            {
                toRet = 1;
            }
            else if (array1[2].Equals(ret2) && ret2 != 1)
            {
                toRet = 2;
            }
            else if (array1[2].Equals(ret3) && ret3 != 1)
            {
                toRet = 3;
            }else if (array1[2].Equals(ret4) && ret4 != 1)
            {
                toRet = 4;
            }else                  if (array1[3].Equals(ret1)&&ret1!=1)
            {
                toRet = 1;
            }
            else if (array1[3].Equals(ret2) && ret2 != 1)
            {
                toRet = 2;
            }
            else if (array1[3].Equals(ret3) && ret3 != 1)
            {
                toRet = 3;
            }else if (array1[3].Equals(ret4) && ret4 != 1)
            {
                toRet = 4;
            }

            return toRet;
        }

        public bool puedeMoverse(int j, int i ){
            if(mapaAntesala[j,i]!=1){
                return true;
            }
            return false;
        }

        public void verSiHayllave(int j,int i){
            Biblioteca.Llave consulta = new Biblioteca.Llave();
            consulta = Biblioteca.HayLlave(j, i);
            
            if (Biblioteca.Llave.Amarilla == consulta)
            {
                LAamilla = true;
            }
            else if (consulta == Biblioteca.Llave.Azul)
            {
                LAzul = true;
            }
            else if (consulta.Equals(Biblioteca.Llave.NoHayLlave))
            {
            }
            else if (consulta.Equals(Biblioteca.Llave.Roja))
            {
                LRoja = true;
            }
            else if (consulta.Equals(Biblioteca.Llave.Verde))
            {
                LVerde = true;
            }

            
        }

      

        }
    }

    

