/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
*/

namespace Les01HelloWorld
{
    public class Program
    {
        // Constant á a fields
        /**
         * const: hang so la bien phai khoi tao gia tri ngay khi khoi tao bien va khong the thay doi gia tri cua hang
         */
        const double PI = 3.14;

        const int numOfWeek = 7;
        const string myBirthday = "2000-01-26";

        public static void Main(string[] args)
        {
            double radius = 10;

            Console.WriteLine(PI);
            Console.WriteLine(radius * radius * Math.PI);

            Console.ReadLine();
        }
    }
}