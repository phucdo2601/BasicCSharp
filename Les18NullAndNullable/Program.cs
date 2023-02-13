using System;

namespace Les18NullAndNullable
{
    internal class Program
    {
        /**
         * null là một giá trị cố định nó biểu thị không có đối tượng nào cả, có nghĩa là biến có giá trị null không có tham chiếu (trỏ) 
         * đến đối tượng nào (không có gì).

            null chỉ có thể gán được cho các biến kiểu tham chiếu (biến có kiểu dữ liệu là các lớp), không thể gán null cho những biến có 
        kiểu dữ liệu dạng tham trị như int, float, bool ...
         */

        /**
         * nullable: Nếu bạn muốn sử dụng các kiểu dữ liệu nguyên tố như int, float, double ... như là một kiểu dữ liệu dạng tham chiếu, 
         * có thể gán giá trị null cho nó, có thể sử dụng như đối tượng ... thì khai báo nó có khả năng nullable, khi biến nullable 
         * có giá trị thì đọc giá trị bằng truy cập thành viên .Value, cách làm như sau:

            Khi khai báo biến có khả năng nullable thì thêm vào ? sau kiểu dữ liệu
         */

        class A { }

        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");*/

            //khai bao bien null
            A a = null;

            //khai bao bien nullable
            int? age;
            age = null;

            age = 10;

            if (!age.HasValue)
            {
                Console.WriteLine("Bien age khong co gia tri");
            } else
            {
                Console.WriteLine($"Gia tri cua bien age la {age}");
            }

        }
    }
}
