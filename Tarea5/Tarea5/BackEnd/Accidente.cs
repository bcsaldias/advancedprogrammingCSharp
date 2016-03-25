using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class Accidente:Emergencia
    {

        public Accidente(Celdas donde):base(donde)
        {
            donde.Emergencia = "Accidente";
        }
    }
}
