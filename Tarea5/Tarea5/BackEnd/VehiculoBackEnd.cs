using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class VehiculoBackEnd
    {
        public MatrizCalles calles;
        public int posX;
        public int posY;

        public VehiculoBackEnd(int x, int y)
        {
            posX = x;
            posY = y;
            calles = Program.MCalles;
        }

        public int andarX()
        {
            if (calles.matriz[posX, posY] == -10 || calles.matriz[posX, posY] == 10)
            {
                posX += calles.matriz[posX, posY] / 10;
                return posX;
            }
            return posX;
        }
        public int andarY()
        {
            if (calles.matriz[posX, posY] == -1 || calles.matriz[posX, posY] == 1)
            {
                posY += calles.matriz[posX, posY];
                return posY;
            }
            return posY;
        }

    }
}
