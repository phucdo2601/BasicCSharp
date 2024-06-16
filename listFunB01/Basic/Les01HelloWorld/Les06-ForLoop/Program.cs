using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les06_ForLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;
            /*  int x = 0;
              for (int i = 0; i <= 10; i +=2)
              {
                  Console.WriteLine(i);
              }
              Console.Read();*/

            //tinh tong so tu 1 den 5, khong bao gom 3
            //continue
            //int sum = 0;
            /*for (int i = 1; i <= 5; i++)
            {
                if (i == 3)
                {
                    continue;
                }
                Console.WriteLine("i="+i);

                sum += i;
            }*/

            /* for (int i = 1; i <= 5; i++)
             {
                 if (i == 3)
                 {
                     break;
                 }
                 Console.WriteLine("i=" + i);

                 sum += i;
             }*/

            /* int n;
             int result =1;
             Console.WriteLine("Mời nhập vào số nguyên n: ");
             n = int.Parse(Console.ReadLine());
             int m = n;
             *//*for(int i = 1; i <= n; i++)
             {
                 result *= i;
             }*//*

             while (n > 0)
             {
                 result *= n;
                 n--;
             }

             Console.WriteLine("Kết quả {0}! = {1}", m, result);*/

            /*int n;
            int result = 0;
            Console.WriteLine("Mời nhập vào số nguyên n: ");
            n = int.Parse(Console.ReadLine());
            if (n % 2 == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    result += i;
                }
                Console.WriteLine("Ket qua la: "+result);

            }
            else
            {
                Console.WriteLine("tôi o tính tổng số lẻ, bye bye");
            }
            */

            /*int n;
            int result = 0;
            Console.WriteLine("Mời nhập vào số nguyên n: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                if (i % 2 != 0)
                {
                    if(i == 3)
                    {
                        continue;
                    }
                    result += i;
                }

            }
            Console.WriteLine("Ket qua la: " + result);*/

            //15
            /* for (int i = 10; i <= 50; i++)
             {
                 if (i % 3 == 0)
                 {
                     Console.Write("x = {0}, ", i);
                 }
             }*/

            //16
            /* int sum = 0;
             int subSum = 1;
             for (int i = 1; i <= 10; i++)
             {
                 subSum = subSum * i;
                 Console.WriteLine(subSum);
                 sum += subSum;
             }
             Console.WriteLine(sum);*/


            /**
             * Tim nhung so hoan thien tu 1 - 1000
             * 6 = 1 + 2 + 3
             */
            /* int n;
             int result = 0;
             Console.WriteLine("Mời nhập vào số nguyên n: ");
             n = int.Parse(Console.ReadLine());
             for (int i = 1; i < n; i++)
             {
                 if (n % i == 0)
                 {
                     result += i;
                 }

             }
             if (result == n)
             {
                 Console.WriteLine("{0} la so hoan hao", n);
             } else
             {
                 Console.WriteLine("{0} khong la so hoan hao", n);

             }*/

            /* for (int n = 1; n <= 1000; n++)
             {
                 int result = 0;
                 for (int i = 1; i < n; i++)
                 {
                     if (n % i == 0)
                     {
                         result += i;
                     }

                 }
                 if (result == n)
                 {
                     Console.WriteLine("{0} la so hoan hao", n);
                 }

             }*/

            /* int a;
             bool flag = false;
             int count = 0;
             string choice;


             while(flag == false)
             {
                 Console.WriteLine("Mời nhập vào số nguyên n: ");
                 a = int.Parse(Console.ReadLine());
                 while (a < 0)
                 {
                     Console.WriteLine("Mời nhập lại vào số nguyên n lớn hơn 0: ");
                     a = int.Parse(Console.ReadLine());
                 }

                 for (int i = 1; i <= a; i++)
                 {
                     if (a % i == 0)
                     {
                         count++;
                         Console.WriteLine("Num count:" + count);
                     }



                 }
                 if (count == 2)
                 {
                     Console.WriteLine("{0} la so nguyen to", a);

                 }
                 else
                 {
                     Console.WriteLine("{0} khong la so nguyen to", a);

                 }

                 Console.WriteLine("Do you want to conitnue the application?(YES OR NO)");
                 choice = Console.ReadLine();
                 if (choice.ToUpper().Equals("YES"))
                 {
                     flag = false;
                 } else
                 {
                     flag = true;
                 }

             }
                 Console.Read();*/

            /*  Console.WriteLine(Math.PI.GetType().ToString());*/

            //Random
            /* Random rd = new Random(); 
             int numRan = rd.Next(50, 101);//50 -100
             Console.WriteLine("So int ngau nhien: {0}", numRan);

             // muon lay so nguyen co phan thap phan ngau nhien
             double k2 = rd.NextDouble();
             Console.WriteLine("So double ngau nhien: {0}",k2);
             Console.Read();*/

            /*DateTime myBirthday = new DateTime(2000, 01, 26);
            Console.WriteLine(myBirthday.ToString("dd/MM/yyyy"));
*/
            DateTime birthday2 = DateTime.Parse("01/11/2000");
            Console.WriteLine(birthday2.ToString("dd/MM/yyyy"));
            Console.Read();
        }
    }
}
