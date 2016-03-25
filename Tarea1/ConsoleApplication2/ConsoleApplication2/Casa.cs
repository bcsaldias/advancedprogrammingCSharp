using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Casa
    {
        public CaOro albergado;
        public int numCasa;
        public CaPlata hayPlata;
        public Casa(int n, CaOro ca)
        {
            numCasa = n;
            albergado = ca;
        }

        public void recibirCaballeros(CaPlata cPlata)
        {
            Console.ReadKey();
            hayPlata = cPlata;
            int a = numCasa + 1;
            if(hayPlata!=null){
                Console.WriteLine("\n\n\n\n\n\n\nLa Casa " + a + " ha recibido a los caballeros de bronce y a un caballero de plata");
            }else{
                Console.WriteLine("\n\n\n\n\n\n\nLa Casa " + a + " ha recibido a los caballeros de bronce");
            }

        }

    }
}
