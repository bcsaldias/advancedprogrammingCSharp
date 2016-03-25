using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {


        static void Main(string[] args)
        {




            
            Simulacion simulacion = new Simulacion();
            simulacion.Comenzar();
            simulacion.Terminar();
            simulacion.VerQuienGana();
                Console.ReadKey(true);
                Console.ReadLine();
        }


    }
}
