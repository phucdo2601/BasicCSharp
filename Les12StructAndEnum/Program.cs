using System;

namespace Les12StructAndEnum
{
    public class Program
    {
        /**
         * Struct
         * kiểu dữ liệu cấu trúc (còn gọi là structure) - kiểu dữ liệu này tạo thành khi ta muốn gộp các dữ liệu có 
         * liên quan thành một nhóm (đóng gói dữ liệu). Để tạo ra kiểu dữ liệu cấu trúc dùng đến từ khóa struct với 
         * khai báo khá giống khai báo lớp, tuy nhiên struct là thuộc nhóm kiểu giá trị C# chứ không phải kiểu tham 
         * chiếu C# (Do đó, truyền tham số dùng struct là tham trị: xem thêm tham chiếu, tham trị C# ). 
         * Trong struct có thể chứa: trường dữ liệu, thuộc tính, phương thức khởi tạo, hằng số, các phương thức, toán tử, sự kiện.
         */
        #region struct: la kieu tham tri, con class la kieu tham chieu
        public class Product
        {
            /**
             * du lieu
             * phuong thuc
             * constructor
             */

            public string name;
            public double price;

            /**
             * Phuong thuc tao trong struct khai voi class
             * Phai xac dinh gia tri khoi tao trong phuong thuc tao cua struct
             */
            public Product(string name, double price)
            {
                this.name = name;
                this.price = price;
            }

            public string GetInfo()
            {
                return $"Ten san pham {this.name}, gia: {this.price}";
            }

            public string Info { get
                {
                    return $"{name} - {price}";
                }
                    set{ 
                    } }
        }
        #endregion

        /**
         * Kiểu liệt kê (enum) khai báo một tập hợp các hằng số có tên, mặc định giá trị các hằng số này 
         * là kiểu int và bắt đầu từ 0 trở đi trong khai báo kiểu liệt kê. Liệt kê (enum) thuộc dạng kiểu 
         * giá trị như struct. Để khai báo một kiểu liệt kê thì dùng từ khóa enum
         */
        #region enum

        /**
         * 0 -KEM
         * 1 -Trung Binh
         * 2 -Kha
         * 3 -Gioi
         */
        enum HOCLUC {
            Kem = 10,
            TrungBinh = 123,
            Kha =333,
            Gioi=999,
        }


        #endregion

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //    vd ve struct
            //    /*Product pr1;
            //    pr1.name = "Iphone";
            //    pr1.price = 10000;
            //    Console.WriteLine(pr1.GetInfo());*/

            //    vd ve class
            //    Product pr1 = new Product("", 0);
            //pr1.name = "Iphone";
            //    pr1.price = 10000;
            //    Console.WriteLine(pr1.GetInfo());



            //    Product pr2 = new Product("Nokia", 800);
            ///**
            //* struct la kieu tham tri, nen no sao chep tu phep gan gia tri, chu khong tham chieu de vi tri, no khong thay doi gia tri cua vung nho dc gan
            //* Doi voi class khi chung ta thuc hien phep gan, thi bie pr1 va bien pr2 cung tham chieu den 1 o nho, no thay doi gia tri cua vung nho dc gan
            //*/
            //pr2 = pr1;
            //    pr2.name = "Iphone X";
            //    Console.WriteLine(pr1.GetInfo());
            //    Console.WriteLine(pr2.GetInfo());
            //    Console.WriteLine(pr2.Info);

            HOCLUC hocluc;
            hocluc = HOCLUC.Kem;

            /*int num = (int) hocluc;
            Console.WriteLine(num);
             
             */

            hocluc = (HOCLUC)(333);

            switch (hocluc)
            {
                case HOCLUC.Kem:
                    Console.WriteLine("Học lực kém");
                    break;
                case HOCLUC.Kha:
                    Console.WriteLine("Học lực Kha");
                    break;
                case HOCLUC.Gioi:
                    Console.WriteLine("Học lực Giỏi");
                    break;
                default:
                    Console.WriteLine("Học lực TB");
                    break;

            }
        }
    }
}
