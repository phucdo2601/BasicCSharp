using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les14List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2 khoi tao 1 list
            /*List<string> arr1 = new List<string>(); //ds phan tu la string
            List<int> arr2 = new List<int>();*/

            // 3 Khoi tao List co san mot so phan tu
            /* List<int> arr1 = new List<int>() { 1,2,3,4,5,6};
             foreach(int i in arr1)
             {
                 Console.Write(i+ "\t");
             }
             Console.Read();*/

            //4. Phuong thuc Add(Them phan tu vao cuoi List)
            /*List<int> arr1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            arr1.Add(7);
            Console.WriteLine("Danh sach sau khi add la");
            foreach (int i in arr1)
            {
                Console.Write(i + "\t");
            }
            Console.Read();*/

            //5 Remove(object)
            /*List<int> arr1 = new List<int>() { 8, 1, 3, 1, 1, 6 };
            arr1.Remove(1);
            Console.WriteLine("Danh sach sau khi xoa la");
            foreach (int i in arr1)
            {
                Console.Write(i + "\t");
            }
            Console.Read();*/

            //6 Count: Dem so phan tu trong danh sach
            /*List<int> arr1 = new List<int>() { 8, 1, 3, 1, 1, 6 };
            Console.WriteLine(arr1.Count);
            Console.Read();*/

            //7 Clear: Xoa toan bo phan tu
            /* List<int> arr1 = new List<int>() { 8, 1, 3, 1, 1, 6 };
             arr1.Clear();
             Console.WriteLine(arr1.Count);*/


            //8 arr8.AddRange(arr9): Them toan bo arr9 vao cuoi arr8
            /*List<int> arr8 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> arr9 = new List<int>() { 100,200,600,400 };
            arr8.AddRange(arr9);
            Console.WriteLine("Danh sach 8 sau khi them ds 9");
            foreach (int i in arr8)
            {
                Console.Write(i + "\t");
            }*/

            /**
             * 9. bool <ds>.Contains(<value>) 
                * Kiểm tra có tồn tại value trong list không
                 * Có trả về true, không trả về False
             */
            /*List<int> arr10 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            bool isExisted = arr10.Contains(10);
            Console.WriteLine(isExisted);
            Console.Read();*/

            // 10 . GetRange(int index, int ount) -Trả về 1 list con, lấy từ index, và count ký tự của list nguồn
            /*List<int> arr10 = new List<int>() { 1, 2, 3, 4, 5, 6, 100, 200 };
            List<int> arr12 = arr10.GetRange(2, 4);
            Console.WriteLine("Danh sach moi sau khi GetRange la");
            foreach (int i in arr12)
            {
                Console.Write(i + "\t");
            }
            Console.Read();*/

            /**
             * 11. int IndexOf(<value>) 
                Trả về vị trí index giá trị tìm thấy, Nếu o thấy trả về -1
             */
            /*List<int> arr10 = new List<int>() { 1, 2, 3, 1, 5, 6, 100, 200 };
            int checkIndex = arr10.IndexOf(200);
            Console.WriteLine(checkIndex);*/

            /**
             * 12. Insert(int index, value); 
                Chèn thêm value vào vị trí index chỉ định
             */
            /*List<int> arr10 = new List<int>() { 1, 2, 3, 1, 5, 6, 100, 200 };
            arr10.Insert(3, 1000);
            Console.WriteLine("Danh sach 8 sau khi Insert vao vi ti ds 9");
            foreach (int i in arr10)
            {
                Console.Write(i + "\t");
            }*/

            /**
             * InsertRange(index, <danh sách chèn thêm>) 
                Chèn <danh sách chèn thêm> vào vị trí index của list gốc
             */
            /*List<int> arr10 = new List<int>() { 1, 2, 3, 4, 5, 6, 100, 200 };
            List<int> arr12 = new List<int>() { 21, 36, 45 };
            arr10.InsertRange(3, arr12);
            Console.WriteLine("Danh sach 10 sau khi InsertRange vao vi tri thu 3");
            foreach (int i in arr10)
            {
                Console.Write(i + "\t");
            }*/

            /**
             * 14. RemoveAt(int index); 
                Xóa phần tử tại vị trí index chỉ định
             */
            /*List<int> arr10 = new List<int>() { 1, 2, 3, 4, 5, 6, 100, 200 };
            arr10.RemoveAt(1);
            Console.WriteLine("Danh sach 10 sau khi RemoveAt vao vi tri thu 1");
            foreach (int i in arr10)
            {
                Console.Write(i + "\t");
            }*/

            /**
             * 15. RemoveRange(int index, int count) 
                Xóa từ index và xóa đi count phần tử
             */
            /*List<int> arr10 = new List<int>() { 1, 2, 3, 4, 5, 6, 100, 200 };
            arr10.RemoveRange(1, 3);
            Console.WriteLine("Danh sach 10 sau khi RemoveRange vao vi tri thu 1 voi 3 phan tu");
            foreach (int i in arr10)
            {
                Console.Write(i + "\t");
            }*/

            /**
             * 16 . <ds>.Reverse(); Đảo ngược danh sách
             */
            /*List<int> arr10 = new List<int>() { 1, 2, 3, 4, 5, 6, 100, 200 };
            arr10.Reverse();
            Console.WriteLine("Danh sach 10 sau khi Reverse");
            foreach (int i in arr10)
            {
                Console.Write(i + "\t");
            }*/

            /**
             * 17. <ds>.Sort(); Sắp xếp tăng dần
             */
            /*List<int> arr10 = new List<int>() { 100, 2, 3, 4, 5, 6, 100, 200 };
            arr10.Sort();
            Console.WriteLine("Danh sach 10 sau khi Sort");
            foreach (int i in arr10)
            {
                Console.Write(i + "\t");
            }*/

            /**
             * 18. BinarySearch
             */
            /*List<int> arr10 = new List<int>() { 111, 2, 3, 4, 5, 6, 100, 200 };
            arr10.Sort();
            int res = arr10.BinarySearch(6);
            Console.WriteLine(res);*/

            /**
             * 19. Tìm max, min
             */
            List<int> arr10 = new List<int>() { 111, 2, 3, 4, 5, 6, 100, 200 };
            Console.WriteLine("Gia tri lon nhat cua mang la {0}", arr10.Max());
            Console.WriteLine("Gia tri lon nhat cua mang la {0}", arr10.Min());

            Console.Read();
        }
    }
}
