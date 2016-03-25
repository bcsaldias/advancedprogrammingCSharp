using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class RestaBackEnd
    {
    
        public event Action<double> actualizarResultado;
        public RestaBackEnd()
        {
           
        }

        public void restar(double a, double b){
            double resta = a - b;
            onActualizarResultado(resta);
        }
        public void onActualizarResultado(double resta)
        {
            if (actualizarResultado != null)
            {
                actualizarResultado(resta);
            }
        }

    }
}
