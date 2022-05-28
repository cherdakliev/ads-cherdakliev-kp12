using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ASD_La_07
{
    class Codes
    {
        public string[] codes;
        public Codes(int size)
        {
            codes = new string[size];
        }

    }
    class Gates
    {
        public string[] gatesArr;
        public Codes[] codesArr;

        public Gates(int size)
        {
            int index = 0;
            int index2 = 0;
            gatesArr = new string[size];
            codesArr = new Codes[size];
            bool flag = true;

            

            for (int i = 0; i < HashTable.StrKeys.Length; i++)
            {
                if (HashTable.items[i] != null && HashTable.items[i].gate != "DELETED")
                {
                    for (int k = 0; k < size; k++)
                    {
                        if (HashTable.items[i].gate == gatesArr[k]) // delete repeating from hashtable
                        {
                            flag = false;
                            break;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        gatesArr[index] = HashTable.items[i].gate;
                        index++;
                    }
                    
                }
            }
            index = 0;
            for (int j = 0; j < size; j++)
            {
                if (gatesArr[j] != null)
                {
                    codesArr[j] = new Codes(size);

                    for (int i = 0; i < HashTable.items.Length; i++)
                    {
                        if (HashTable.items[i] != null)
                        {
                            if (HashTable.items[i].gate == gatesArr[j])
                            {
                                codesArr[index].codes[index2] = HashTable.StrKeys[i];
                                index2++;
                            }
                        }
                }
                }
                index++;
                index2 = 0;
            }
            
        }

        public void Print()
        {
            WriteLine();
            for (int j = 0; j < codesArr.Length; j++)
            {
                if (codesArr[j] != null)
                {
                    Write($"{gatesArr[j],5}");
                    WriteLine();
                    for (int k = 0; k < codesArr[j].codes.Length; k++)
                    {
                        if (codesArr[j].codes[k] != null)
                        {
                            WriteLine($"{codesArr[j].codes[k]}");
                        }

                    }
                    WriteLine();
                }

            }
        }
    }
}
