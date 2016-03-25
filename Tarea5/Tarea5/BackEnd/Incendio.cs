using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class Incendio:Emergencia
    {

        public Incendio(Celdas donde)
            : base(donde)
        {
            donde.emergencia = "Incendio";
        }
    }
}
