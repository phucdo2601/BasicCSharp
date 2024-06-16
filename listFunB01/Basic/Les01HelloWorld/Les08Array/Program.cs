using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les08Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int[] stt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };


            for (int i = 0; i < stt.Length; i++)
            {
                Console.Write(stt[i]+"\t");
            }*/

            //13 CopyTo (copy de gia tri vao mang da co)
            /* int[] mang10 = { 100, 200, 300, 400, 500 };
             int[] mang11 = { 1, 2, 3, 4, 5, 6, 7 };
             Console.WriteLine("Mang 11 truoc khi thay doi gia tri la:");
             foreach (int i in mang11) {
                 Console.Write(i+",\t");
             }


             mang10.CopyTo(mang11, 2);
             Console.WriteLine("Mang 11 sau khi thay doi gia tri la:");
             foreach (int i in mang11)
             {
                 Console.Write(i + ",\t");
             };
             Console.Read();*/

            //14 Copy(Array_nguon, Array_Goc, Int32) (Int32: So phan tu muon copy)
            /*int[] mang10 = { 100, 200, 300, 400, 500 };
            int[] mang11 = { 1, 2, 3, 4, 5, 6, 7 };
            Array.Copy(mang10, mang11, 3);
            foreach (int i in mang11) {
                Console.Write(i +",\t");
            }*/

            //15. Clone (tạo ra mảng mới trên vùng nhớ mới)
            int[] mang11 = { 1, 2, 3, 4, 5, 6, 7 };
            int[] mang12 = (int[]) mang11.Clone();
            foreach (int i in mang12) {
                Console.WriteLine(i+",\t");
            }


            Console.Read();
        }
    }
}
