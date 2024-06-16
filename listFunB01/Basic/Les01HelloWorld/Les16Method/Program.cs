using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les16Method
{
    internal class Program
    {
        /// <summary>
        /// ham tinh tong cac so truyen vao
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        static int Tong(int x, int y, int z)
        {
            return x + y + z;
        }

        static int TinhGiaiThua(int n)
        {
            if (n > 0)
            {
                return n * (TinhGiaiThua(n - 1));

            }
            return 1;


        }

        //vi du method void

        static void XinChao(string m)
        {
            if (m.ToLower().Equals("nam"))
            {
                Console.WriteLine("Xin Chao ban Nam");
            }
            else
            {
                Console.WriteLine("Xin Chao ban Nu");

            }
        }

        // 7 . Truyền tham trị : không thay đổi giá trị biến sau khi gọi hàm
        static void ThamTri(int a)
        {
            a += 2;
                Console.WriteLine("Gia tri tham tri a trong ham: "+a);
        }

        /**
         * 8. Truyền tham chiếu (truyền tham biến) - ref :
         * // ref phải khởi tạo giá trị cho biến trước khi gọi hàm 
            //int b; // sẽ báo lỗi
         */
        static void ThamChieuRef(ref int b)
        {
            b += 2;
            Console.WriteLine("b trong ham la: " + b);
        }

        /**
         * 9 . Truyền tham chiếu (truyền tham biến) - out : 
            // out phải gán giá trị cho biến trước khi thoát khỏi hàm
         */
        static void ThamChieuOut(out int c)
        {
            c = 4;
            Console.WriteLine("b trong ham la: " + c);

        }

        static void Main(string[] args)
        {
            /*  int res = Tong(1, 2, 3);
              Console.WriteLine(res);*/

            /*int resGt = TinhGiaiThua(3);
            Console.WriteLine(resGt);*/

            /*  XinChao("nam");*/

            //Tham tri
            /*int a = 1;
            Console.WriteLine("Gia tri tham tri a truoc khi goi ham: " + a);
            ThamTri(a);
            Console.WriteLine("Gia tri tham tri a sau khi goi ham: " + a);*/

            //Tham chieu ref
            /* int b = 2;
             Console.WriteLine("Gia tri tham tri b truoc khi goi ham: " + b);
             ThamChieuRef(ref b);
             Console.WriteLine("Gia tri tham tri b sau khi goi ham: " + b);*/

            //Tham Chieu out
            int c;
            ThamChieuOut(out c);
            Console.WriteLine("Gia tri tham tri c sau khi goi ham: " + c);

            Console.Read();
        }
    }
}
