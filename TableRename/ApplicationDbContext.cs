using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableRename;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Entity1>? Entity1s { get; set; }
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


public class Entity1
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
    [InverseProperty(nameof(Entity1.Entity2Navigation))]
    public ICollection<Entity1> Entity1s { get; set; } = new List<Entity1>();
}

public class Entity3
{
    public int Id { get; set; }
    [InverseProperty(nameof(Entity1.Entity3Navigation))]
    public ICollection<Entity1> Entity1s { get; set; } = new List<Entity1>();
}