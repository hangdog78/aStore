using aStoreServer.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{

    public DbSet<Operation> Operation => Set<Operation>();
    public DbSet<Department> Department { get; set; } = null!;
    public DbSet<DepGroup> DepGroup { get; set; } = null!;
    public DbSet<Entity> Entity { get; set; } = null!;
    public DbSet<EntityRoute> EntityRoute { get; set; } = null!;
    public DbSet<Group> Group { get; set; } = null!;
    public DbSet<OperationsProgress> OperationsProgress { get; set; } = null!;
    public DbSet<OperationState> OperationState { get; set; } = null!;
    public DbSet<PositionRules> PositionRules { get; set; } = null!;
    public DbSet<RoutStage> RoutStage { get; set; } = null!;
    public DbSet<Worker> Worker { get; set; } = null!;
    public DbSet<WorkerPosition> WorkerPosition { get; set; } = null!;
    public DbSet<Test> Test { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }


}