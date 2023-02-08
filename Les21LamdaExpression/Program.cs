using System;
using System.Linq;

namespace Les21LamdaExpression
{
    /**
     * Biểu thức lambda còn gọi là biểu thức hàm nặc danh (Anonymous), một biểu thức khai báo giống phương thức (hàm) 
     * nhưng thiếu tên. Cú pháp để khai báo biểu thức lambda là sử dụng toán dử => như sau: 
     * 
     * phai gan bieu lamda cho mot bien 
     * 
     * KHAI BAO BIEU THUC LAMDA
     * 1/ (int a, int b) => bieu_thuc;
     *  2/ (thamSo) => {
     *      cac_bieu_thuc;
     *      return bieu_thuc_trave;
     *  }
     */

    internal class Program
    {
       

        static void Main(string[] args)
        {
            /*Action<String> thongBao;
            thongBao = (string s) => Console.WriteLine(s); // ~ delegate void Kieu(string s) = Action<string>
            for (int i = 0; i < 10; i++)
            {

                thongBao?.Invoke("Xin Chao Lamda Expression!");
            }*/

            /**
             * Kieu delegate ko co kieu tra ve, va ko co tham so dau vao
             */
            /*Action thongBao1;
            thongBao1 = () => Console.WriteLine("Xin Chao cac ban");

            thongBao1?.Invoke();*/

            /*Action<string> welcome;
            welcome = (s) => Console.WriteLine(s);

            welcome?.Invoke("Hello World!");*/

            /*Action<string, string> welcome;
            welcome = (string mgs, string name) => Console.WriteLine(mgs +" "+ name);
            welcome?.Invoke("Hello World!", "Phuc Do");*/
            /*(int a, int b) => {
                int kq = a+b;
                return  kq;
                }*/

            #region co nhieu chi thi lenh trong bt lamda
            /*Action<string, string> welcome;
            welcome = (string mgs, string name) => {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(mgs +" "+ name);
                Console.ResetColor();
            };
            welcome?.Invoke("Hello World!", "Phuc Do");*/

            //phuong thuc lamda co kieu dl tra ve
            /* Func<int, int, int> tinhToan;
             tinhToan = (int a, int b) =>
             {
                 int kq = a + b;
                 return kq;
             };
             Console.WriteLine(tinhToan?.Invoke(15, 5));*/



            #endregion


            #region Su dung lamda cho mot so thu vien
            int[] arr = { 2, 4, 16, 25, 36, 49, 64, 81, 99 };
            /*var kq = arr.Select((int x) =>
            {
                return Math.Sqrt(x);
            });

            foreach (var item in kq)
            {
                Console.WriteLine(item);
            }*/

            /* arr.ToList().ForEach((int x) =>
             {
                 if (x % 2 != 0)
                 {
                     Console.WriteLine(x);
                 }
             });*/

            /*arr.Where(x =>
            {
                return x % 4 == 0;
            }).ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });*/

            arr.Where(x => x >= 10 && x <= 50).ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });

            #endregion
        }
    }
}
