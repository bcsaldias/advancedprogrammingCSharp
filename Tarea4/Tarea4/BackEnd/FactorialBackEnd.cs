using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class FactorialBackEnd
    {
        public event Action<int> actualizarResultado;
        public void calcular(int a)
        { if(a>=0){
            int suma = factorial(a) ;
            if (suma < 0)
            {
                onActualizarResultado(0);
            }
            else
            {
                onActualizarResultado(suma);
            }
            }
        }

        public int factorial(int n)
        {
            if (n >= 0)
            {
                if (n == 0 || n == 1)
                {
                    return 1;
                }
                else
                {
                    return n * factorial(n - 1);
                }
            }
            else
            {
                return 0; // cero si no se puede graficar
            }
        }

        public void onActualizarResultado(int suma)
        {
            if (actualizarResultado != null)
            {
                actualizarResultado(suma);
            }
        }
    }
}
