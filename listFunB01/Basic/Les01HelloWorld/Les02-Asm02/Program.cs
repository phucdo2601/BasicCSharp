using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les02_Asm02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r;
            Console.WriteLine("Input radius: ");
            r = double.Parse(Console.ReadLine());
            double s, v;
            s = r * r;
            v = r * 2 * 3.14;
            Console.WriteLine($"Chu vi va dien tich hinh tron voi ban kinh la {r}: {v} & {s}");

            Console.Read();
        }
    }
}
