using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class DivisionBackEnd
    {

        public event Action<double> actualizarResultado;

        public void dividir(double a, double b){
            if (b != 0)
            {
                double division = a / b;
                onActualizarResultado(division);
            }
            
        }
        public void onActualizarResultado(double division)
        {
            if (actualizarResultado != null)
            {
                actualizarResultado(division);
            }
        }

    }
}
