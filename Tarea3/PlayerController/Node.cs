using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerController
{
    public class Node
    {
        Node next;
        int numero;

        public Node Next { get { return next; } set { next = value; } }
        public int Numero{ get { return numero;}}

        public Node(int numero)
        {
            this.numero = numero;
            next = null;
        }

    }
}
