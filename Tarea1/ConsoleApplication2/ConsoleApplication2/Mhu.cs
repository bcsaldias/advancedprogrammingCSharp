using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Mhu:CaOro
    {
        int durabilidadInicial;
        public Mhu():base("Mhu")
        {
            durabilidadInicial = armadura.durabilidad;
        }

        public void Regeneracion(CaBronce[] deBronce) // regenera armadura
        {
            Console.ReadKey();
            Console.WriteLine("\n\n\n\n\n Mhu ha Regenerado a los caballeros de Bronce !!!!!!!! \n\n\n\n");
            armadura.durabilidad = durabilidadInicial;

            for (int i = 0; i < 5; i++)
            {
                deBronce[i].Vida = deBronce[i].Vida0;  
            }

        }

    }
}
