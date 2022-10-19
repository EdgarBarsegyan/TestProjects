using Microsoft.EntityFrameworkCore;
using TestCrudService.Api.Dal.Entity;
using TestCrudService.Api.Dal.EntityMap;

namespace TestCrudService.Api.Dal;

internal sealed class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DocUserMap());
        
        
        // modelBuilder.Entity<DocUser>().HasData(
        //     new DocUser { Id = 1, Name = "Tom", Age = 37 },
        //     new DocUser { Id = 2, Name = "Bob", Age = 41 },
        //     new DocUser { Id = 3, Name = "Sam", Age = 24 }
        // );
    }
    
    public DbSet<DocUser> UserSet { get; set; }
}