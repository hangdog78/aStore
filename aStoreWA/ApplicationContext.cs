using aStoreServer.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{

    public DbSet<Operation> Operation => Set<Operation>();
    public DbSet<Department> Department  => Set<Department>();
    public DbSet<DepGroup> DepGroup =>Set<DepGroup>();
    public DbSet<Entity> Entity => Set<Entity>();
    public DbSet<EntityRoute> EntityRoute => Set<EntityRoute>();
    public DbSet<Group> Group => Set<Group>();
    public DbSet<OperationsProgress> OperationsProgress => Set<OperationsProgress>();
    public DbSet<OperationState> OperationState => Set<OperationState>();
    public DbSet<RoutStage> RoutStage => Set<RoutStage>();
    public DbSet<Worker> Worker => Set<Worker>();
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }


}