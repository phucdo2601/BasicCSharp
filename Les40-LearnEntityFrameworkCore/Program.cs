using Les40_LearnEntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les40_LearnEntityFrameworkCore
{
    public class Program
    {
        #region Basic CreateDatabase with EntityFrame on ConsoleApp
        static void CreateDatabase()
        {
            using var dbContext = new DatabaseContext();
            string dbName = dbContext.Database.GetDbConnection().Database;

            var res = dbContext.Database.EnsureCreated();
            if (res)
            {
                Console.WriteLine($"Create database with name {dbName} sucessfully");

            }
            else
            {
                Console.WriteLine($"Create database with name {dbName} not sucessfully");

            }
        }

        #endregion



        #region Drop Database with EntityFrame on ConsoleApp
        static void DropDatabase()
        {
            using var dbContext = new DatabaseContext();
            string dbName = dbContext.Database.GetDbConnection().Database;

            var res = dbContext.Database.EnsureDeleted();
            if (res)
            {
                Console.WriteLine($"Drop database with name {dbName} sucessfully");

            }
            else
            {
                Console.WriteLine($"Drop database with name {dbName} not sucessfully");

            }
        }
        #endregion

        #region Insert data on table
        /*static void InsertProduct()
        {
            using var dbContext = new DatabaseContext();
            
            /*var p1 = new Product();
            p1.ProductName= "Test-SP02";
            p1.Provider= "Nha cung cap 02";

            dbContext.Add(p1);*//*

            var products = new object[]
            {
                new Product{ ProductName = "Test-SP03", Provider = "Nha cung cap 02"},
                new Product{ ProductName = "Test-SP04", Provider = "Nha cung cap 02"},
                new Product{ ProductName = "Test-SP05", Provider = "Nha cung cap 01"},
                new Product{ ProductName = "Test-SP06", Provider = "Nha cung cap 03"},
            };

            dbContext.AddRange( products );

            int num_rows = dbContext.SaveChanges();
            Console.WriteLine($"Da chen {num_rows} dong du lieu");


        }*/

        #endregion

        #region doc du lieu
        static void ReadData()
        {
            using var dbContext = new DatabaseContext();
            /*var products = dbContext.Products.ToList();

            foreach (var item in products)
            {
                item.PrintInfo();
            }*/

            /*var res = from pr in dbContext.Products
                      where pr.ProductId >= 3
                      select pr;*/

            /*var res = from pr in dbContext.Products
                      where pr.Provider.Contains("Nha")
                      orderby pr.ProductId descending
                      select pr;*/

            /*res.ToList().ForEach(x => x.PrintInfo());*/

            /*var res = (from pr in dbContext.Products
                      where pr.ProductId == 4
                      select pr).FirstOrDefault();

            if (res != null)
            {
                res.PrintInfo();
            }*/

            /*var res = (from pr in dbContext.Products
                           where pr.Provider == "Nha cung cap 01"
                           select pr).FirstOrDefault();

            if (res != null)
            {
                res.PrintInfo();
            }*/
        }

        #endregion

        #region update data on db
        static void UpdateProduct(int id, string newProName)
        {
            using var dbContext = new DatabaseContext();
            var res = (from pr in dbContext.Products
                       where pr.ProductId == id
                       select pr).FirstOrDefault();

            if (res != null)
            {
                //doi tuong theo su thay doi cua object ma moi lay
                /* EntityEntry<Product> entry = dbContext.Entry(res);
                 entry.State= EntityState.Detached;*/

                res.ProductName = newProName;

                int num_rows = dbContext.SaveChanges();
                Console.WriteLine($"Da sua {num_rows} dong du lieu");
            }

        }

        #endregion

        #region Delete Product
        static void DeleteProduct(int id)
        {
            using var dbContext = new DatabaseContext();
            var res = (from pr in dbContext.Products
                       where pr.ProductId == id
                       select pr).FirstOrDefault();

            if (res != null)
            {

                dbContext.Products.Remove(res);



                int num_rows = dbContext.SaveChanges();
                Console.WriteLine($"Da sua {num_rows} dong du lieu");
            }

        }
        #endregion

        // Chèn dữ liệu mẫu
        public static void InsertSampleData()
        {
            using var dbContext = new DatabaseContext();
            // Thêm 2 danh mục vào Category
            /*var cate1 = new Category() { Name = "Cate1", Description = "Description1" };
            var cate2 = new Category() { Name = "Cate2", Description = "Description2" };
            dbContext.Categories.Add(cate1);
            dbContext.Categories.Add(cate2);*/

            var cate1 = (from c in dbContext.Categories
                         where c.CategoryId == 1
                         select c).FirstOrDefault();

            var cate2 = (from c in dbContext.Categories
                         where c.CategoryId == 2
                         select c).FirstOrDefault();

            dbContext.Add(
                new Product()
                {
                    ProductName = "Iphone 8",
                    Price = 1200,
                    CateId = 1,
                }
                );

            dbContext.Add(
                new Product()
                {
                    ProductName = "Iphone XS Max",
                    Price = 1200,
                    Category = cate1,
                }
                );

            dbContext.Add(
                new Product()
                {
                    ProductName = "test-pro-03",
                    Price = 1200,
                    Category = cate2,
                }
                );

            dbContext.Add(
                new Product()
                {
                    ProductName = "Ruou vang Abc",
                    Price = 1200,
                    CateId = 2,
                }
                );

            dbContext.Add(
                new Product()
                {
                    ProductName = "Ipad Gen 9",
                    Price = 4535,
                    CateId = 1,
                }
                );

            dbContext.Add(
               new Product()
               {
                   ProductName = "Ipad Gen 9",
                   Price = 4535,
                   CateId = 1,
               }
               );

            dbContext.Add(
               new Product()
               {
                   ProductName = "Ipad Gen 10",
                   Price = 3453,
                   CateId = 2,
               }
               );

            dbContext.Add(
               new Product()
               {
                   ProductName = "Ipad Gen 11",
                   Price = 4535,
                   CateId = 2,
               }
               );

            dbContext.Add(
               new Product()
               {
                   ProductName = "Ipad Gen 4",
                   Price = 4535,
                   CateId = 1,
               }
               );



            dbContext.SaveChanges();

        }


        static void Main(string[] args)
        {
            //DropDatabase();
            //CreateDatabase();

            /*DropDatabase();*/

            //Insert, Select, Update, Delete

            #region Insert Data on Table
            /*InsertProduct();*/
            /*InsertSampleData();*/

            #endregion

            #region Select data
            /*ReadData();*/

            #endregion

            #region Update data
            /*UpdateProduct(1, "Iphone XS");*/
            #endregion

            #region Delete data
            /* DeleteProduct(6);*/
            #endregion

            #region Logging


            #endregion

            using var dbContext = new DatabaseContext();
            /* var product = (from p in dbContext.Products
                           where p.ProductId == 1
                           select p).FirstOrDefault();

             var e = dbContext.Entry(product);
             e.Reference(e => e.Category).Load();

            product.PrintInfo();

             if (product.Category !=null)
             {
                 Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");
             } else
             {
                 Console.WriteLine("Category == null");
             }*/


            /*var category = (from c in dbContext.Categories
                          where c.CategoryId == 1
                          select c).FirstOrDefault();

            Console.WriteLine($"{category.Name} - {category.Description}");
            var e = dbContext.Entry(category);
            e.Collection(c => c.Products).Load();

            if (category.Products != null)
            {
                Console.WriteLine($"So san pham la: {category.Products.Count}");
                category.Products.ForEach(p => p.PrintInfo());
               
            }
            else
            {
                Console.WriteLine("Products == null");
            }*/

            /*var resPro = from p in dbContext.Products
                         join c in dbContext.Categories on p.CateId equals c.CategoryId
                         select new
                         {
                             p.ProductName,
                             c.Name,
                             p.Price
                         };*/

            var resPro = dbContext.Products.Include(c => c.Category).ToList();

            resPro.ToList().ForEach(p => Console.WriteLine(p));
        }
    }
}
