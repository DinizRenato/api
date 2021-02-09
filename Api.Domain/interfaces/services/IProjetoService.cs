using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.dtos.projeto;

namespace Api.Domain.interfaces.services
{
    public interface IProjetoService
    {
        Task<ProjetoDto> Get(Guid id);
        Task<IEnumerable<ProjetoDto>> GetAll();
        Task<ProjetoDto> Post(ProjetoDtoCreate projeto);
        Task<ProjetoDto> Put(ProjetoDto projeto);
        Task<bool> Delete(Guid id);
    }
}
