using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Cliente
    {
        public string nombre;
        OC oC;
        public string rut;
        // podría tener dirección e infinitos otros datos public string direccion; 

        public Cliente(string name, string r)
        {
            nombre = name;
            rut = r;
        }

        public void hacerPedido(Cliente c,string m, Item[] objects, Tienda tien)
        {
            oC = new OC(c,m, objects);
            tien.guardaOC(oC);
        }

    }
}
