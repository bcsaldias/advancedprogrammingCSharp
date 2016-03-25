using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using BibliotecaT2;
using System.Text;

namespace Tarea2
{
    public class LlaveAzul:ILlave
    {
        public string Decriptar(string aDecriptar)
        {
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(aDecriptar);
            XmlNode raiz = myDoc.DocumentElement;
            char[] raizLetra =raiz.LocalName.ToCharArray(); 
            XmlNode nnodo = raiz;
            XmlNodeList hijosnnodo ;
            while (nnodo.LocalName.Length == 1 && nnodo.HasChildNodes)
            {
                raizLetra = nnodo.LocalName.ToCharArray();
                hijosnnodo = nnodo.ChildNodes;
                nnodo = hijosnnodo[raizLetra[0] - 64 - 1];
            }
            return nnodo.LocalName;
        }
    }
}

