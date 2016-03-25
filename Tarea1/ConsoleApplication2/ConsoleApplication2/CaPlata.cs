using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class CaPlata : Caballero
    {

        static Random r = new Random();
        public CaPlata(string name): base(name)
        {
            Nombre = name;
            Vida = r.Next(500, 1001);
            Cosmos = r.Next(30, 51);
            Velocidad = r.Next(200, 251);
            Fuerza = r.Next(150, 251);
        }

        public override void Ataque(Caballero CaObjetivo)//Plateado
        {
            Console.ReadKey();
            Console.WriteLine("\n" + Nombre + " ha atacado a " + CaObjetivo.Nombre);
            Console.WriteLine("Durabilidad de su arma: " + arma.durabilidad);
            CaObjetivo.esAtacado(Fuerza + Cosmos + arma.poder);
            arma.durabilidad -= (Fuerza + Cosmos + arma.poder - CaObjetivo.armadura.defensa) / 10;
            if (arma.durabilidad <= 0)
            {
                arma.durabilidad = 0;
            }

        }

        public override void incrementarCosmos()
        {
            Console.ReadKey();
            Cosmos += 2;
            Console.WriteLine("El Cosmos del caballero " + Nombre + " es : " + Cosmos);
        }


    }
}
