using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les07String01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //KHAI BAO NGUYEN VAN
            /* string textDi2 = @"D:\TuHocLapTrinh\angular";
             string textDi3 = "\"Hi anh em\"";
             string textDi4 = "\"Hi anh em:\n Phuc\"";
             Console.WriteLine(textDi4);*/

            /*    string testDig8 = "XinChao";
                char[] lst = testDig8.ToCharArray();
                Console.WriteLine(lst);
                Console.WriteLine(testDig8.Length);
                Console.WriteLine("Ki thu tu nhat cua chuoi {0} la {1}", testDig8, testDig8[0]);*/

            /*string text;
            Console.WriteLine("Input the text digit: ");
            text= Console.ReadLine();
            int countLower = 0;
            int countUpper = 0;
            int countNum = 0;
            int countBlank = 0;

            char[] arrChar = text.Trim().ToCharArray();
            foreach (char c in arrChar)
            {
                if (char.IsLower(c))
                {
                    countLower++;
                } else if (char.IsUpper(c))
                {
                    countUpper++;
                } else if (char.IsDigit(c)) {
                    countNum++;
                } else if(char.IsWhiteSpace(c))
                {
                    countBlank++;
                }

            }
            Console.WriteLine("Chuoi {0} co {1} ky tu thuong: ", text, countLower);
            Console.WriteLine("Chuoi {0} co {1} ky tu hoa: ", text, countUpper);
            Console.WriteLine("Chuoi {0} co {1} ky tu so: ", text, countNum);
            Console.WriteLine("Chuoi {0} co {1} ky tu khoang trang: ", text, countBlank);*/

            /*string textDi1 = "121";
            string textDi2 = "121";
            Console.WriteLine(textDi1.CompareTo(textDi2));*/

            //copyto
            /*string testDi14 = "123456";
            char[] t2 = new char[6];
            t2[0] = 'a';
            t2[1] = 'n';
            testDi14.CopyTo(1, t2, 2, 4);
            Console.WriteLine(t2);*/

            //EndsWith
            /*string testDi1 = "thuCuoi.mp3";
            bool isMp3 = testDi1.Trim().EndsWith(".mp3")? true : false;
            Console.WriteLine(isMp3);*/

            /* int n = 14;
             string testDi1 = string.Format("n = {0} va can bac 2 cua n la {1}", n, Math.Sqrt(n));

             Console.WriteLine(testDi1); */


            //Insert
            /* string testDi1 = "123";
             string testDi2 = "Obama";
             testDi1 = testDi1.Insert(3, testDi2);
             Console.WriteLine(testDi1);*/

            //IndexOf
            /* string testDi = "123asssssas";
             int kq4 = testDi.Trim().LastIndexOf('a');
             Console.WriteLine(kq4);*/

            /* string testDi1 = "123456";
             Console.WriteLine(testDi1);

             testDi1 = testDi1.Remove(1, 2);
             Console.WriteLine(testDi1);*/

            //replace
            /*string testDi = "12345678987654";
            Console.WriteLine(testDi);
            testDi = testDi.Replace("45", "99");
            Console.WriteLine(testDi);*/

            //Substring
            string testDi1 = "12122343434";
            Console.WriteLine(testDi1);

            string testDi2 = testDi1.Substring(1, 4);
            Console.WriteLine(testDi2);


            Console.Read();
        }
    }
}
