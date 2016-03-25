using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class FibonacciBackEnd
    {
        public event Action<int> actualizarResultado;
        public void calcular(int a)
        {
            if (a >= 0)
            {
                int suma = fibonacci(a);
                onActualizarResultado(suma);
            }
        }
        public int fibonacci(int n)
        {
            if (n >= 0)
            {

                if (n < 2)
                {
                    return n;
                }
                else
                {
                    return fibonacci(n - 1) + fibonacci(n - 2);
                }
            }
            else
            {
                return 0;// retorna cero si no existe.
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
