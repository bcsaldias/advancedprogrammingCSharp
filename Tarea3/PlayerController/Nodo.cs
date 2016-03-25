using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerController
{
   public class Nodo
    {
        private Nodo der = null;
        private Nodo izq = null;
        private Nodo abajo = null;
        private Nodo arriba = null;
        private object element;
        private int posX;
        private int posY;
        public string deOb ="";
        private int pasillo = 0;
        public int usable = 0;

        public Nodo Derecha { get { return der; } set { der = value; } }
        public Nodo Izquierda { get { return izq; } set { izq = value; } }
        public Nodo Abajo { get { return abajo; } set { abajo = value; } }
        public Nodo Arriba { get { return arriba; } set { arriba = value; } }

        public Nodo(object element, int x, int y, string ob, int largo, int alto)
        {
            deOb = ob;
            posX = x;
            posY = y;
            this.element = element;
            if (x > 0 && PlayerController.mapa[x - 1, y] != null)
            {
                der = PlayerController.mapa[x - 1, y];
            }
            if (x < largo - 1 && PlayerController.mapa[x + 1, y] != null)
            {
                izq = PlayerController.mapa[x + 1, y];
            }
            if (y > 0 && PlayerController.mapa[x, y - 1] != null)
            {
                arriba = PlayerController.mapa[x, y - 1];
            }
            if (y < alto - 1 && PlayerController.mapa[x, y + 1] != null)
            {
                abajo = PlayerController.mapa[x, y + 1];
            }

            //if (deOb == null)
            //{
            //    pasillo = 1;
            //}
        }

        public int PosX
        {
            get { return posX; }
        }
        public int PosY
        {
            get { return posY; }
        }

    }
}
