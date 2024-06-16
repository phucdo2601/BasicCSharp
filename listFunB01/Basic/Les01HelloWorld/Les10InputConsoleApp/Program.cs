/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");*/

namespace Les10InputConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
             * Vi du: Nhap tu ban phim kieu string 
             */
            string name;
            int testNum;
            string address;
            string ageStr;
            int age;
            string salaryExpectStr;
            decimal salaryExpect;

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Using Readline() - Enter your name: ");
            name = Console.ReadLine();

            

            Console.WriteLine("Input the age: ");
            ageStr = Console.ReadLine();

            age = Convert.ToInt32(ageStr);

            Console.WriteLine("Input the expectation salary: ");
            salaryExpectStr = Console.ReadLine();
            salaryExpect = Convert.ToDecimal(salaryExpectStr);
            Console.WriteLine("Using the Read() - Enter your test num: ");
            testNum = Console.Read();

            Console.WriteLine("Ascii value of testNum: {0}", testNum);

            Console.WriteLine("Yor name is " + name);
            Console.WriteLine("Yor age is {0}", age);
            Console.WriteLine($"Your expectation salary is {salaryExpect}");

            Console.Read();





        }
    }
}
