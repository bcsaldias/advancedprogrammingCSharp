using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public class PernaNegra:Barco
    {
        public static string nombreBarco = "PernaNegra";
        public PernaNegra(CeldasBarcoBackend[] celdas)
            : base(3,celdas,"PernaNegra")
        {
            celdasDelBarco = celdas;
        }
    }
}
