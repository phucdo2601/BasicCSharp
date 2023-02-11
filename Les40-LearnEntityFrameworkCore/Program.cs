using Les40_LearnEntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

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
        static void InsertProduct()
        {
            using var dbContext = new DatabaseContext();
            /**
             * Model (Product)
             * Add, AddSync
             * SaveChanges
             */
            /*var p1 = new Product();
            p1.ProductName= "Test-SP02";
            p1.Provider= "Nha cung cap 02";

            dbContext.Add(p1);*/

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


        }

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

            if (res != null) { 
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


        static void Main(string[] args)
        {

            /*CreateDatabase();*/

            /*DropDatabase();*/

            //Insert, Select, Update, Delete

            #region Insert Data on Table
            /*InsertProduct();*/

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

        }
    }
}
