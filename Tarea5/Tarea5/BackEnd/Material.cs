using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class Material
    {
        public string nombreMaterial;
        public double inflamable;
        public double sick;
        public Material(string nombre, double sick, double inflamable)
        {
            nombreMaterial = nombre;
            this.inflamable = inflamable*100;
            this.sick = sick*100;

        }

    }
}
