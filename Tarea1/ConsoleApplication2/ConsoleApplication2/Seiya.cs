using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Seiya:CaBronce
    {
        public Seiya()
            : base("Seiya", "ConstelacionDeSeiya")
        {

        }

        public override void pensarEnZahori()
        {
            Console.ReadKey();
            Cosmos += 2*r.Next(5, 11);
            amorAZahori += 2*r.Next(5, 11);
        }
    }
}
