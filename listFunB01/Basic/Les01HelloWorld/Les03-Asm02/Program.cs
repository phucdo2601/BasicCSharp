using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les03_Asm02
{
    public class Program
    {
        static void Main(string[] args)
        {
            double height;
            double weight;

            double BMI;
            Console.WriteLine("Input height: ");
            height = double.Parse(Console.ReadLine());

            Console.WriteLine("Input weight: ");
            weight = double.Parse(Console.ReadLine());

            BMI = weight / (Math.Pow(height, 2));

            Console.WriteLine("Chi so BMI cua ban la: ", BMI);

            if (BMI < 15)
            {
                Console.WriteLine("Than hinh gay");
            }
            else if (BMI >= 15 && BMI < 16)
            {
                Console.WriteLine("Than hinh hoi gay");

            }
            else if (BMI >= 18.5 && BMI < 25)
            {
                Console.WriteLine("Than hinh binh thuong");

            }
            else if (BMI >= 25 && BMI < 30)
            {
                Console.WriteLine("Than hinh hoi beo");

            }
            else if (BMI >= 30)
            {
                Console.WriteLine("Than hinh beo");

            }
            else if (BMI >= 35)
            {
                Console.WriteLine("Than hinh qua beo");

            }

            Console.Read();
        }
    }
}
