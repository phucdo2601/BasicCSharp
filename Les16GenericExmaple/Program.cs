using System;

namespace Les16GenericExmaple
{
    /**
     * Generic là kiểu đại diện, nó cho phép tạo mã nguồn code không phụ thuộc vào kiểu dữ liệu cụ thể, chỉ khi code thực thi 
     * thì kiểu cụ thể mới xác định. Trước đây bạn đã quen với việc viết code trên những kiểu dữ liệu cụ thể như int, float, double ... 
     * hay các class do bạn định nghĩa, tuy nhiên có những giải thuật giống nhau trên những kiểu dữ liệu khác nhau, 
     * để tránh việc viết nhiều lần code lặp lại thì lúc này áp dụng Generic - kiểu đại diện để xây dựng phương thức hoặc lớp.
     */
    public class Program
    {
        static void Swap<T>(ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;

        }

        /*static void Swap(ref float x, ref float y)
        {
            float temp;
            temp = x;
            x = y;
            y = temp;

        }*/

        class Product<A>
        {
            A id;

            public void SetId (A id)
            {
                this.id = id;
            }

            public void PrintInfo()
            {
                Console.WriteLine($"ID = {this.id}");
            }
        }

        static void Main(string[] args)
        {
            /*int a = 5;
            int b = 45;

            Console.WriteLine($"a = {a}, b = {b}");
            Swap<int>(ref b, ref b);
            Console.WriteLine($"a = {a}, b = {b}");*/

            Product<int> sp1 = new Product<int> ();
            sp1.SetId(100);
            sp1.PrintInfo();

            Product<string> sp2 = new Product<string>();
            sp2.SetId("Id224324");
            sp2.PrintInfo();
        }
    }
}
