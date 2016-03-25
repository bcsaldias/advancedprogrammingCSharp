using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class PlotterBackEnd
    {
        public double inicio;
        public double final;
        public double step;
        public double numeroDePuntos;
        public string toPlot;
        double[,] listaDePuntos;

        public PlotterBackEnd(string aGrap)
        {
            toPlot = aGrap;
        }
        public double[,] graficar(){
            numeroDePuntos = (double)((final - inicio) / step);
            listaDePuntos = new double[2, (int)numeroDePuntos];

            if (toPlot == "seno")
            {
                for (int i = 0; i < (int)numeroDePuntos; i++)
                {
                    listaDePuntos[0, i] = inicio+i*step;
                    listaDePuntos[1, i] = Math.Sin(inicio + i*step);
                }
            }
            else if (toPlot == "coseno")
            {
                for (int i = 0; i < (int)numeroDePuntos; i++)
                {
                    listaDePuntos[0, i] = inicio+i*step;
                    listaDePuntos[1, i] = Math.Cos(inicio + i*step);
                }
            }
            else if (toPlot == "factorial")
            {
                FactorialBackEnd fact = new FactorialBackEnd();
                for (int i = 0; i < (int)numeroDePuntos; i++)
                {
                    listaDePuntos[0, i] = inicio + i * step;
                    listaDePuntos[1, i] = fact.factorial((int)(inicio + i * step));
                }
            }
            else if (toPlot == "fibonacci")
            {
                FibonacciBackEnd fib = new FibonacciBackEnd();
                for (int i = 0; i < (int)numeroDePuntos; i++)
                {
                    listaDePuntos[0, i] = inicio + i * step;
                    listaDePuntos[1, i] = fib.fibonacci((int)(inicio + i * step));
                }

            }
            return listaDePuntos;
        }
    }
}
