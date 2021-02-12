using Api.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.mapping
{
    public class MetadadoMap : IEntityTypeConfiguration<MetadadoEntity>
    {
        public void Configure(EntityTypeBuilder<MetadadoEntity> builder)
        {
            builder.ToTable("Metadado");
            builder.HasKey(m => m.Id);
            builder.HasOne(p => p.Projeto).WithMany(m => m.Metadados);
            builder.Property(m => m.Order).IsRequired();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Type).IsRequired();
            builder.Property(m => m.Options).IsRequired();
        }
    }
}
