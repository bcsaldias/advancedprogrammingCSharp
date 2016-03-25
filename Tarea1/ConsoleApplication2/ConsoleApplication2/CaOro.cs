using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class CaOro:Caballero
    {
        static Random r = new Random();
        public int Conciencia;
        public int probAccion;
        public int Vida0;
        public int turnosNoActuados = 0;
        public CaOro(string name): base(name)
        {
            
            Nombre = name;
            Vida = r.Next(2000, 2501);
            Vida0 = Vida;
            Cosmos = r.Next(15, 31);
            Velocidad = r.Next(100, 201);
            Fuerza = r.Next(200, 301);
            Conciencia = r.Next(0, 51);
            probAccion = 100 - Conciencia;
            cInicial = Cosmos;
        }



        public override void Ataque(Caballero CaObjetivo) //Dorado
        {
            int actuara = r.Next(0, 100);
            
            if (actuara < probAccion)
            {
                Console.ReadKey();
                turnosNoActuados = 0;
                Console.WriteLine("\n" + Nombre + " ha atacado a " + CaObjetivo.Nombre);
                Console.WriteLine("Durabilidad de su arma: " + arma.durabilidad);

                CaObjetivo.esAtacado(Fuerza + Cosmos - Conciencia + arma.poder);
                arma.durabilidad -= (Fuerza + Cosmos + arma.poder - CaObjetivo.armadura.defensa) / 10;
                if (arma.durabilidad <= 0)
                {
                    arma.durabilidad = 0;
                }
            }
            else
            {
                turnosNoActuados++ ;
            }
            
        }

        public override void incrementarCosmos()
        {
            Console.ReadKey();
            Cosmos += 10;
            Console.WriteLine("\n" + Nombre + " ha aumentado su Cosmos a: " + Cosmos);
        }

    }
}
