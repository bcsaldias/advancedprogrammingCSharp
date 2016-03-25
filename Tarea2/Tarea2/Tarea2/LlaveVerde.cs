using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using BibliotecaT2;
using System.Text;


namespace Tarea2
{
    public class LlaveVerde : ILlave
    {
        public string Decriptar(string aDescri)
        {

            StreamReader sr2 = new StreamReader(aDescri); // Directo
            string aDescrip = sr2.ReadToEnd();
            char[] arrAdes = aDescrip.ToCharArray(0, aDescrip.Length);
            string porRet = "";
            int letra = 0;
            int letrasSaltar = 0;
            while(letra< aDescrip.Length)
            {
                    porRet += arrAdes[letra];
                    letrasSaltar = (arrAdes[letra] - 64) % 6;
                    letra += letrasSaltar+1;
               
            }
                return porRet;
        }
    }
}
