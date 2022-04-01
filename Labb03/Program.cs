using System;
using static System.Console;
using System.Collections.Generic;

namespace ASD
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Main()
        {
            Random rnd = new Random();
            Write("N: ");
            int n = int.Parse(ReadLine());
            int[] arr = new int[n];

            bool sorted = true;

            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(-20, 20);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > n / 2.0)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                }
                 Write(arr[i] + " ");
                ResetColor();
                
            }
            WriteLine();
            ForegroundColor = ConsoleColor.Yellow;
            for (int i = n-1; i >= 0; i--)
            {
                if (arr[i] > n / 2.0)
                {
                    Write(arr[i] + " ");
                }
            }
            ResetColor();
            int start = 0, end = n - 1;
            for (int i = 0; i < n; i++)
            {
                sorted = true;

                for (int j = start; j < end; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        sorted = false;
                    }
                }
                if (sorted)
                    break;

                end--;

                for (int j = end - 1; j > start; j--)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        sorted = false;
                    }
                }

                if (sorted)
                    break;
            }
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < n / 2.0)
                {
                    Write(arr[i] + " ");
                }
            }
            WriteLine();
        }
    }
}
