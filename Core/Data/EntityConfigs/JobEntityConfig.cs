using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWJOBS.Core.Models;

namespace TWJOBS.Core.Data.EntityConfigs;

public class JobEntityConfig : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("jobs");

        builder.HasKey(j => j.id);
        builder.Property(j => j.id)
            .HasColumnName("id");

        builder.Property(j => j.titulo)
            .HasColumnName("titulo")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(j => j.salario)
            .HasColumnName("salario")
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(j => j.requerimentos)
            .HasColumnName("requerimentos")
            .HasColumnType("nvarchar(500)")
            .IsRequired();
    }
}