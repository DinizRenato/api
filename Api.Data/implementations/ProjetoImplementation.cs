using System;
using System.Threading.Tasks;
using Api.Data.context;
using Api.Data.repository;
using Api.Domain.dtos.projeto;
using Api.Domain.entities;
using Api.Domain.repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.implementations
{
    public class ProjetoImplementation : BaseRepository<ProjetoEntity>, IProjetoRepository
    {
        private DbSet<ProjetoEntity> _dataset;
        // private MyContext _context;
        public ProjetoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProjetoEntity>();
            // _context = context;
        }

        public async Task<ProjetoEntity> GetByIdWithMetadados(Guid id)
        {
            return await _context.Projetos.Include(p => p.Metadados).SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
    }
}
