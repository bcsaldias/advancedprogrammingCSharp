using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{


    public class SumaBackEnd
    {
        private static void Main(string[] args)
        {
        }


        

        public SumaBackEnd()
        {
        }
        public event Action<double> actualizarResultado;
        public void sumar(double a, double b){
            double suma = a + b;
            onActualizarResultado(suma);
        }
        public void onActualizarResultado(double suma)
        {
            if (actualizarResultado != null)
            {
                actualizarResultado(suma);
            }
        }

    }
}
