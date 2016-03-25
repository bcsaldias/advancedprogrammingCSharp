using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public class Tytanic:Barco
    {
        public static string nombreBarco = "Tytanic";
        public Tytanic(CeldasBarcoBackend[] celdas)
            : base(5,celdas,"Tytanic")
        {
            celdasDelBarco = celdas;
        }
    }
}
