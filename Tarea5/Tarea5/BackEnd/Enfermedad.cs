using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class Enfermedad:Emergencia
    {
        public Enfermedad(Celdas donde)
            : base(donde)
        {
            donde.emergencia = "Enfermedad";
        }
    }
}
