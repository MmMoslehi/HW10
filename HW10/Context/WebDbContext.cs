using HW10.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class WebDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(HW10.Connercton.ConnectionString.Connectionstring);
            //.LogTo(Console.WriteLine);
    }
}
