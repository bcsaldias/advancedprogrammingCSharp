using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class SenoBackEnd
    {
        public event Action<double> actualizarResultado;
        public void calcular(double a)
        {
            double suma = Math.Sin(a);
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
