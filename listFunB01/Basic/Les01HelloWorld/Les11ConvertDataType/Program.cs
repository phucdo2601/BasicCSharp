/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
*/

namespace Les11ConvertDataType
{
    public class Program
    {
        /**
         * Chuyển đổi từ kiểu dữ liệu lớn hơn sang kiểu dữ liệu nhỏ hơn
            double -> float -> long -> int -> char
        Trong thuc te thi nen dung TryParse cho an toan
         */
        public static void Main(string[] args)
        {
            string valueStr = "5.2";
            double result;
            bool isValid = double.TryParse(valueStr, out result);
            Console.WriteLine(isValid);
        }
    }
}