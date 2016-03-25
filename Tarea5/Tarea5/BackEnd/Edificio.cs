using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace BackEnd
{
    public class Edificio
    {
        //Thread t1;
        public Celdas[] celdasEdificio;
        public string nombreEdificio;
        public Edificio(Celdas[] misCeldas, string miNombre){
            celdasEdificio = misCeldas;
            nombreEdificio = miNombre;
        }
    }
}
