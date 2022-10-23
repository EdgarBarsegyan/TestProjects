using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCrudService.DAL.Entity;

namespace TestCrudService.DAL.EntityMap;

public class RefEducationMap : IEntityTypeConfiguration<RefEducation>
{
    public void Configure(EntityTypeBuilder<RefEducation> builder)
    {
            builder.ToTable("Ref_Education")
                .HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.HasOne<DocEducationLine>(x => x.EducationLine)
                .WithOne(x => x.Education)
                .HasForeignKey<DocEducationLine>(x => x.EducationId);
    }
}