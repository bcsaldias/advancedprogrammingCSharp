using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using BibliotecaT2;
using System.Text;

namespace Tarea2
{
    public class LlaveRoja:ILlave
    {
        

        public string Decriptar(string aDescri)
        {

            StreamReader sr2 = new StreamReader(aDescri);
            string aDescrip = sr2.ReadToEnd();

            char[] arrAdes = aDescrip.ToCharArray(0, aDescrip.Length);
            string porRet = "";
            for (int i = 0; i < aDescrip.Length; i++)
            {
                char nuevo = ' ';
                if (arrAdes[i] != ' ')
                {
                    nuevo = Convert.ToChar(arrAdes[i] - 1);
                    if (arrAdes[i] - 1 == 64)
                    {
                        nuevo = Convert.ToChar(90);
                    }
                }
                porRet+=nuevo;
            }
                return porRet;
        }

    }
}
