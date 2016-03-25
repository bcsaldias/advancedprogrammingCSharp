using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class CaBronce : Caballero
    {

        public string constelacion;
        public int amorAZahori;
        protected static Random r = new Random();
        public int Vida0;
        public int amorZaho0;

        public CaBronce(string name, string constel): base(name)
        {
            Nombre = name;
            Vida0 = r.Next(1000, 1501);
            Vida = Vida0;
            Cosmos = r.Next(30, 51);
            Velocidad = r.Next(50, 151);
            Fuerza = r.Next(150, 251);
            amorZaho0 = r.Next(50, 101);
            amorAZahori = amorZaho0;
            constelacion = constel;
            cInicial = Cosmos;
        }

        public virtual void pensarEnZahori(){
            Console.ReadKey();
            Cosmos = Cosmos + r.Next(5, 11);
            amorAZahori = amorAZahori + r.Next(5, 11);
            Console.WriteLine("\n" + Nombre + " ha pensado en Zahori, Cosmos: " + Cosmos + ", Amor a Zahori: " + amorAZahori);
        }
        public void predicarPorZahori(CaOro enemigo)
        {
            enemigo.Conciencia += r.Next(5, 11);
            enemigo.probAccion = 100 - enemigo.Conciencia;
            if (enemigo.Conciencia > 100)
            {
                enemigo.Conciencia = 100;
            }
            if (enemigo.probAccion <0)
            {
                enemigo.probAccion = 0;
            }
            Console.WriteLine("\n" + Nombre + " ha predicado por Zahori, ahora " + enemigo.Nombre + " tiene conciencia: " + enemigo.Conciencia + " y probabilidad de acción: " +enemigo.probAccion);
        }

        public void ejecucionDeAthena(Caballero contrincante) {
            int probDeCausarMuerte = amorAZahori % 40;
            int aleat = r.Next(1, 101);
            if (aleat <= probDeCausarMuerte)
            {
                Console.WriteLine("\n" + Nombre + " ha realizado la ejecución de Athena");
                contrincante.Vida = 0;
                Console.WriteLine("\n\n" + contrincante.Nombre + " HA MUERTO !!\n\n");
            }
        }

        public override void Ataque(Caballero CaObjetivo)//DeBronce
        {
            Console.ReadKey();
            Console.WriteLine("\n" + Nombre + " ha atacado a " + CaObjetivo.Nombre);
            Console.WriteLine("Durabilidad de arma: " + arma.durabilidad);
            CaObjetivo.esAtacado(Fuerza + Cosmos + arma.poder);
            arma.durabilidad -= (Fuerza + Cosmos + arma.poder- CaObjetivo.armadura.defensa)/10;
            if (arma.durabilidad <= 0)
            {
                arma.durabilidad = 0;
            }
        }

        public override void incrementarCosmos()
        {
            Console.ReadKey();
                Cosmos+= 10;
                Console.WriteLine("\n" + Nombre + " ha aumentado su Cosmos a: " + Cosmos);
        }

    }
}
