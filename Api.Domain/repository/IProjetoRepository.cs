using System;
using System.Threading.Tasks;
using Api.Domain.dtos.projeto;
using Api.Domain.entities;
using Api.Domain.interfaces;

namespace Api.Domain.repository
{
    public interface IProjetoRepository : IRepository<ProjetoEntity>
    {
        Task<ProjetoEntity> GetByIdWithMetadados(Guid id);
    }
}
