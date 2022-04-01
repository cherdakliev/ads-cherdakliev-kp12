using System;
using static System.Console;

namespace ASD_Labb_04
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            DCList list = new DCList();
            WriteLine($"Користувацькі функції:\nДодати перший елемент -> add_f\n" +
                $"Додати останній елемент -> add_l\nДодати елемент на позицію -> add_to\n" +
                $"Видалити перший елемент -> del_f\nВидалити останній елемент -> del_l\n" +
                $"Видалити елемент на позиції -> del_from\n" +
                $"Додати новий вузол після голови списку, якщо значення" +
                $" вузла парне, інакше – після хвоста списку -> do");

            do
            {
                WriteLine();
                Write("Введіть функцію: ");
                string func = ReadLine();
                func = func.ToLower();
                int pos = 0;
                int data = 0;
                if (func == "add_f")
                {
                    Write("Елемент, що додається: ");
                    data = int.Parse(ReadLine());
                    list.AddFirst(data);
                }
                if (func == "add_l")
                {
                    Write("Елемент, що додається: ");
                    data = int.Parse(ReadLine());
                    list.AddLast(data);
                    list.Print();
                }
                if (func == "add_to")
                {
                    Write("Елемент, що додається: ");
                    data = int.Parse(ReadLine());
                    Write("Позиція: ");
                    pos = int.Parse(ReadLine());
                    list.AddToPosition(data, pos);
                }
                if (func == "del_f")
                {
                    list.DeleteFirst();
                }
                if (func == "del_l")
                {
                    list.DeleteLast();
                }
                if (func == "del_from")
                {
                    Write("Позиція: ");
                    pos = int.Parse(ReadLine());
                    list.DeleteFromPosition(pos);
                }
                if (func == "do") // ЗАВДАННЯ ВАРІАНТУ 5
                {
                    Write("Елемент, що додається: ");
                    data = int.Parse(ReadLine());
                    if (data % 2 == 0)
                    {
                        list.AddToPosition(data, 2);
                    }
                    else
                    {
                        list.AddLast(data);
                        list.Print();
                    }
                }

                Write("Do you want to continue (Y/N)? ");
            } while (ReadKey().Key != ConsoleKey.N);


        }
    }
}
