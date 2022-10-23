using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCrudService.DAL.Entity;

namespace TestCrudService.DAL.EntityMap;

public class DocEducationLineMap : IEntityTypeConfiguration<DocEducationLine>
{
    public void Configure(EntityTypeBuilder<DocEducationLine> builder)
    {
        builder.ToTable("Doc_EducationLine")
            .HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
    }
}