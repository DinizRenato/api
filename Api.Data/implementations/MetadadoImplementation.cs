using Api.Data.context;
using Api.Data.repository;
using Api.Domain.entities;
using Api.Domain.repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.implementations
{
    public class MetadadoImplementation : BaseRepository<MetadadoEntity>, IMetadadoRepository
    {
        private DbSet<ProjetoEntity> _dataset;
        public MetadadoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProjetoEntity>();
        }
    }
}
