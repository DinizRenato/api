using System;
using Api.Data.mapping;
using Api.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.context
{
    public class MyContext : DbContext
    {
        public DbSet<ProjetoEntity> Projetos { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjetoEntity>(new ProjetoMap().Configure);
            modelBuilder.Entity<MetadadoEntity>(new MetadadoMap().Configure);

            modelBuilder.Entity<ProjetoEntity>().HasData(
              new ProjetoEntity
              {
                  Id = Guid.NewGuid(),
                  Name = "Contrato de Clientes"
              }
            );

        }
    }
}
