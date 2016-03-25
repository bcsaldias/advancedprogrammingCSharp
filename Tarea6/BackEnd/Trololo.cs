using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public class Trololo:Barco
    {
        public static string nombreBarco = "Trololo";
        public Trololo(CeldasBarcoBackend[] celdas)
            : base(3,celdas,"Trololo")
        {
            celdasDelBarco = celdas;
        }
    }
}
