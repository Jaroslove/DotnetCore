using System;
using System.Linq;
using EF.Db;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionsBuilder.UseSqlServer(
                @"Server=(LocalDB)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=True");

            var context = new NorthwindContext(optionsBuilder.Options);

            using (var transaction = context.Database.BeginTransaction())
            {

                var product = context.Products.Find(1);
                product.UnitPrice = (decimal)1111.1111;
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                
                transaction.Commit();
//                var products = context.Products.ToList();
//                
//                transaction.Rollback();
            }
            
//            var products = context.Products
////                .Select(p => p.OrderDetails)
//                .SelectMany(p => p.OrderDetails)
//                .ToList();

//            var products = context.Products
//                .Include(p => p.Category)
//                .Include(p => p.Supplier)
//                .Include(p => p.OrderDetails)
//                .ThenInclude(o => o.Product)
            //.Where(p => p.Category.CategoryId > 10)
//                .ToList();

//            var productsCount = context.Products.Count();

//            Console.WriteLine(productsCount);
        }
    }
}