using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableRename;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Entity4>? Entity4s { get; set; }
    public DbSet<Entity2>? Entity2s { get; set; }
    public DbSet<Entity3>? Entity3s { get; set; }
}


public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = @"server=(localdb)\MSSQLLocalDB;Database=TableRename;Integrated Security=true;Encrypt=False;";
        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}


public class Entity4
{
    public int Id { get; set; }
    public int Entity2Id { get; set; }
    [ForeignKey(nameof(Entity2Id))]
    public Entity2? Entity2Navigation { get; set; }
    public int Entity3Id { get; set; }
    [ForeignKey(nameof(Entity3Id))]
    public Entity3? Entity3Navigation { get; set; }
}

public class Entity2
{
    public int Id { get; set; }
    [InverseProperty(nameof(Entity4.Entity2Navigation))]
    public ICollection<Entity4> Entity1s { get; set; } = new List<Entity4>();
}

public class Entity3
{
    public int Id { get; set; }
    [InverseProperty(nameof(Entity4.Entity3Navigation))]
    public ICollection<Entity4> Entity1s { get; set; } = new List<Entity4>();
}