using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
partial class Program
{
    static void ListProducts(int[]? productIdsToHighlight = null)
    {
        using (Northwind db = new())
        {
            if ((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products.");
                return;
            }

            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |", "Id", "Product Name", "Cost", "Stock", "Disc.");
            
            foreach (Product p in db.Products)
            {
                ConsoleColor previousColor = ForegroundColor;
                if ((productIdsToHighlight is not null) && productIdsToHighlight.Contains(p.ProductId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }

                WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |",
                    p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);

                ForegroundColor = previousColor;
            }
        }
    }

    static (int affected, int productId) AddProduct(int categoryId, string productName, decimal? price)
    {
        using (Northwind db = new())
        {
            if (db.Products is null) return (0, 0);

            Product p = new()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Cost = price,
                Stock = 72
            };

            EntityEntry<Product> entity = db.Products.Add(p);
            WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

            int affected = db.SaveChanges();
            WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

            return (affected, p.ProductId);
        }
    }

}