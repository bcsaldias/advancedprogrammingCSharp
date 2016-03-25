using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class SemaforoBackEnd
    {
        public Celdas[] celdSemaforo;
        public int time;
        public int original;
        public SemaforoBackEnd(Celdas[] misCeldas, int time)
        {
            celdSemaforo = misCeldas;
            this.time = time;
            original = time;
        }

        public void restar()
        {
            time--;
            if (time == 0)
            {
                //time = original;
                Program.cambiarLuz.Add(this);
            }
        }
    }
}
