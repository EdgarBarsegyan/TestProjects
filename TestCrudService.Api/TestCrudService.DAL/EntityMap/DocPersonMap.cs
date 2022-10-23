using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCrudService.DAL.Entity;

namespace TestCrudService.DAL.EntityMap;

public class DocPersonMap : IEntityTypeConfiguration<DocPerson>
{
    public void Configure(EntityTypeBuilder<DocPerson> builder)
    {
            builder.ToTable("Doc_Person")
                .HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.Age).HasColumnName("Age");
            builder.HasMany(x => x.DocEducationLine)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);

    }
}