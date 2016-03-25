using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class VentanaCustomBackEnd
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public VentanaCustomBackEnd(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
