using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_lab_06
{
    public class LinearQueue
    {
        private int front, rear;
        private string[] array;

        public LinearQueue(int size)
        {
            this.front = this.rear = -1;
            this.array = new string[size];
        }

        public void Enqueue(string data) //додавання елементу в чергу
        {
            
            if (isEmpty())
            {
                front++;
            }
            if (isFull())
            {
                Console.WriteLine("Черга переповнена. Починається процес очищення черги...");
                for (int i = 0; i < array.Length - 1; i++)
                {
                    Dequeue();
                }
                Console.WriteLine("Черга пуста");
                rear = front = -1;
            }
            else
            {
                rear++;
                array[rear] = data;
                Print();
                Console.WriteLine();
            }
        }

       
        public void Dequeue() //Вилучення елементу
        {
            Console.ResetColor();
            string el = array[front];
            array[front] = "";
            if (isEmpty())
            {
                throw new Exception("Черга пуста");
            }
            else if (front == rear)
                front = rear = -1;
            else
            {
                rear--;
            }          
            for (int k = 0; k < array.Length - 1; k++)
            {
                array[k] = array[k + 1];
               
            }
            array[array.Length - 1] = ", ";
            Console.WriteLine("Вилучений елемент: " + el);
            Console.WriteLine();

        }

        private bool isFull() 
        {
            return rear == (array.Length - 1);
        }
        private bool isEmpty()
        {
            return (front == -1) && (rear == -1);
        }

        public void Print()
        {
            Console.Write("Черга: ");
            for (int i = 0; i < array.Length; i++)
            {
                if ((i == front) || (i == rear))
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ResetColor();
                Console.Write(array[i] + ", ");

            }
        }
    }
}
