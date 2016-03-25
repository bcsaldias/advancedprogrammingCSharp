using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public class CeldasBarcoBackend
    {
        public int posX;
        public int posY;
        public string nombreBarcp;
        public int dueño;
        public int atacado;

        
        public CeldasBarcoBackend(int i, int j, string barco, int dueño, int atac)
        {
            atacado = -2;
            nombreBarcp = barco;
            posX = i;
            posY = j;
            this.dueño = dueño;
        }
        public int atacaCeldaBarco(int dueño)
        {
            if (atacado < 0)
            {
                atacado = dueño;
            }
            return atacado;
        }
    }
}
