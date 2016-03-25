using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Tienda
    {
        OC[] todasLasOrdenes = new OC[500];
        Item[] todosLosItem;

        public Tienda(Item[] todos)
        {
            todosLosItem = todos;
        }

        public void guardaOC(OC orden)
        {
            todasLasOrdenes[OC.nOrden - 1] = orden;
        }

        public void imprimirOCmes(string m)
        {
            for (int i = 0; i < OC.nOrden; i++)
            {
                if (m == todasLasOrdenes[i].mes) {
                todasLasOrdenes[i].imprimirOrden();
                }
            }
        }

    }
}
