using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace

ConsoleApplication1
{

    public class Item
    {

        public int precio;
        public string tipo;
        public string marca;
        public Item(int p, string t, string m)
        {

            precio = p;

            tipo = t;

            marca = m;

        }

        public virtual void imprimir()
        {

            Console.WriteLine(tipo + " " + precio + " " + marca);
        }

    }

}