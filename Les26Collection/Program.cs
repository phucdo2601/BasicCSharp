using System;
using System.Collections.Generic;

namespace Les26Collection
{
    /**
     * Lớp List<T>
     * Lớp collection List là lớp triển khai các giao diện IList, ICollection, IEnumerable nó quản lý danh sách các đối tượng cùng kiểu. 
     * Bạn có thể thêm, bớt, truy cập, sắp xếp các phần tử trong danh sách bằng các phương thức nó cung cấp như Add, AddRange, Insert, RemoveAt, Remove ... các phương thức này chi tiết theo ví dụ dưới
     */
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ID { get; set; }
        public string Origin { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            #region List
            /*List<int> arr1= new List<int>() {45, 12, 1221, 45 };*/

            /*arr1.Add(1);
            arr1.Add(1);
            arr1.AddRange(new int[] {3,4,5,6,7});
            Console.WriteLine(arr1.Count);
            Console.WriteLine(arr1[2]);
            List<string> arr2= new List<string>();*/

            //chen vao vi tri chi dinh
            /*arr1.Insert(0, 10);*/

            // xoa phan tu o vi tri dc chi dinh
            /* arr1.RemoveAt(2);   */

            //xoa phan tu trong ds voi gia tri cua no - chi remove cai phan tu dau tien no bat dc
            /* arr1.Remove(45);*/

            /* arr1.InsertRange(0, new int[] { 78, 67, 45 });*/

            /* foreach (int i in arr1) {
                 Console.WriteLine(i);
             }*/

            /* List<int> list = new List<int>() { 7,8,9,5,6,9,0,1,2};
             var n = list.FindAll(x => x % 2 == 0);
             foreach (var x in n) {
                 Console.WriteLine(x);
             }*/

            /* List<Product> products = new List<Product>()
             {
                 new Product()
                 {
                     Name = "Iphone X",
                     Price= 10000,
                     Origin = "China",
                     ID = 1,
                 },
                 new Product()
                 {
                     Name = "phone-02",
                     Price= 23423,
                     Origin = "Japan",
                     ID = 2,
                 },
                 new Product()
                 {
                     Name = "phone-03",
                     Price= 3424,
                     Origin = "China",
                     ID = 3,
                 },
                 new Product()
                 {
                     Name = "phone-04",
                     Price= 42422,
                     Origin = "China",
                     ID = 4,
                 },
             };*/

            /* var p = products.Find(p => p.Origin.Trim().Equals("Japan"));
             if (p != null)
             {
                 Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
             }*/

            /* var p = products.FindAll(p => p.Price < 40000);
             foreach (var item in p)
             {
                 Console.WriteLine($"{item.Name} - {item.Price} - {item.Origin}");
             }*/

            /* foreach (var item in products)
             {
                 Console.WriteLine($"{item.Name} - {item.Price} - {item.Origin}");
             }

             products.Sort(

                 (p1, p2) => {
                     if (p1.Price < p2.Price)
                         return 1;
                     else if (p1.Price == p2.Price)
                         return 0;
                     return -1;
                 }
             );
             Console.WriteLine("--------------------------------------------");
             Console.WriteLine("Sap xep theo gia tu cao xuong thap");
             foreach (var item in products)
             {
                 Console.WriteLine($"{item.Name} - {item.Price} - {item.Origin}");
             }*/
            #endregion

            #region SortedList -Nếu tập dữ liệu của bạn được sắp xếp dựa trên một key (khóa), thì bạn có thể dùng đến SortedList<Tkey,TValue>. Lớp này sắp xếp dữ liệu dựa trên một key, kiểu đề làm key là bất kỳ.
            //SortedList<string, Product> products = new SortedList<string, Product>();
            //products["sp1"] = new Product()
            //{
            //    Name = "Iphone X",
            //    Price = 10000,
            //    Origin = "China",
            //    ID = 1,
            //};

            //products["sp2"] = new Product()
            //{
            //    Name = "Samsung G fold 4",
            //    Price = 63464,
            //    Origin = "China",
            //    ID = 1,
            //};

            //products.Add("sp3", new Product()
            //{
            //    Name = "phone-03",
            //    Price = 3424,
            //    Origin = "China",
            //    ID = 3,
            //});

            //var p = products["sp2"];
            //Console.WriteLine(p.Name);

            ///* var keys = products.Keys;
            // var values = products.Values;

            // foreach ( var key in keys )
            // {
            //     var product = products[key];
            //     Console.WriteLine(product.Name);
            // }*/

            //foreach (KeyValuePair<string, Product> item in products)
            //{
            //    var key = item.Key;
            //    var value = item.Value;
            //    Console.WriteLine($"Key: {key} - Name of Product: {value.Name}");
            //}


            #endregion

            #region queue FIFO: First in First out
            /* Queue<string> listDocs = new Queue<string>();
             listDocs.Enqueue("Ho So 1");
             listDocs.Enqueue("Ho So 2");
             listDocs.Enqueue("Ho So 3");

             //Dequeue --loai bo phan tu dau tien khoi danh sach
             var doc = listDocs.Dequeue();

             Console.WriteLine($"Xu ly cac ho so: {doc} - {listDocs.Count}");*/

            #endregion

            #region Stack LIFO - Last in First out
            /*  Stack<string> products = new Stack<string>();
              products.Push("pro-item-01");
              products.Push("pro-item-02");
              products.Push("pro-item-03");

              var proGet = products.Pop();
              Console.WriteLine($"Boc do mat hang {proGet}");

              proGet = products.Pop();
              Console.WriteLine($"Boc do mat hang {proGet}");

              proGet = products.Pop();
              Console.WriteLine($"Boc do mat hang {proGet}");*/

            #endregion

            /**
             * Danh sách liên kết là một danh sách chứa các phần tử, mỗi phần tử trong loại danh sách này được gọi là một nút (Node). 
             * Mỗi nút ngoài dữ liệu của nút đó, nó sẽ gồm hai biến - một biến tham chiếu đến Node phía trước, một nút tham chiếu đến nút phía sau.
             */
            #region LinkedListNode
            //LinkedList<string> listTutorials = new LinkedList<string>();
            //var tu1 = listTutorials.AddFirst("Bai hoc 1");
            //var tu3 = listTutorials.AddLast("Bai hoc 3");
            //LinkedListNode<string> tu2 = listTutorials.AddAfter(tu1, "Bai hoc 2");
            //listTutorials.AddLast("Bai hoc 4");
            //listTutorials.AddLast("Bai hoc 5");

            ///*foreach (var item in listTutorials)
            //{
            //    Console.WriteLine(item);
            //}*/

            ///* var node = tu2;
            // Console.WriteLine(node.Value);

            // node = node.Previous;
            // Console.WriteLine(node.Value);*/

            //var node = listTutorials.Last;
            //while (node != null)
            //{
            //    Console.WriteLine(node.Value);
            //    node = node.Previous;
            //}


            #endregion

            /**
             * Lớp Dictionary<Tkey,TValue> khá giống SortedList, Dictionary được thiết kế với mục đích tăng hiệu quả với tập dữ liệu lớn, phức tạp.

                Một đối tượng dữ liệu lưu vào Dictionary dưới dạng cặp key/value, truy cập đến phần tử thông qua key hoặc thông qua vị trí (index) 
                của dữ liệu trong danh sách. Chú ý, không cho phép trùng key.
             */
            #region Dictionary
            // Khởi tạo với 2 phần tử
            //Dictionary<string, int> sodem = new Dictionary<string, int>()
            //{
            //    ["one"] = 1,
            //    ["tow"] = 2,
            //};
            //// Thêm hoặc cập nhật
            //sodem["three"] = 3;
            //sodem.Add("four", 4);


            ///*var keys = sodem.Keys;
            //foreach (var k in keys)
            //{
            //    var value = sodem[k];
            //    Console.WriteLine($"{k} = {value}");
            //}*/

            //foreach (KeyValuePair<string, int> item in sodem)
            //{
            //    Console.WriteLine($"{item.Key} = {item.Value}");
            //}

            #endregion


            /**
             * HashSet là tập hợp danh sách không cho phép trùng giá trị. HashSet<T> khác với các collection khác là nó cung cấp cơ chế đơn giản 
             * nhất để lưu các giá trị, nó không chỉ mục thứ tự và các phần tử không sắp xếp theo thứ tự nào. HashSet<T> cung cấp hiệu năng cao 
             * cho các tác vụ tìm kiếm, thêm vào, xóa bỏ ...
             */
            #region HashSet
            HashSet<int> set1 = new HashSet<int>() { 1,2,3,4,5,6,7};
            HashSet<int> set2 = new HashSet<int>() { 8,9,7,2,20,3};

            /*set1.Add(11);
            set1.Remove(7);*/

            //lay cac phan tu khac nhau giua 2 tap hop
            /*set1.UnionWith(set2);*/

            //lay cac phan tu giong nhau giua 2 tap hop
            set1.IntersectWith(set2);

            foreach (var item in set1)
            {
                Console.WriteLine(item);
            }

            #endregion
        }
    }
}
