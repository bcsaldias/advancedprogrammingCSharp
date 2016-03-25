using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            int[,] matriz = new int[0,0];
            Class1 ao = new Class1(matriz);
            ao.comenzar();

        }

    }
}
