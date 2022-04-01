using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Labb_04
{
    class DCList
    {
        int count;
        public Node tail;
        public class Node
        {
            public int data;
            public Node next;
            public Node prev;
            public Node(int data)
            {
                this.data = data;
            }
            public Node(int data, Node next, Node prev)
            {
                this.data = data;
                this.next = next;
                this.prev = prev;
            }
        }
        public DCList()
        {

        }
        public DCList(int data)
        {
            SetTail(data);
        }
        private void SetTail(int data)
        {
            tail = new Node(data);
            tail.next = tail;
            tail.prev = tail;
            count = 1;
            Print();
        }
        public void AddFirst(int data)//OK
        {
            if (count == 0)
            {
                SetTail(data);
                return;
            }
            Node current = new Node(data);
            Node temp = new Node(0);
            if (current != null)
            {
                temp = tail.next;
                current.next = temp;
                current.prev = tail;
                temp.prev = current;
                tail.next = current;
                count++;
            }
            Print();
        }
        public void AddToPosition(int data, int position)//OK
        {
            if (position > count)
            {
                AddLast(data);
            }
            else
            {
                Node current = new Node(data);
                Node temp = new Node(0);
                temp = tail.next;
                for (int i = 1; i <= position - 2; i++)
                {
                    temp = temp.next;
                    position--;
                }
                current.prev = temp;
                current.next = temp.next;
                temp.next.prev = current;
                temp.next = current;
                if (temp == tail)
                {
                    tail = tail.next;
                }
                count++;
            }
            Print();

        }
        public void AddLast(int data)//OK
        {
            Node current = new Node(data);
            Node temp = new Node(0);
            if (count == 0)
            {
                SetTail(data);
                return;
            }
            temp = tail.next;
            current.next = temp;
            current.prev = tail;
            tail.next = current;
            temp.prev = current;
            tail = current;
            count++;
        }
        public void DeleteFirst()//OK
        {
            if (count == 0)
            {
                Console.WriteLine("Список пустий!");
                return;
            }
            Node temp = new Node(0);
            temp = tail.next;
            tail.next = temp.next;
            temp.next.prev = tail;
            temp = null;
            count--;
            Print();
        }
        public void DeleteFromPosition(int position)//OK
        {
            if (count == 0)
            {
                Console.WriteLine("Список пустий!");
                return;
            }
            Node temp = new Node(0);
            temp = tail.next;
            while (position > 1)
            {
                temp = temp.next;
                position--;
            }
            Node temp2 = new Node(0);
            temp2 = temp.prev;
            temp2.next = temp.next;
            temp.next.prev = temp2;
            temp = null;
            count--;
            Print();
        }
        public void DeleteLast() //OK
        {
            if (count == 0)
            {
                Console.WriteLine("Список пустий!");
                return;
            }
            Node temp = new Node(0);
            temp = tail.prev;
            temp.next = tail.next;
            tail.next.prev = temp;
            tail = null;
            tail = temp;
            count--;
            Print();
        }
        public void Print()//ok
        {
            if (count == 0)
            {
                Console.WriteLine("Список пустий!");
                return;
            }
            Node current = tail;
            Console.WriteLine("Список:");
            for (int i = 0; i < count; i++)
            {
                current = current.next;
                Console.WriteLine(current.data);
            }
        }
    }
}
