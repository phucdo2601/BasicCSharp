using Les30LinqInCSharp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Les30LinqInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var brands = new List<Brand>()
            {
    new Brand{ID = 1, Name = "Công ty AAA"},
    new Brand{ID = 2, Name = "Công ty BBB"},
    new Brand{ID = 4, Name = "Công ty CCC"},
};

            var products = new List<Product>()
{
    new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
    new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
    new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
    new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
    new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
    new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
    new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
};

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //lay gia pham gia 400
            /* var query = from p in products
                         where p.Price == 400
                         select p;
             foreach (var item in query)
             {
                 System.Console.WriteLine(item);
             }*/
            #region Select trong Linq
            /*var kq = products.Select(
                p =>
                {
                    return new {
                        Name = p.Name,
                        Price = p.Price,
                    };
                }
                );
            foreach (var item in kq)
            {
                System.Console.WriteLine(item);
            }*/

            #endregion

            #region Where trong Ling

            /* var kq = products.Where(
                 p =>
                 {
                     return p.Name.Contains("tr");
                 }
                 );
             foreach (var item in kq)
             {
                 System.Console.WriteLine(item);
             }*/

            /*var kq = products.Where(
                p => p.Price >= 200 && p.Price <= 300
                );

            foreach (var item in kq)
            {
                System.Console.WriteLine(item);
            }*/
            #endregion

            #region Select many

            /*var kq = products.SelectMany(
                p => p.Colors
                );
            foreach (var item in kq)
            {
                System.Console.WriteLine(item);
            }*/
            #endregion

            #region Min, Max Sum
            /*Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());*/

            /*Console.WriteLine(numbers.Where(p => p % 2 != 0).Average());*/

            /*Console.WriteLine(products.Average(p => p.Price));*/

            #endregion

            #region Join in Linq => lay cac du lieu don le tu cac bang khac
            /*var kq = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
            {
                return new
                {
                    ProductName = p.Name,
                    BrandName = b.Name,
                };
            });

            foreach (var item in kq)
            {
                Console.WriteLine(item);
            }*/

            #endregion

            #region GroupJoin Linq => Lay group cac du lieu lien quan tu cac bang khac
            /*var kq = brands.GroupJoin(products, b => b.ID, p => p.Brand, (brand, pros) =>
            {
                return new
                {   
                    BrandId = brand.ID,
                    ListProduct = pros,

                };
            });

            foreach (var item in kq)
            {
                Console.WriteLine(item.BrandId);
                foreach (var pro in item.ListProduct)
                {
                    Console.WriteLine(pro);
                }
            }*/


            #endregion

            #region Take(n) - lay ra n so luong phan tu dau tien
            /* products.Take(4).ToList().ForEach(p => Console.WriteLine(p));*/

            #endregion

            #region Skip(n) - bo qua n phan tu dau tien
            /*products.Skip(2).ToList().ForEach(p => Console.WriteLine(p));*/

            #endregion

            #region OrderBy (tang dan) / OrderByDescending (giam dan)

            /*products.OrderByDescending(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));*/

            #endregion

            #region Reverse
            /*numbers.Reverse().ToList().ForEach(n => Console.WriteLine(n));*/


            #endregion

            #region GroupBy - nhom san pham theo mot gia tri cho truoc
            /*var kq = products.GroupBy(p => p.Price);
            foreach (var group in kq)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }
            }*/

            #endregion

            #region Distinct lay ra ca phan tu duy nhat
            /* products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(m => Console.WriteLine(m));*/


            #endregion

            #region Single/ SingleOrDefault. Nen su dung SingleOrDefault, trong truong hop no khong tim thay thi no se tra ve kq la null
            /*var kq = products.SingleOrDefault(p => p.Price == 400);
            Console.WriteLine(kq);*/

            #endregion

            #region Any => phương thức Any() trả về boolean và nó sẽ trả về kết quả ngay khi gặp phần tử đầu tiên thỏa mãn điều kiện khi duyệt qua các phần tử của List<T>
            /*var p = products.Any(p => p.Price == 400);
            Console.WriteLine(p);
*/
            #endregion

            #region kiem tra tat ca co thao man dk da cho hay khong
            /*var p = products.All(p => p.Price >= 300);
            Console.WriteLine(p);*/

            #endregion

            #region Count
            /*var p = products.Count(p => p.Price == 400);
            Console.WriteLine(p);*/

            #endregion

            #region vd1: In ra ten san pham, ten thuong hieu, co gia (300 - 400), gia giam dan
            /*var kq = products.OrderByDescending(p => p.Price).Where(p => p.Price >= 300 && p.Price <= 400)
                .Join(brands, p => p.Brand, b => b.ID, (p, b) =>
                {
                    return new
                    {
                        ProductName = p.Name,
                        BrandName = b.Name,
                    };
                }).ToList();
            foreach (var item in kq)
            {
                Console.WriteLine(item);
            }*/




            #endregion

            #region Cu phap Linq
            /**
             * Cu phap linq:
             * 1/ Xac dinh nguon: from tenPhanTu inIEnumerables
             * 
             * 2/ Lay du lieu: select, group by....
             */

            /* var qr = from p in products

                      select $"{p.Name} - {p.Price}";*/

            /* var qr = from p in products

                      select new
                      {
                          ProductName = p.Name,
                          Price = p.Price,
                      };
             qr.ToList().ForEach(q => Console.WriteLine(q));*/

            /* var qr = from p in products
                      where p.Price <= 400
                      select new
                      {
                          ProductName = p.Name, Price = p.Price,
                      };
             qr.ToList().ForEach(q => Console.WriteLine(q));*/

            /**
             * Gia <= 500, mau Xanh
             */
            /*var qr = from p in products
                     from color in p.Colors

                     where p.Price <= 500 && color.Equals("Xanh")
                     orderby p.Price descending 

                     select new
                     {
                         ProductName = p.Name,
                         ProductPrice = p.Price,
                         Color = p.Colors,
                     };
            qr.ToList().ForEach(q =>
            {
                Console.WriteLine($"{q.ProductName} - {q.ProductPrice} -{string.Join(",", q.Color)}");
            });*/

            //groupby
            /**
             * lay danh sach cac san pham nhom theo gia
             */
            /*var qr = from p in products

                     group p by p.Price into gr
                     orderby gr.Key
                     select gr
                     ;

            qr.ToList().ForEach(group =>
            {
                Console.WriteLine(group.Key);
                group.ToList().ForEach(p => Console.WriteLine(p));
            });
*/
            //let tenBien
            /**
             * Truy van: Doi tuong {
             *      Gia
             *      Cac SP
             *      So Luong
             * }
             */

            /* var qr = from p in products

                      group p by p.Price into gr
                      orderby gr.Key
                      let quantity = gr.Count()
                      select new
                      {
                          ProductPrice = gr.Key,
                          ListProducts = gr.ToList(),
                          Quantity= quantity
                      };

             qr.ToList().ForEach(i => {
                 Console.WriteLine(i.ProductPrice);
                 Console.WriteLine(i.Quantity);
                 i.ListProducts.ForEach(p => Console.WriteLine(p));
             });*/

            /**
             * JOIN: KET HOP nhieu nguon du lieu trong cau truy van
             */
            /*var qr = from p in products
                     join b in brands on p.Brand equals b.ID
                     select new
                     {
                         ProductName = p.Name,
                         ProductPrice = p.Price,
                         BrandName = b.Name,
                     };*/

            //lay het san pham va ca thuong hieu (sp ko co thuong hieu  thi de trong)
            var qr = from p in products
                     join b in brands on p.Brand equals b.ID into t
                     from b2 in t.DefaultIfEmpty()
                     select new
                     {
                         ProductName = p.Name,
                         ProductPrice = p.Price,
                         BrandName = b2 != null ? b2.Name : "",
                     };

            qr.ToList().ForEach(o =>
            {
                Console.WriteLine($"{o.ProductName, 15} {o.BrandName, 15} {o.ProductPrice, 5}");
            }) ;

            #endregion
        }
    }
}
