using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les03LogicOperAndPrefixAndPostfix
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* bool kq;
            int a =9, b =10;
            kq = (a != b) && (a < 3);
            Console.WriteLine(kq);
            Console.Read();*/

            /**
             * Toan tu Prefix, Postfix(tien to, hau to):
             * a++, a--: Postfix
             * ++a, --a: Prefix
             * Uu tien tinh toan Prefix, Postfix
             *      Step 1: Prefix
             *      Step 2: Cac phep toan con lai
             *      Step 3: Gan Gia tri cho bien ben trai dau bang
             *      Step 4: Tinh Postfix
             */

            int x =1; int y = 2;
            int z = x++ - ++y + 1;
            Console.WriteLine("z = "+z);
            Console.WriteLine("y = "+y);
            Console.WriteLine("x = "+x);
            Console.Read();
        }
    }
}
