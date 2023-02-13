using System;

namespace Les10ClassAndOOP
{
    class Student : IDisposable
    {
        public string name;

        public Student(string name)
        {
            this.name = name;
            Console.WriteLine("Khoi tao "+this.name);
        }

        ~Student()
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Destructor of Student(Phuong thuc huy cua Student)");
            Console.ResetColor();
        }

        public void Dispose()
        {
            //phuong thuc giai phong tai nguyen dang vi chiem du, hoac dong chuoi ket noi
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Get memory of Student(Phuong thuc huy cua Student) by Dispose method");
            Console.ResetColor();
        }
    }

    public class Program
    {

        static void Test()
        {
            using Student st = new Student("Ten sinh vien of test mt");
        }
        static void Main(string[] args)
        {
            /*Weapon wp1; // bien nay vua doi khoi tao; khong cho vo mot gia nao ca ne gia cua no la null

            wp1 = new Weapon();*/

            /* Weapon wp2 = new Weapon("Xin Chao dt 2");
             wp2.name = "Sung luc";
             Console.WriteLine(wp2.name);
             wp2.SetDoSatThuong(5);
             wp2.TanCong();*/

            /*Weapon vk3 = new Weapon("Sung may", 15);
            vk3.TanCong();
            vk3.SatThuong = 600;
            Console.WriteLine(vk3.SatThuong);
            vk3.NoiSanXuat = "America";
            Console.WriteLine(vk3.NoiSanXuat);*/

            /*Student st;
            for (int i = 0;i < 100000; i++) {
                st = new Student("Sinh Vien thu "+i);
                st = null;

            }*/

            //.net core : ep thu hoi bo nho ngay lap tuc bi bo, do dotnet quyet dinh
            /*GC.Collect();*/

            /*            using (Student st = new Student("Ten Sinh Vien"))
                        {
                            // code se thi hanh trong using nay
                            // ngoai pham vi khoi nay thi se bi thu hoi vung nho
                        }*/


            Test();

        }
    }
}
