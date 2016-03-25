using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace

ConsoleApplication1
{

    public class PC : Item
    {

        public int garantia;
        public PC(int p, string t, string m, int gar)
            : base(p, t, m)
        {

            garantia = gar;

        }

        public override void imprimir()
        {

            Console.WriteLine(tipo + " " + marca + " " + garantia + " años " + precio);
        }



    }

}