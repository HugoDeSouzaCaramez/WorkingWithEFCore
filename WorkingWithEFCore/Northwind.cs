using Microsoft.EntityFrameworkCore;

namespace Packt.Shared;

public class Northwind : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");

        string connection = $"Filename={path}";
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;

        WriteLine($"Connection: {connection}");

        ForegroundColor = previousColor;

        optionsBuilder.UseSqlite(connection);

        optionsBuilder.LogTo(WriteLine).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired()
        .HasMaxLength(15);

        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        }
    }
}