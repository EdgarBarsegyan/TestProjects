using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCrudService.Api.Dal.Entity;

namespace TestCrudService.Api.Dal.EntityMap;

public class DocUserMap : IEntityTypeConfiguration<DocUser>
{
    public void Configure(EntityTypeBuilder<DocUser> builder)
    {
        builder.ToTable("DocUser").HasKey(x => x.Id);
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Age).HasColumnName("Age").IsRequired();

    }
}