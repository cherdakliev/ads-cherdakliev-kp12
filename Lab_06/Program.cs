using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace asd_lab_06
{
    class Program
    {
        static void Main()
        {
            do
            {
                WriteLine();
                Write("Введiть 'example' для показу контрольного прикладу. Введiть 'user' для введення з клавiатури: "); // Користувацьке меню
                string s = ReadLine();
                if (s.ToLower() == "example")
                {
                    LinearQueue q = new LinearQueue(10);
                    string[] arr1 = new string[10] { "Acn65", "76nCB", "98KIC8", "iol", "j7k", "gg8", "67hh", "fff7jk8", "87jh", "fdddl"};
                    string[] arr2 = new string[5] { "GDF4", "ddf5", "123dOL", "dc11", "UIO6"};
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Червноим кольором позначаються голова та хвiст черги "); //КОНТРОЛЬНИЙ ПРИКЛАД
                    ResetColor();
                    WriteLine("Контрольний приклад: ");
                    WriteLine("Розмір черги: 10 ");
                    WriteLine();
                    q.Print();
                    WriteLine();

                    for (int i = 0; i < arr1.Length; i++)
                    {
                        string m = "";
                        if (arr1[i] == "j7k" || arr1[i] == "fff7jk8")
                        {
                            m = "(ЗА УМОВОЮ ЗАВДАННЯ ЦЕЙ ЕЛЕМЕНТ НЕ БУДЕ ДОДАНИЙ, А ПЕРШИЙ ЕЛЕМЕНТ ЧЕРГИ БУДЕ ВИЛУЧЕНИЙ)";
                            WriteLine("Додаэмо елемент: " + arr1[i] + m);
                            AddToQueue(arr1[i], q, ref i);
                            i = i + 2;
                        }
                        else
                        {
                            WriteLine("Додаэмо елемент: " + arr1[i] + m);
                            AddToQueue(arr1[i], q, ref i);
                        }
                        
                    }

                    for (int i = 0; i < arr2.Length; i++)
                    {
                        WriteLine("Додаэмо елемент: " + arr2[i]);
                        AddToQueue(arr2[i], q, ref i);
                    }
                }
                else if (s.ToLower() == "user")
                {
                    Write("Введіть довжину черги: ");
                    int size = Convert.ToInt32(ReadLine());
                    LinearQueue q = new LinearQueue(size);
                    int k = 0;
                    while (k != size)
                    {
                        Write("Введіть елемент у чергу: ");
                        string item = ReadLine();
                        WriteLine("Додаэмо елемент: " + item);
                        AddToQueue(item, q,  ref k);
                        k++;
                    }
                    WriteLine();
                    q.Enqueue("3");
                }
                else
                {
                    WriteLine("Помилка!");
                }
                Write("Do you want to continue (Y/N)? ");
            } while (ReadKey().Key != ConsoleKey.N);
            
 
        }

        static void AddToQueue(string data, LinearQueue q, ref int k)
        {
            char[] a = new char[100];
            a = data.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {

                if (i != 0 && i != a.Length - 1)
                {
                    bool num = ((Convert.ToInt32(a[i]) >= 48) && (Convert.ToInt32(a[i]) <= 57));//перевірка чи елемети підхоядть до умови вилучення
                    if (num)
                    {
                        bool letter1 = ((Convert.ToInt32(a[i - 1]) >= 65) && (Convert.ToInt32(a[i - 1]) <= 122));
                        bool letter2 = ((Convert.ToInt32(a[i + 1]) >= 65) && (Convert.ToInt32(a[i + 1]) <= 122));
                        if (num && letter1 && letter2)
                        {
                            q.Dequeue();
                            k = k - 2;
                            break;
                        }
                    }
                }
                else if (i == a.Length - 1)
                {
                    q.Enqueue(data);
                    break;
                }

            }
        }
    }


}
