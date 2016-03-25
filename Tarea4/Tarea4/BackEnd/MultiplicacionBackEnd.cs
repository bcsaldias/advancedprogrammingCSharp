using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class MultiplicacionBackEnd
    {
        public event Action<double> actualizarResultado;

        public void multiplicar(double a, double b){
            double multiplicacion = a * b;
            onActualizarResultado(multiplicacion);
        }
        public void onActualizarResultado(double multiplicacion)
        {
            if (actualizarResultado != null)
            {
                actualizarResultado(multiplicacion);
            }
        }

    }
}
