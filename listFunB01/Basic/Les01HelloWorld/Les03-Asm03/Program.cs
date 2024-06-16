using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les03_Asm03
{
    public class Program
    {
        static void Main(string[] args)
        {
            int year;
            Console.WriteLine("Input the check year: ");
            year = int.Parse(Console.ReadLine());

            if ((year % 400 == 0) || (year % 4 == 0 && year% 100 != 0))
            {
                Console.WriteLine("Nam nhuan");
            } else
            {
                Console.WriteLine("Nam Khong nhuan");
            }

            Console.ReadKey();
        }
    }
}
