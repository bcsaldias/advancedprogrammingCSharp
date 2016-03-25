using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public abstract class Caballero
    {
        public Arma arma = new Arma();
        public Armadura armadura = new Armadura();
        public string Nombre;
        public int Vida;
        public int Cosmos;
        public int Velocidad;
        public int Fuerza;
        public int cInicial;

        public Caballero(string N) { 
        }

        public virtual void incrementarCosmos()
        {
        }

        public virtual void Ataque(Caballero O)
        {
        }

        public void esAtacado(int ataque)
        {
            Console.ReadKey();
            Console.Write("\nLa Vida de " + Nombre + " era " + Vida);
            Vida -= ataque - armadura.defensa;
            armadura.durabilidad -= (ataque - armadura.defensa) / 15;
            if (armadura.durabilidad <= 0)
            {
                armadura.durabilidad = 0;
            }
            if (Vida < 0)
            {
                Vida = 0;
                Muere();
                
            }
            Console.WriteLine(" ahora es " + Vida);
            if (Vida == 0)
            {
                Console.WriteLine("\n\n"+Nombre+" HA MUERTO !!\n\n");
            }
            Console.WriteLine("Durabilidad actual de la armadura " + armadura.durabilidad);
        }
        public virtual void Muere()
        {
        }


    }
}
