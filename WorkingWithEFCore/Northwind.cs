using Microsoft.EntityFrameworkCore;

namespace Packt.Shared;

public class Northwind : DbContext
{
    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        string path = Path.Combine(
        Environment.CurrentDirectory, "Northwind.db");
        string connection = $"Filename={path}";
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection: {connection}");
        ForegroundColor = previousColor;
        optionsBuilder.UseSqlite(connection);
    }
}