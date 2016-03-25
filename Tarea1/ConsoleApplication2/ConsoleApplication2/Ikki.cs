using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Ikki:CaBronce
    {
        public int durabArmaInic;
        public int durabArmaduraInic;
        public Ikki()
            : base("Ikki", "ConstelacionDeIkki")
        {
            durabArmaInic = arma.durabilidad;
            durabArmaduraInic = armadura.durabilidad;
        }

        public override void Muere()
        {
            Console.ReadKey();
            Console.WriteLine("IKKI MUERE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            if (r.Next(0, 2) == 1)
            {
                resucitar();
            }
        }

        public void resucitar()
        {
            Console.ReadKey();
            Console.WriteLine("IKKI HA RESUCITADO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Vida = Vida0;
            arma.durabilidad = durabArmaInic;
            armadura.durabilidad = durabArmaduraInic;
        }

    }
}
