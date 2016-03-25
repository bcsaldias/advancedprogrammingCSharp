using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class CosenoBackEnd
    {
        public event Action<double> actualizarResultado;
        public void calcular(double a)
        {
            double suma = Math.Cos(a);
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
