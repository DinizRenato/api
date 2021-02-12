using Api.Data.context;
using Api.Data.repository;
using Api.Domain.entities;
using Api.Domain.repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.implementations
{
    public class ProjetoImplementation : BaseRepository<ProjetoEntity>, IProjetoRepository
    {
        private DbSet<ProjetoEntity> _dataset;
        public ProjetoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProjetoEntity>();
        }
    }
}
