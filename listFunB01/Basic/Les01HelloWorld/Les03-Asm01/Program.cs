using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les03_Asm01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum;
            double sub;
            double x;
            double y;
            Console.WriteLine("Input sum of x and y: ");
            sum = double.Parse(Console.ReadLine());

            Console.WriteLine("Input sub of x and y: ");
            sub = double.Parse(Console.ReadLine());

            x = (sum - sub) / 2;
            y = sum - x;
            Console.WriteLine($"x la {x} va y la {y}");

            Console.Read();
        }
    }
}
