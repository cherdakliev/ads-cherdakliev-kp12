using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ASD_La_07
{
    class Value
    {
        public string aeroportOfArrival;
        public string gate;
        public TimeDate departureTime;
        public int isDelayed;

        public Value(string aeroportOfArrival, string gate, TimeDate departureTime)
        {
            this.aeroportOfArrival = aeroportOfArrival;
            this.gate = gate;
            this.departureTime = departureTime;
        }
    }
    class Key
    {
        public string flightCode;

        public Key(string flightCode)
        {
            this.flightCode = flightCode;
        }
    }
    internal class TimeDate
    {
        public int year;
        public string month;
        public int day;
        public int time;
        
        public TimeDate(int year, string month, int day, int time)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.time = time;
        }
    }


    class HashTable
    {

        private double loadness;
        //private int size;
        public Gates gates;
        static public Value[] items;
        static private TimeDate[] timeItems;
        static public string[] StrKeys;
        private long key;
        int count = 0;
        static char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '-', '0','1','2','3','4','5','6','7','8','9'};
        
        private int BetLen = alphabet.Length;
        public HashTable(int size)
        {
            items = new Value[size];
            StrKeys = new string[size];
            timeItems = new TimeDate[size];
        }
        public void CountItems()
        {
            count = 0;
            for (int i = 0; i < StrKeys.Length; i++)
            {
                if (items[i] != null)
                {
                    if (StrKeys[i] != null || items[i].aeroportOfArrival != "DELETED")
                    {
                        count++;
                    }
                }

            }
        }
        static public string GetTime(int num)
        {
            string time = "";

            string min, hourStr;


            if (num > 2400)
            {
                num = num % 2400;
            }
            int hour = num / 100;
            int minute = num % 100;

            if (minute >= 60)
            {
                minute %= 60;
                hour++;
            }
            min = minute.ToString();
            hourStr = hour.ToString();
            if (minute < 10)
                min = "0" + minute;
            if (hour < 10)
                hourStr = "0" + hour;

            time = hourStr + ":" + min;



            return time;
        }

        public void Add(Key Key, Value item)
        {
            int gateIndex = 0;
            if (count < items.Length)
            {
                key = GetHash(Key.flightCode, items);
                items[key] = item;
                items[key].isDelayed = 0;
                timeItems[key] = item.departureTime;
                StrKeys[key] = Key.flightCode;
                gates = new Gates(items.Length);

                //for (int i = 0; i < gates.gatesArr.Length; i++)
                //{
                //    if (gates.gatesArr[i] != null)
                //        if (items[key].gate == gates.gatesArr[i])
                //        {
                //            gateIndex = i;
                //            break;
                //        }
                //}
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null && key != i)
                    {
                        if (items[key].gate == items[i].gate)
                        {
                            if ((items[key].departureTime.day == items[i].departureTime.day) &&
                                (items[key].departureTime.month == items[i].departureTime.month)&&
                                (items[key].departureTime.time < items[i].departureTime.time + 145) && ((items[key].departureTime.time > items[i].departureTime.time - 145))
                                && (items[key].departureTime.year == items[i].departureTime.year))
                            {
                                items[key].isDelayed = items[i].departureTime.time + 145 - items[key].departureTime.time;
                                break;
                            }
                        }
                    }
                }
            
                

            }
            else
            {

                bool prost = true;
                int newSize = items.Length;
                for (int i = 1; i < 100; i++)
                {
                    for (int j = 2; j < (items.Length + i) / 2; j++)
                    {
                        if ((items.Length + i) % j == 0)
                        {
                            prost = false;
                            break;
                        }
                        else
                            prost = true;
                    }
                    if (prost)
                    {
                        newSize = items.Length + i;
                        break;
                    }
                }
                ReHashing(newSize);
            }
            CountItems();
        }
        public void Find(Key key)
        {
            bool contains = false;
            int indexOf = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (StrKeys[i] == key.flightCode)
                    {
                        contains = true;
                        indexOf = i;
                        break;
                    }
                }
            }
            if (!contains)
            {
                Console.WriteLine("Key '" + key.flightCode + "' doesn't exist");
            }
            else
            {
                Console.WriteLine("Key: '" + key.flightCode + "' Value: " + items[indexOf].aeroportOfArrival + " " 
                    + items[indexOf].gate + " " + timeItems[indexOf].year + "/" + timeItems[indexOf].month
                    + "/" + timeItems[indexOf].day + "/" + timeItems[indexOf].time + " " + items[indexOf].isDelayed);
            }
        }
        public long GetHash(string flightCode, Value[] table)
        {
            int StrLen = flightCode.Length;
            
            int[] key = new int[StrLen];
            int index = 0;
            long total = 0;
            char[] c;
            long res = 0;
            c = flightCode.ToLower().ToCharArray();

            for (int i = 0; i < StrLen; i++)
                for (int j = 0; j < BetLen; j++)
                {
                    if (c[i] == alphabet[j])
                    {
                        key[index] = j+1;
                        index++;
                    }
                }
            for (int i = 0; i < StrLen; i++)
            {
                total = key[i] * Pow(BetLen, (StrLen - (i + 1)));
                total = total % table.Length;
                res += total;
            }
            
            total = res % table.Length;

           
                if (table[total] != null)
                {

                    for (int i = 0; i < table.Length; i++)
                    {
                        bool deleted = table[total].aeroportOfArrival == "DELETED";
                        if (deleted)
                        {
                            break;
                        }
                        total = (res + i) % table.Length;
                        if (table[total] == null || deleted)
                            break;
                    }
                }

            return total;
        }

        public void ReHashing(int size)
        {
            Value[] temp = items;
            string[] StrTemp = StrKeys;
            StrKeys = new string[size];
            items = new Value[size];
            timeItems = new TimeDate[size];
            long keyIndex = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                keyIndex = GetHash(StrTemp[i], items);
                StrKeys[keyIndex] = StrTemp[i];
                items[keyIndex] = temp[i];
                items[keyIndex].isDelayed = 0;
                timeItems[keyIndex] = temp[i].departureTime;
            }
        }
        public void Remove(Key key)
        {
            count = 0;
            bool contains = false;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (StrKeys[i] == key.flightCode)
                    {
                        items[i] = new Value("DELETED", "DELETED", null);
                        timeItems[i] = new TimeDate(0, "DELETED", 0, 0);
                        StrKeys[i] = "DELETED";
                        gates = new Gates(items.Length);
                        CountItems();
                        loadness = count / items.Length;
                        contains = true;
                    }
                }
            }
            if (!contains)
            {
                Console.WriteLine("Key '" + key.flightCode + "' doesn't exist");
            }
        }
        public void Print()
        {
            string dayStr = "";
            string time = "";
            string Delayed = "";
            Console.OutputEncoding = Encoding.UTF8;
            Write($"{"Код", 10} {"ІНФО",30} ");
            WriteLine();
            Write($"{"Місто прибування", 30}  {"Гейт", 5}  {"Час", 18}  {"Затримка",19}");
            WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i].departureTime != null)
                    {
                        if (items[i].departureTime.day < 10)
                        {
                            dayStr = "0" + items[i].departureTime.day;
                        }
                        else
                        {
                            dayStr = items[i].departureTime.day.ToString();
                        }
                        time = GetTime(items[i].departureTime.time);
                        Delayed = GetTime(items[i].isDelayed);
                    }
                    
                    
                    Write($"{StrKeys[i], 10}");
                    Write($"{items[i].aeroportOfArrival, 14}");
                    Write($"{items[i].gate, 15}");
                    Write($"{timeItems[i].month, 10}/");
                    Write($"{dayStr}/");
                    Write($"{timeItems[i].year}");
                    Write($"{time, 8}");
                    Write($"{Delayed, 10}");
                    WriteLine();
                }
                
            }
        }
        private long Pow(long num, long pow)
        {
            for (int i = 0; i < pow-1; i++)
            {
                num *= num;
            }
            return num;
        }
    }
}
