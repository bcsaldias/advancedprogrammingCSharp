using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace

ConsoleApplication1
{

    public class OC
    {

        Item[] itemDeOrden;
        public static int nOrden = 0;
        int ordenN;
        public string mes;
        public Cliente comprador;

        public OC(Cliente nam, string m, Item[] objects)
        {
            comprador = nam;
            nOrden += 1;
            ordenN = nOrden;
            itemDeOrden = objects;

            mes = m;

        }

        public void imprimirOrden()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\nNúmero de Orden: "+ ordenN + " Mes: "+ mes + " Cliente: " + comprador.nombre + " Rut: " +comprador.rut);
            for (int i = 0; i < itemDeOrden.Length; i++)
            {
               
                itemDeOrden[i].imprimir();

            }

        }

    }

}

