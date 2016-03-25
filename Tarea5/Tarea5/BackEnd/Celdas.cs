using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class Celdas
    {
        public int posX;
        public int posY;
        public Material material;
        public string emergencia;
        public string nombreEdificio;
        public bool hayEmergencia;
        public string Emergencia
        {
            set { emergencia = value; }
            get { return emergencia; }
        }


        public Celdas(int i, int j, Material mat, string nombreEdificio)
        {
            hayEmergencia = false;
            emergencia = null;
            this.nombreEdificio = nombreEdificio;
            posX = i;
            posY = j;
            material = mat;

        }
        
    }
}
