using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public  class HolandesVolador:Barco
    {
        public static string nombreBarco = "HVolador";
        public HolandesVolador(CeldasBarcoBackend[] celdas)
            : base(2, celdas, "HVolador")
        {
            celdasDelBarco = celdas;
        }
    }
}
