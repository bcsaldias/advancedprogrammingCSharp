using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Arma
    {
        static Random r = new Random();
        public int durabilidad = r.Next(0, 1001);
        public int poder = r.Next(0,101);

    }
}
