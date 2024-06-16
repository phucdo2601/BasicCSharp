using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les02_2Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Nhap vao so nguyen n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Ban vua nhap vao so: {0}", n);

            if (n % 2 != 0)
            {
                Console.WriteLine($"{n} la so le");
            } else
            {
                Console.WriteLine($"{n} la so chan");

            }

            Console.ReadLine();
        }
    }
}
