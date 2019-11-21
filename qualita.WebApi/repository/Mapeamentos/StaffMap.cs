using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using qualita.WebApi.model;

namespace qualita.WebApi.repository.Mapeamentos
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(t => t.id);

            builder.Property(t => t.name).HasMaxLength(255).IsRequired();

            builder.Property(t => t.function).HasMaxLength(255).IsRequired();

            builder.Property(t => t.rg).HasMaxLength(20).IsRequired();

            builder.Property(t => t.imgUrl).IsRequired();

            builder.ToTable("funcionarios");
        }
    }
}