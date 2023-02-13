using System;

namespace Les19_VirtualMethodAndAbstractClass
{
    /**
     * Tính đa hình là một trong các đặc tính của lập trình hướng đối tượng, trong phần quá tải 
     * phương thức - nó đã thể hiện tính đa hình. Tính đa hình của nghĩa là có nhiều dạng, tính đa hình sẽ thể hiện rõ 
     * khi xây dựng các lớp kế thừa. Một phương thức được gọi, nó sẽ là phương thức cụ thể nào tùy thuộc vào đối tượng lúc nó thực thi.
     */
    /**
     * virtual method
     */
    //class Product
    //{
    //    public double Price { get; set; }

    //    /**
    //     * dinh nghia phuong thuc ao: phuong thuc do co the ghi de tu lop ke thua
    //     * de dinh nghia pt ao, sau khi khai bao xong phuong thuc, them tu khoa virtual truoc kieu du lieu tra ve
    //     */

    //    public virtual void ProductInfo()
    //    {
    //        Console.WriteLine($"Gia san pham {Price}");
    //    }

    //    public void Test () => ProductInfo();
    //}

    /**
     * abstract class: thi khong dc tao ra doi tuong
     */
    abstract class Product
    {
        public double Price { get; set; }

        /**
         * dinh nghia phuong thuc ao: phuong thuc do co the ghi de tu lop ke thua
         * de dinh nghia pt ao, sau khi khai bao xong phuong thuc, them tu khoa virtual truoc kieu du lieu tra ve
         */

        /*public virtual void ProductInfo()
        {
            Console.WriteLine($"Gia san pham {Price}");
        }*/

        /**
         * abstract method: phuong thuc truu tuong => pt nay chi co ten ma khong co phan than phuong thuc
         */
        public abstract void ProductInfo();

        public void Test() => ProductInfo();


    }

    /**
     * interface: Giao diện (interface) nó có ý nghĩa gần giống với lớp abstract. Chỉ có điều khai báo thì dùng từ khóa interface thay cho từ khóa 
     * class và điều quan trọng - tất cả các phương thức đều khai báo không có thân (chỉ có tên - nghĩa là phương thức abstract).. 
     * Lớp triển khai giao diện (lớp kế thừa) bắt buộc phải định nghĩa lại (không cần từ khóa overrid) tất cả các phương thức này, 
     * cũng có một điều khác là lớp kế thừa có thể kế thừa nhiều giao diện.
     */

    interface IHingHoc {
        public double TinhChuVi();
        public double TinhDienTich();
    }

    class HinhChuNhat : IHingHoc
    {
        public double A { get; set; }
        public double B { get; set; }

        public HinhChuNhat(double a, double b)
        {
            A = a;
            B = b;
        }
        public double TinhChuVi()
        {
            return (this.A + this.B) * 2;
        }

        public double TinhDienTich()
        {
            return this.A * this.B;
        }
    }

    class HinhTron : IHingHoc
    {
        public double R { get; set; }

        public HinhTron(double r)
        {
            this.R = r;
        }

        public double TinhChuVi()
        {
            return 2 * this.R * Math.PI;
        }

        public double TinhDienTich()
        {
            return this.R * this.R * Math.PI;

        }
    }

    #region trien khai nhieu giao dien trong c#, cach nhau boi dau phay
    /*class HinhTron : IHingHoc, IA1, IB1
    {
        public double R { get; set; }

        public HinhTron(double r)
        {
            this.R = r;
        }

        public double TinhChuVi()
        {
            return 2 * this.R * Math.PI;
        }

        public double TinhDienTich()
        {
            return this.R * this.R * Math.PI;

        }
    }*/

    #endregion


    class Iphone : Product
    {
        public Iphone() => Price = 500;

        public override void ProductInfo()
        {
            Console.WriteLine("Dien thoai Iphone");
            Console.WriteLine($"Gia san pham {Price}");
        }

        /* void Abc() => Console.WriteLine("fsdfsfs");

         int Sum(int a, int b) => a+ b;*/

        // override - nap chong phuong thuc(ghi de)
        /* public override void ProductInfo()
         {
             Console.WriteLine("Dien Thoai Iphone");
             // khi muon su dung lai phuong bi ghi de o lop cha, dung tu khoa base
             base.ProductInfo();
         }*/

    }

    public class Program
    {
        static void Main(string[] args)
        {
            /*Iphone i = new Iphone();
            i.Test();*/

            /*Iphone i = new Iphone();
            i.ProductInfo();*/

            /*HinhChuNhat h = new HinhChuNhat(4,5);
            Console.WriteLine($"Dien tich: {h.TinhDienTich()}, Chu vi: {h.TinhChuVi()} ");*/

            HinhTron ht = new HinhTron(3);
            Console.WriteLine($"Dien tich: {ht.TinhDienTich()}, Chu vi: {ht.TinhChuVi()} "); 

        }
    }
}
