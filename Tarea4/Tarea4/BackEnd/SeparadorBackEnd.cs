using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class SeparadorBackEnd
    {

        private double numer;
        public event Action<double> actualizarResultado;
        
        public void numero(double num)
        {
            numer = num;
            onActualizarResultado(num);
        }
        public double Numero { get { return numer; } }

        public void onActualizarResultado(double suma)
        {
            if (actualizarResultado != null)
            {
                actualizarResultado(suma);
            }
        }

    }
}
