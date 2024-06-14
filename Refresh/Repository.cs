using Microsoft.EntityFrameworkCore;
using Refresh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Refresh.EF;

namespace Refresh
{
    public class Repository
    {
        NorthwindDbContext db;
        static Func<Product, string> PrintProduct = (product) =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{product.ProductId,5} {product.ProductName,-50} {product.UnitPrice:00000.00} {product.UnitsInStock,-6}");
            return sb.ToString();
        };
        private readonly Action<Category> PrintCategory = (category) =>
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Category: ")
            .Append($"\tID: {category.CategoryId}, Name: {category.CategoryName}\n")
            .Append($"\tDescription: {category.Description}");
            if (category.Products.Count > 0)
            {
                sb.AppendLine($"\n{"Id",5} {"Product Name",-50} {"Price",7} {"Units In Stock"}");
                foreach (var product in category.Products)
                {
                    sb.AppendLine(Repository.PrintProduct(product));
                }
            }
            Console.WriteLine(sb.ToString());
        };
        public Repository()
        {
            db = new NorthwindDbContext();
        }
        public void GetCategories()
        {
            var q = db.Categories.ToList();
            q.ForEach(c => PrintCategory(c));
        }
        public void GetCategoriesWithProducts()
        {
            var q = db.Categories.Include(c => c.Products).ToList();
            q.ForEach(c => PrintCategory(c));
        }
        public void GetCategoriesWithProductsUsingJoins()
        {
            var query = from c in db.Categories
                        join p in db.Products on c.CategoryId equals p.CategoryId
                        select new
                        {
                            Category = c,
                            Product = p
                        };

            var categoriesWithProducts = query.ToList()
                .GroupBy(cp => cp.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.Select(cp => cp.Product).ToList()
                }).ToList();

            foreach (var categoryWithProducts in categoriesWithProducts)
            {
                var category = categoryWithProducts.Category;
                foreach (var product in categoryWithProducts.Products)
                {
                    category.Products.Add(product);
                }
                PrintCategory(category);
            }
        }
        public void GetProductCountByCategory()
        {
            var query = from c in db.Categories
                        join p in db.Products on c.CategoryId equals p.CategoryId
                        group p by new { c.CategoryId, c.CategoryName } into g
                        select new
                        {
                            CategoryName = g.Key.CategoryName,
                            ProductCount = g.Count()
                        };

            var result = query.ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.CategoryName}: {item.ProductCount}");
            }
        }

        public void ListAllProductsWithCategoryDetails()
        {
            var query = from p in db.Products
                        join c in db.Categories on p.CategoryId equals c.CategoryId
                        select new
                        {
                            p.ProductId,
                            p.ProductName,
                            p.UnitPrice,
                            p.UnitsInStock,
                            p.Discontinued,
                            c.CategoryId,
                            c.CategoryName,
                            c.Description
                        };

            var result = query.ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductId} - {item.ProductName} - {item.UnitPrice} - {item.UnitsInStock} - {item.Discontinued} - {item.CategoryId} - {item.CategoryName} - {item.Description}");
            }
        }
        public void PrintMaxOrderValue()
        {
            var maxOrderValue = db.OrderDetail
                .Select(od => od.UnitPrice * od.Quantity)
                .Max();

            Console.WriteLine($"Max Order Value: {maxOrderValue}");
        }

        public void PrintOrderValueGroupedByOrder()
        {
            var query = from od in db.OrderDetail
                        group od by od.OrderId into g
                        select new
                        {
                            OrderId = g.Key,
                            OrderValue = g.Sum(od => od.UnitPrice * od.Quantity)
                        };

            var result = query.ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"Order ID: {item.OrderId}, Order Value: {item.OrderValue}");
            }
        }
    }
}