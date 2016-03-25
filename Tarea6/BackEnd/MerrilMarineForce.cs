using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public class MerrilMarineForce:Barco
    {
        public static string nombreBarco = "MForce";
        public MerrilMarineForce(CeldasBarcoBackend[] celdas)
            : base(4,celdas,"MForce")
        {
            celdasDelBarco = celdas;
        }
    }
}
