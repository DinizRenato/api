using Api.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.mapping
{
    public class ProjetoMap : IEntityTypeConfiguration<ProjetoEntity>
    {
        public void Configure(EntityTypeBuilder<ProjetoEntity> builder)
        {
            builder.ToTable("Projeto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
