using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Les15Dictionary
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;
            //1 Khai bao dic
            /*Dictionary<int, string> testDic1 = new Dictionary<int, string>();*/

            //2 Khoi tao dic co gia tri
            /*Dictionary<int, string> dic = new Dictionary<int, string>() { {1, "Obama" }, {2, "jackma" } };*/

            /* Dictionary<string, int> infoRe = new Dictionary<string, int>() { {"51h-21312",565675 }, { "52b-64544", 1233213} };*/

            //4 . add ( Thêm phần từ vào dic)
            /* Dictionary<string, int> infoRe = new Dictionary<string, int>() { { "51h-21312", 565675 }, { "52b-64544", 1233213 } };
             infoRe.Add("52R-2342432",324242 );
             infoRe.Add("52R-2342433",3343234 );*/

            //5. Duyệt dic ( xóa phần tử đầu tiên nếu tìm thấy trong list)
            /*Dictionary<string, int> infoRe = new Dictionary<string, int>() { { "51h-21312", 565675 }, { "52b-64544", 1233213 }, { "52R-2342432", 324242 } };
            foreach(KeyValuePair<string, int> kvp in infoRe)
            {
                Console.WriteLine(kvp.Key +"-"+kvp.Value);
            }*/

            /**
             * 6. dic.ContainsKey() 
             Kiểm tra xem 1 key có tồn tại trong dic hay không 
             //True : nếu có tồn tại 
             //False : nếu không tồn tại
             */
            /*Dictionary<int, string> infoRe = new Dictionary<int, string>() { { 1, "Test1"}, { 2, "Test2" }, { 3, "Test3" } };
            bool isExisted = infoRe.ContainsKey(1);
            Console.WriteLine(isExisted);*/

            /**
             * 7 . dic.ContainsValue() 
                Kiểm tra xem 1 Value có tồn tại trong dic hay không 
                 //True : nếu có tồn tại 
                 //False : nếu không tồn tại
             */
            /*Dictionary<int, string> infoRe = new Dictionary<int, string>() { { 1, "Test1" }, { 2, "Test2" }, { 3, "Test3" } };
            bool isExisted = infoRe.ContainsValue("PDN");
            Console.WriteLine(isExisted);*/

            /**
             *  8. dic[key] : lấy value từ key
             */
            /*Dictionary<int, string> infoRe = new Dictionary<int, string>() { { 1, "Test1" }, { 2, "Test2" }, { 3, "Test3" } };
            string test = infoRe[1];
            Console.WriteLine(test);*/

            // gan gia tri khac
            /*Dictionary<int, string> infoRe = new Dictionary<int, string>() { { 1, "Test1" }, { 2, "Test2" }, { 3, "Test3" } };
            infoRe[2] = "Phuc Do";
            Console.WriteLine(infoRe[2]);*/

            //9. dic.Remove(key); : Xóa phần tử theo key
            /*Dictionary<int, string> infoRe = new Dictionary<int, string>() { { 1, "Test1" }, { 2, "Test2" }, { 3, "Test3" } };
            infoRe.Remove(1);
            Console.WriteLine("Dictionary sau khi xoa la:");
            foreach(KeyValuePair<int, string> kvp in infoRe)
            {
                Console.WriteLine(kvp);
            }*/

            //10 . Dic.Clear() : Xóa toàn bộ phần tử
            /* Dictionary<int, string> infoRe = new Dictionary<int, string>() { { 1, "Test1" }, { 2, "Test2" }, { 3, "Test3" } };
             infoRe.Clear();
             Console.WriteLine("So phan tu cua dic sau khi clear: "+infoRe.Count());*/

            //11. Chuyển values dic => list
            /* Dictionary<int, string> infoRe = new Dictionary<int, string>() { { 1, "Test1" }, { 2, "Test2" }, { 3, "Test3" } };
             List<string> listVal = new List<string>();
             listVal = infoRe.Values.ToList();
             foreach (string val in listVal)
             {
                 Console.WriteLine(val);

             }*/

            //12. Chuyển Keys dic => list
            Dictionary<int, string> infoRe = new Dictionary<int, string>() { { 1, "Test1" }, { 2, "Test2" }, { 3, "Test3" } };
            List<int> listVal = new List<int>();
            listVal = infoRe.Keys.ToList();
            foreach (int val in listVal)
            {
                Console.WriteLine(val);

            }

            Console.Read();

        }
    }
}
