using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQThuis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Computer"},
                new Category{CategoryId=2, CategoryName="Telephone"}
            };

            List<Product> products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Acer Laptop", QuantityPerUnit="32 GB RAM", UnitPrice=10000, UnitInStock=5 },
                new Product{ProductId=2, CategoryId=1, ProductName="Asus Laptop", QuantityPerUnit="16 GB RAM", UnitPrice=8000, UnitInStock=3 },
                new Product{ProductId=3, CategoryId=1, ProductName="HP Laptop", QuantityPerUnit="8 GB RAM", UnitPrice=6000, UnitInStock=2 },
                new Product{ProductId=4, CategoryId=2, ProductName="Samsung Telephone", QuantityPerUnit="4 GB RAM", UnitPrice=5000, UnitInStock=15 },
                new Product{ProductId=5, CategoryId=2, ProductName="Apple Telephone", QuantityPerUnit="4 GB RAM", UnitPrice=8000, UnitInStock=0 }
            };

            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine();
            Console.WriteLine("With LINQ");

            var result = products.Where(p => p.ProductName.Contains('A'));
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine();
            List<Product> product = GetProducts(products);
            foreach (var item in product)
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine();
            Console.WriteLine("Method With LINQ ");
            List<Product> productLinq = GetProductsLinq(products);
            foreach (var item in productLinq)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        static List<Product>GetProducts(List<Product> products)
        {
            List<Product> filteredProducts = new List<Product>();
            foreach (var item in products)
            {
                if (item.UnitPrice>5000 && item.UnitInStock>2)
                {
                    filteredProducts.Add(item);
                }
            }
            return filteredProducts;
        }

        static List<Product> GetProductsLinq(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 2).ToList();
        }
    }
    class Product
    {
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
