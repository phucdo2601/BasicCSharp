/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");*/

namespace Les01HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
             * Bien trong c#
             * Khi khong khai bao gia tri thi kieu so la 0, kieu string la null, kieu bool la false
             */
            /* int age = 23;
             float pi = 3.145676f;
             string name = "PDB";
             char at = '%';
             long bigNum = 12;
             bool isGpsEnable = false;*/

            /**
             * Kieu du lieu trong c#
             * Kiểu string
                -Kiểu string khác với các kiểu trên là kiểu dữ liệu tham chiếu dùng để lưu chuỗi ký tự văn bản. 
                -Nếu không gán giá trị thì mặc định giá trị của kiểu String sẽ là null
             */
            /* int age = 23;
             float pi = 3.145676f;
             string name = "PDB";
             char at = '%';
             long bigNum = 12;
             bool isGpsEnable = false;
             double myDouble = 1.9;
             decimal myDecimal = 234.12345M;*/

            /**
             * Les06: Thuc hanh kieu so
             */
            /*int num1 = 10;
            int num2 = 12;
            int sum = num2 + num1;
            Console.WriteLine("Sum of " + num1 + " + " + num2 + " = " + sum);
            float floatNum1 = 1.2f;
            float floatNum2 = 2.4f;
            float floatSum = floatNum1 + floatNum2;
            float floatDivision = floatNum1 / floatNum2;
            float floatMultiple = floatNum1 * floatNum2;
            Console.WriteLine("Sum of float nums: " + floatNum1 + " + " + floatNum2 + " = " + floatDivision);
            Console.WriteLine("Mul of float nums: " + floatNum1 + " * " + floatNum2 + " = " + floatMultiple);*/

            /**
             * Les07: Kieu String
             */
            /*string myName = " P D B  ";
            myName = myName.Trim().ToLower();

            var listCharNames = myName.Split(' ');
            Console.WriteLine(myName);
            Console.WriteLine(listCharNames);*/

            /**
             * Les09: Kieu tham tri va kieu tham chieu
                -Kiểu tham trị lưu trực tiếp dữ liệu trong bộ nhớ Stack
                -Kiểu tham chiếu chỉ lưu địa chỉ trong Stack còn giá trị biến nằm ở nơi khác (Heap)
             */

            Console.Read();
        }
    }
}
