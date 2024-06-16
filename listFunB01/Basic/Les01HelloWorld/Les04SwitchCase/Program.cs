using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les04SwitchCase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            /* int a;
             Console.ForegroundColor= ConsoleColor.Green;
             Console.WriteLine("Input num a: ");
             a = int.Parse(Console.ReadLine());

             int div = a % 2;

             Console.ForegroundColor= ConsoleColor.Green;
             Console.BackgroundColor= ConsoleColor.Red;
             switch (div)
             {
                 case 0:
                     Console.WriteLine("{0} la So Chan", a);
                     goto case 1;

                 case 1:
                     Console.WriteLine("{0} la So Le", a);
                     break;
             }*/

            int choice;

            Console.WriteLine("CHƯƠNG TRÌNH TÌM KIẾM");
            Console.WriteLine("1. Tim Theo Tên");
            Console.WriteLine("2. Tim Theo tác giả");
            Console.WriteLine("3. Tim Theo nhà xuất bản");
            Console.WriteLine("4. Tim Theo Tiêu đề");
            Console.WriteLine("bấm phím để tìm kiếm");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Read();
                throw;
            }

            switch (choice) 
            {
                case 1:
                    Console.WriteLine("Tim Theo Tên");
                    break;
                case 2:
                    Console.WriteLine("Tim Theo tác giả");
                    break;
                case 3:
                    Console.WriteLine("Tim Theo nhà xuất bản");
                    break;
                case 4:
                    Console.WriteLine("Tim Theo tiêu đề");
                    break;
                default:
                    break;
            }



            Console.Read();

        }
    }
}
