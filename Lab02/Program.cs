using System;
using static System.Console;

namespace ASD
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n, min1, max1, min2, max2, i1, j1, i2, j2, i3, j3, i4, j4;
            i1 = i2 = i3 = i4 = j1 = j2 = j3 = j4 = 0;
            Write("n: ");
            n = int.Parse(ReadLine());
            if (n > 0 && n % 1 == 0)// Перевірка даних
            {
             int[,] arr = new int[n, n];
            //Генерація масива
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(0, n * n);
                }
            }
            min1 = max1 = arr[0, n - 2];
            min2 = max2 = arr[1, n - 1];
            //Вивід масива
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Write(arr[i, j] + " ");
                }
                WriteLine();
            }
            WriteLine();
            //Обхід масива вертикальною змійкою над діагоналлю
            for (int j = n - 2; j >= 0; j--)
            {
                if ((j + 1) % 2 == 1)
                {
                    for (int i = 0; i < n - 1; i++)
                    {
                        if ((i + j) < n - 1)
                        {
                            if (arr[i, j] > max1)
                            {
                                max1 = arr[i, j];
                                i1 = i;
                                j1 = j;
                            }
                            if (min1 > arr[i, j])
                            {
                                min1 = arr[i, j];
                                i2 = i;
                                j2 = j;
                            }
                            Write(arr[i, j] + " ");
                        }
                    }
                }
                else
                {
                    for (int i = n - 2; i >= 0; i--)
                    {
                        if ((i + j) < n - 1)
                        {
                            Write(arr[i, j] + " ");
                        }
                    }
                }
            }
            //Обхід масива(diagonal)
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if ((i + j) == (n - 1))
                    {
                        Write(arr[i, j] + " ");
                    }
                }
            }
            //Обхід масива горизонтальною змійкою під діагоналлю(horizontal)
            for (int i = 0; i < n; i++)
            {
                if ((i + 1) % 2 == 1)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((i + j) > n - 1)
                        {
                            if (arr[i, j] < min2)
                            {
                                min2 = arr[i, j];
                                i3 = i;
                                j3 = j;
                            }
                            if (arr[i, j] > max2)
                            {
                                max2 = arr[i, j];
                                i4 = i;
                                j4 = j;
                            }
                            Write(arr[i, j] + " ");
                        }
                    }
                }
                else
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        if ((i + j) > n - 1)
                        {
                            Write(arr[i, j] + " ");
                        }
                    }
                }
            }
            WriteLine();
            WriteLine($"Максимальне значення над побічною діагоналлю: arr[{i1}, {j1}]: {max1}\n" +
                $"Мінамальне значення над побічною діагоналлю: arr[{i2}, {j2}]: {min1}\n" +
                $"Максимальне значення під побічною діагоналлю: arr[{i4}, {j4}]: {max2}\n" +
                $"Мінамальне значення під побічною діагоналлю: arr[{i3}, {j3}]: {min2}");
            }
            else
            {
                WriteLine("Неккоректні дані!");
            }   
        }
    }
}
