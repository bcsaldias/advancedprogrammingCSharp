using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class Asalto:Emergencia
    {
        public int numero;
        static Random r = new Random();
        public Asalto(Celdas donde)
            : base(donde)
        {
            numero = r.Next(4, 41);
            donde.emergencia = "Asalto";
        }

        public void restar(){
            numero--;
            if (numero == 0)
            {
                Program.sacarEmergencia.Add(this);
            }
        }
    }
}
