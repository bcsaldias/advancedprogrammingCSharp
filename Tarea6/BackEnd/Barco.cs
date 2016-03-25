using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public class Barco
    {
        public CeldasBarcoBackend[] celdasDelBarco;
        //public CeldasBarcoBackend[] barcosMuerto;
        public string name;
        protected Barco(int i, CeldasBarcoBackend[] celdas, string nombre)
        {
            name = nombre;
            celdasDelBarco = new CeldasBarcoBackend[i];
        }

        public bool BarcoMuerto()
        {
            for (int i = 0; i < celdasDelBarco.Length; i++)
            {
                if (celdasDelBarco[i].atacado < 0)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
