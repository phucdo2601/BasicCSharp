using Les33_DI_in_MvcWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace Les33_DI_in_MvcWeb.Services
{
    public class ProductService
    {
        List<Product> products = new List<Product>();

        public ProductService() {
            System.Console.WriteLine("Khoi tao ProductService");
            products.AddRange(new Product[]
            {
                new Product() {ID ="pro01", Name = "Dien Thoai 01", Price = 1000},
                new Product() {ID ="pro02", Name = "Dien Thoai 02", Price = 2000},
                new Product() {ID ="pro03", Name = "Dien Thoai 03", Price = 3000},
                new Product() {ID ="pro04", Name = "Dien Thoai 04", Price = 4000},
            });
        
        }

        public Product FindProduct(string productId) { 
            var qr = from p in products where p.ID == productId select p;

            return qr.FirstOrDefault();
        }
    }
}
