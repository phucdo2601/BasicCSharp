
using System;

namespace Les20Delegate
{
    /**
     * Delegate (hàm ủy quyền) là một kiểu dữ liệu, nó dùng để tham chiếu (trỏ đến) đến các hàm (phương thức) 
     * có tham số và kiểu trả về phù hợp với khai báo kiểu. Khi dùng đến delegate bạn có thể gán vào nó một, 
     * nhiều hàm (phương thức) có sự tương thích về tham số, kiểu trả về, sau đó dùng nó để gọi hàm (giống con trỏ trong C++), 
     * các event trong C# chính là các hàm được gọi thông qua delegate, bạn cũng có thể dùng delegate để xây dựng các 
     * hàm callback, đặc biệt là các Event
     */

    /**
     * khai bao kieu delegate thuong khong co than phuong thuc
     */ 
    public delegate void ShowLog(string mess);

    public class Program
    {
        static void Info(string s)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /*delegate int KIEU1();*/

        static int Tong(int a, int b) => a + b;
        static int Hieu(int a, int b) => a - b;

        static void Tong2(int a, int b, ShowLog log)
        {
            int kq = a + b;
            log?.Invoke($"Tong la {kq}");
        }
        static void Hieu2(int a, int b, ShowLog log)
        {
            int kq = a - b;
            log?.Invoke($"Tong la {kq}");
        }

        static void Main(string[] args)
        {
            ShowLog log = null;

            /* log = Info;*/

            //kiem tra bien delegate khac null
            /*if (log != null)
            {
                //thi han bien delegate -c1;
                log("Xin Chao");
            }*/

            //thi han bien delegate -c1;
            /* log("Xin Chao");*/

            // c2 - thi hanh bien delegate, ?: kiem tra khac null 
            /*log?.Invoke("Xin chao ABC");

            log = Warning;
            log?.Invoke("Xin chao PhucDo");*/

            #region bien delegate co them tham chieu den nhieu phuong thuc

            /**
             * cach bien nhu the nay, bien log se tham chieu den 2 method  Info, Warning;
             * No se chay tuan tu 2 phuong thuc giong nhu thu tu khai bao
             */
            /*  log += Info;
              log += Info;
              log += Info;
              log += Warning;
              log += Warning;
              log += Info;

              log?.Invoke("Xin chao PhucDo");*/
            #endregion

            #region Action, Func: delegate - generic

            /**
             * Action
             */
            /*Action action; // khi khai bao nhu the nay se tuong duong bien deletegate coi kieu tra ve la Void: ~ delegate void Kieu()
            Action<string, int> action1; // ~ delegate void Kieu(string s, int i);

            Action<string> action2; // ~delegate void Kieu(string s)
            action2 = Warning; // gan dc boi vi 2 phuong thuc deu co cach truyen tham so vao tuong dong
            action2 += Info;

            action2?.Invoke("Thong tu Action2");*/

            /**
             * Func: Tuong tu Action nhung phai co kieu tra ve
             */
            //Func<int> f1; // ~ delegate int Kieu();
            /**
             * // ~ delegate string Kieu(string, double); : so kieu du lieu tra ve cuoi cung thi ta co kieu tra ve cua delegate
             * con tham so truyen vao thi lay tuan tu tu dau den vi tri n - 1 (voi n la so kieu du lieu truyen vao)
             */
            // Func<string, double, string> f2; // ~ delegate string Kieu(string, double);

            /**
             * Khai bao mot bien delegate co the gan cho Method Tong, Hieu
             */

            /* Func<int, int, int> tinhToan; // ~ delegate int Kieu(int a, int b);
             int a = 5;
             int b = 15;

             tinhToan = Tong;

             Console.WriteLine($"Tong {tinhToan(b, a)}");
             tinhToan = Hieu;

             Console.WriteLine($"Hieu {tinhToan(b, a)}");*/

            #endregion


            #region Sử dụng Delegate làm tham số hàm
            //truyen vao null ti khong xuat ra gi
            Tong2(9, 4, null);
            // truyen vao doi so thi se xuat nhu doi so dc cau hinh 
            Tong2(9, 4, Info);

            #endregion
        }
    }
}
