using System;
using static System.Console;
class Task_2{
    static void Main(){
         int n, a, b, c, rev_i, i = 0;
        //  Console.WriteLine(n.ToString().Reverse().ToArray());
         Console.Write("enter n: ");
         n = Int32.Parse(Console.ReadLine());
         a = b = c = 0;
         for (i = 1; i < n; i++){
             a = i / 100;
             b = (i / 10) % 10;
             c = i % 10;
             if(i > 9  && i < 100){
                 rev_i = c*10 + i/10;
             }else if(i > 99 && i < 1000){
                rev_i = c*100 + 10*b + a;
             }else{
                 rev_i = i;
             }
             if (rev_i == i)
             {
                 WriteLine(i);
             } 
         }
    }
}

