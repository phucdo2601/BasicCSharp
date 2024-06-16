using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les05_WhileAndDoWhileLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;


            //while loop
            /*while (x <= 5)
            {
                Console.WriteLine(x);
                x++;
            }*/
            /*Console.WriteLine("Input n: ");
            x = int.Parse(Console.ReadLine());
            while (x< 1 || x> 100)
            {
                Console.WriteLine("Vui long nhap lai(khoang so tu 1-99): ");
                x = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"So ban vua nhap la {x}");

            Console.Read();*/

            //do...while loop
            /* int a = 1;
             int sum = 0;

             do
             {
                 sum += a;
                 a++;
             } while (a < 5);
             Console.WriteLine("Tong tu 1 den 5 la: {0}", sum);
             Console.Read();*/

            //while(true)
            int n = 0;
            while (true)
            {
                n++;
                Console.WriteLine("n= "+n);
                if (n == 10)
                {
                    break;
                }
            }
            Console.Read();
        }
    }
}
