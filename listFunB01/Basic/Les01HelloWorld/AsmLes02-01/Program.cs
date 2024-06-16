using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmLes02_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b = 2;
            Console.WriteLine("Input a: ");
            a = int.Parse(Console.ReadLine());

            int res;
            a -= b +7;
            res = a;
            Console.WriteLine(res);
            Console.Read();
        }
    }
}
