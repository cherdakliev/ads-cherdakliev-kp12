using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace asd_lab_05
{
    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            Write("Введiть M: ");
            byte m = Convert.ToByte(ReadLine());
            int[,] matrix = new int[m, m];
            int num = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = num + 10; // щоб масив виглядав більш красиво і цільно в консолі, числа починаються з 10
                    num++;
                }
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    int r = rnd.Next(i + 1);
                    int k = rnd.Next(j + 1);
                    int temp = matrix[r, k];
                    matrix[r, k] = matrix[i, j];
                    matrix[i, j] = temp;
                }   
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ForegroundColor = ConsoleColor.White;
                    if (((i + j) >= m) && (i < j))
                    {

                        ForegroundColor = ConsoleColor.Yellow;
                    }

                    Write(matrix[i, j] + " ");
                }
                WriteLine();
            }
            WriteLine();
            Block_Sort(matrix);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ForegroundColor = ConsoleColor.White;
                    if (((i + j) >= m) && (i < j))
                    {

                        ForegroundColor = ConsoleColor.Yellow;
                    }

                    Write(matrix[i, j] + " ");
                }
                WriteLine();
            }
            ReadKey();
        }
        private static int[,] Block_Sort(int[,] matrix) // сортування комірками
        {

            int IsPair = 0;
            int m = matrix.GetLength(0);
            if (m % 2 == 0)
            {
                IsPair++;
            }        
            int max = matrix[m - 2, m - 2];
            int min = matrix[m - 2, m - 2];
            int[] array = new int[16]; // при М = 9, максимальна кількість елементів між побічною і головною діагоналлю справа буде 16
            int CountOfElem = 0;
            for (int j = m - 1; j >= m - 1 - j; j--) //обхід матриці змійкою
            {
                
                if ((j + 1 + IsPair) % 2 == 1)
                {

                    for (int i = m - 2; i >= 1; i--)
                    {
                        if (((i + j) >= m) && (i < j))
                        {
                            array[CountOfElem] = matrix[i, j];
                            if (matrix[i, j] > max)
                            {
                                max = matrix[i, j];
                            }
                            CountOfElem++;
                        }

                    }
                }
                else
                {
                    for (int i = 1; i < j; i++)
                    {
                        if (((i + j) >= m) && (i < j))
                        {
                            array[CountOfElem] = matrix[i, j];
                            if (matrix[i, j] > max)
                            {
                                max = matrix[i, j];
                            }
                            CountOfElem++;
                        }
                    }
                }            
            }
            int CountOfBlocks = (max / 10);
            int k = 10; // щоб масив виглядав більш красиво і цільно в консолі, числа починаються з 10
            int g = 19;
            int[][] bucks = new int[CountOfBlocks][];
            int a = 0;
            int b = 0;
            for (int v = 0; v < CountOfBlocks; v++)
            {
                bucks[a] = new int[CountOfElem];
                for (int i = 0; i < CountOfElem; i++)
                {
                    
                    for (int j = k; j <= g; j++)
                    {
                        if (array[i] == j)
                        {
                            b++;
                        }
                    }
                }
                bucks[a] = new int[b];
                b = 0;
                for (int i = 0; i < CountOfElem; i++)
                    {

                    for (int j = k; j <= g; j++)
                    {
                        if (array[i] == j)
                        {
                            bucks[a][b] = array[i];
                            b++;

                        }
                    }
                }
                b = 0;
                a++;
                int temp;
                temp = k;
                k = g + 1;
                g += 10;
            }
            for (int i = 0; i < bucks.Length; i++) // виводимо не відсортоввані комірки
            {
                Write($"Комiрка {i+1}: ");
                for (int j = 0; j < bucks[i].Length; j++)
                {

                    Write(bucks[i][j] + " ");
                }
                WriteLine();
            }
            WriteLine();
            Sort(bucks); // сорутємо кожну комірку окремо
            int[] res = new int[0];
            for (int j = 0; j < bucks.Length; j++) //переводимо зубчасту матрицу в однорідний масив
            {

                int[] tempMassiv = new int[bucks[j].Length + res.Length]; 
                for (int dd = 0; dd < res.Length; dd++)
                {
                    tempMassiv[dd] = res[dd]; 
                }   


                for (int d = 0; d < bucks[j].Length; d++)
                {
                    tempMassiv[d + res.Length] = bucks[j][d];
                }

                res = tempMassiv;
            }
            int l = 0;
            for (int j = m - 1; j >= m - 1 - j; j--) //обхід матриці змійкою і заміна елементів на результуючі
            {

                if (((j + 1 + IsPair) % 2 == 1))
                {

                    for (int i = m - 2; i >= 1; i--)
                    {
                        if (((i + j) >= m) && (i < j))
                        {
                            matrix[i, j] = res[l];
                            l++;
                        }

                    }
                }
                else
                {
                    for (int i = 1; i < j; i++)
                    {
                        if (((i + j) >= m) && (i < j))
                        {
                            matrix[i, j] = res[l];
                            l++;
                        }
                    }
                }
            }
            return matrix;
        }

        private static int[][] Sort(int[][] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length - 1; j++)
                {
                    for (int k = j + 1; k < arr[i].Length; k++)
                    {
                        if (arr[i][j] > arr[i][k])
                        {
                            temp = arr[i][j];
                            arr[i][j] = arr[i][k];
                            arr[i][k] = temp;
                        }
                    }
                    
                }
            }
            return arr;
        }
    }
}
