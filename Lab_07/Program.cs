using System;
using static System.Console;

namespace ASD_La_07
{

    class Program
    {

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
        static void Main()
        {
            string[] monthArr = new string[12]{
                "January", "February",
                "March", "April", "May",
                "June", "July", "August",
                "September","October", "November", "December"
            };
            string[] arriveArray = new string[15]
            {
                "Rome","Antalya","Toronto","Kyiv","Stambul",
                "New-York","Paris","Munchen","Viena","London",
                "Liverpool","Pekin","Amsterdam","Madrid","Budapest",
            };
            string[] gateArray = new string[4]
            {
                "Gate 1", "Gate 2", "Gate 3",
                "Gate 1"
            };
            string[] flightCodes = new string[10]
            {
                "ukc-21","fel-8","31-tor","66-spe",
                "lokj-214","ljk-17","tre-91", "top-3",
                "kerya-56","18ti"
            };

            int day, year, time;
            string month, ar, gate, flightCode;
            TimeDate td;
            Value v;
            Key key;
            HashTable hs = new HashTable(7);
            Random rnd = new Random();
            int index;
            for (int i = 0; i < 10; i++)
            {
                year = 2022;
                index = rnd.Next(0, 11);
                month = monthArr[index];
                if ((index + 1) == 2)
                {
                    day = rnd.Next(1, 28);
                }
                else
                {
                    day = rnd.Next(1, 30);
                }
                time = rnd.Next(1, 2400);
                td = new TimeDate(year, month, day, time);

                flightCode = flightCodes[i];
                key = new Key(flightCode);

                ar = arriveArray[rnd.Next(0, 14)];
                gate = gateArray[rnd.Next(0, 4)];
                v = new Value(ar, gate, td);
                hs.Add(key, v);
            }
            hs.Print();
            hs.gates.Print();
            WriteLine();
            key = new Key("tre-91");
            hs.Remove(key);
            hs.Print();
            WriteLine();
            key = new Key("lokj-214");
            hs.Find(key);
            WriteLine();
            hs.gates.Print();

            int[] t = new int[4]
            {
                1740, 1810, 1839, 1730
            };
            string[] co = new string[4] {
                "key-1","key-2","key-3","key-4"
            };
            for (int i = 0; i < 4; i++)
            {
                //Write("Напишіть ключ: ");
                //flightCode = ReadLine();
                //Write("Введіть аеропорт прибуття: ");
                //ar = ReadLine();
                //WriteLine();
                //Write("Введіть полосу: ");
                //gate = ReadLine();
                //year = 2022;
                //WriteLine();
                //Write("Введіть місяць: ");
                //month = ReadLine();
                //WriteLine();
                //Write("Введіть день: ");
                //day = Convert.ToInt32(ReadLine());
                //WriteLine();
                //Write("Введіть час: ");
                //time = Convert.ToInt32(ReadLine());
                //WriteLine();
                year = 2022;
                month = "February";
                day = 27;
                time = t[i];
                ar = arriveArray[rnd.Next(0, 14)];
                gate = gateArray[i];
                flightCode = co[i];
                td = new TimeDate(year, month, day, time);
                v = new Value(ar, gate, td);
                key = new Key(flightCode);
                hs.Add(key, v);
            }
            hs.Print();
            hs.gates.Print();
            ReadLine();

        }
    }
}
