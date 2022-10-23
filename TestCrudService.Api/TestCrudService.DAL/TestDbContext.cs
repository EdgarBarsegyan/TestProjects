using Microsoft.EntityFrameworkCore;
using TestCrudService.DAL.Entity;
using TestCrudService.DAL.EntityMap;

namespace TestCrudService.DAL;

public sealed class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DocPersonMap());
        modelBuilder.ApplyConfiguration(new DocEducationLineMap());
        modelBuilder.ApplyConfiguration(new RefEducationMap());
    }

    public DbSet<DocPerson> PersonSet { get; set; }
    public DbSet<DocEducationLine> EducationLines { get; set; }
    public DbSet<RefEducation> Educations { get; set; }
}