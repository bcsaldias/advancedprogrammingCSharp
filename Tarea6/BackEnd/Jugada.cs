using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public class Jugada
    {
        public int posX;
        public int posY;
        public int dueño;
        TimeSpan time;
        DateTime date;
        public int atacoAntes;
        public Jugada(int x, int y, int dueño, int atacoAntes)
        {
            this.atacoAntes = atacoAntes;
            posX = x;
            posY = y;
            this.dueño = dueño;
        }
    }
}
