using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class MatrizCalles
    {
        //falta ver lo de los semáforos
        public int[,] matriz;
        int[,] dirección; // sube -1 baja+1
        public MatrizCalles(int[,] matriz)
        {
            this.matriz = matriz;
            hacerCalles();
        }

        private void hacerCalles()
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    if (matriz[i, j] == -5)
                    {
                        establecerValor(i, j);
                    }
                }
            }
        }

        private void establecerValor(int i,int j)
        {
            if ((i + 2 < matriz.GetLength(0)) && (matriz[i, j] == -5 && matriz[i + 1, j] == -5 && (i + 2 == matriz.GetLength(0) || i + 1 == matriz.GetLength(0) || matriz[i + 2, j] != -5)))
            {
                matriz[i, j] = 1;
                matriz[i + 1, j] = -1;
            }
            else if (((j + 2 < matriz.GetLength(1))) && (matriz[i, j] == -5 && matriz[i, j + 1] == -5 && (j + 2 == matriz.GetLength(1) || j + 1 == matriz.GetLength(1) || matriz[i, j + 2] != -5)))
            {
                matriz[i, j] = -10;
                matriz[i, j+1] = 10;

            }
        }
    }
}
