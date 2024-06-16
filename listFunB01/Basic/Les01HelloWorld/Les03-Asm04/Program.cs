
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les03_Asm04
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*int month;
            int year;
            int day;
            Console.WriteLine("Input the month for finding day: ");
            month = int.Parse(Console.ReadLine());

            if (month == 2)
            {
                Console.WriteLine("Input the year for finding day: ");
                year = int.Parse(Console.ReadLine());
                if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
                {
                    day = 29;
                    Console.WriteLine($"The num day of {month} is {day}");
                } 
                else
                {
                    day = 28;
                    Console.WriteLine($"The num day of {month} is {day}");

                }
            }
            else
            {
                day = 28;
                Console.WriteLine($"The num day of {month} is {day}");
            }*/
            //Them dong nay de chuong trinh xuat ra tieng viet
            Console.OutputEncoding = Encoding.UTF8;

            int n;
            Console.WriteLine("Moi nhap vao so diem n");
            n = int.Parse(Console.ReadLine());

            string ans = (n >= 8) ? "Giỏi" : ((n >= 6.5 && n < 8) ? "Khá" : ((n<6.5 && n>= 5) ? "Trùng Bình" : "Yếu" ) ); 
            Console.WriteLine(ans);
    
            Console.ReadLine();
        }
    }
}
