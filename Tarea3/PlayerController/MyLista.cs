using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerController
{
    class MyLista
    {
        private Node head;
        private Node last;

        public MyLista()
        {
            last = head = null;
        }

        public void Add(int numero)
        {
            if (head == null)
            {
                head = new Node(numero);
                last = head;
            }
            else
            {

                last.Next = new Node(numero);
                last = last.Next;
            }
            
        }

        public int GetNumero(int index)
        {
            Node node = head;
            for (int i = 0; i < index&&node!=null; i++)
            {
                node = node.Next;
            }
            if (node != null)
            {
                return node.Numero;
            }
            return -1;
        }

    }
}
