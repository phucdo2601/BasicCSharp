using System;

namespace Les14_Inheritance
{
    /**
     * Kế thừa là một trong 4 khía cạnh của lập trình hướng đối tượng, nó là khả năng cho phép chúng ta định nghĩa 
     * ra một lớp mới dựa trên một lớp khác có sẵn, kế thừa giúp cho việc mở rộng code - bảo trì trở nên dễ hơn.
     * 
     * Lớp cơ sở là lớp mà được lớp khác kế thừa.
        Lớp kế thừa là lớp kế thừa lại các thuộc tính, phương thức từ lớp cơ sở.
        B ke thua A
        A - la lop co so, lop cha
        B - la lop ke thua, lop con
        
        class B : class A{
        }

        de mot lop khong bi ke thua boi mot lop nao khac thi them tu khoa sealed

     */

    public sealed class TestAn
    {


    }

    public class Animal
    {
        public int Legs { get; set; }
        public float Weight { get; set; }

        public Animal() 
        {
            Console.WriteLine("Khoi tao class Animal");
        }

        public Animal(string abc)
        {
            Console.WriteLine($"Khoi tao class Animal (2) - {abc}");
        }

        public void ShowLeg()
        {
            Console.WriteLine($"Legs: {Legs}");
        }
    }

    public class Cat :Animal
    {
        public string Food { get; set; }

        public Cat(string s) : base(s)
        {
            this.Legs = 4;
            this.Food = "Chuot";
            Console.WriteLine("Khoi tao class CAT");


        }

        public void Eat()
        {
            Console.WriteLine(Food);
        } 

        /**
         * khai bao lai mot phuong thuc tu lop cha; them tu khoa new
         */
        public new void ShowLeg()
        {
            Console.WriteLine($"Loai meo co so chan la ${this.Legs}");
        }

        public void ShowInfo()
        {
            /**
             * su dung lai phuong thuc tu lop cha
             */
            base.ShowLeg();
            ShowLeg();
        }

    }

    class A { }

    class B :A { } 
    class C : B { } 

    /**
     * A -> B -> C
     */

    public class Program
    {
        static void Main(string[] args)
        {
            /*Cat c = new Cat("Abc Xryr");
            c.ShowLeg();
            c.Eat();
            c.ShowInfo();*/

            A a;
            B b;
            C c;

            b = new B();
            c = new C();

            a = b;
            a = c;

            b = c;

            // b gan cho c se co loi, boi vi lop chan khong then gan cho lop con
           /* c = b;*/
        }
    }
}
