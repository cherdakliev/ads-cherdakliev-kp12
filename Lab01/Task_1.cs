using System;
using static System.Console;
using static System.Math;
class Program{
    static void Main(){
        double a, b, x, y, z;
        Random rnd = new Random();
        Write("x: ");
        x = Double.Parse(ReadLine());
        Write("y: ");
        y = Double.Parse(ReadLine());
        Write("z: ");
        z = Double.Parse(ReadLine());
        WriteLine("x is " + x);
        WriteLine("y is " + y);
        WriteLine("z is " + z);
        a = (x + (Pow((Abs(y) + Pow(z, 3)), 1/3.0 )) / Pow(x, 3) + x);
        b = (Sqrt(x-y) / z) + (1 / Pow(a, 2));
        if (Pow(x, 3) + x != 0){
            WriteLine(a); 
        }else{
            WriteLine(" a - Порожня множина");
        }
        if((z != 0) && (x - y >= 0) && (a != 0)){
            WriteLine(b);  
        }else{
            WriteLine(" b - Порожня множина");
        }
    }
}

