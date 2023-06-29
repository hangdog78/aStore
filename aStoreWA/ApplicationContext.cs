using aStoreServer.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
   
    public DbSet<Test> test { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    
}