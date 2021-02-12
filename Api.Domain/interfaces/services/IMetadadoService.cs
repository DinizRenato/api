using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.dtos.metadado;

namespace Api.Domain.interfaces.services
{
    public interface IMetadadoService
    {
        Task<MetadadoDto> Get(Guid id);
        Task<IEnumerable<MetadadoDto>> GetAll();
        Task<MetadadoDto> Post(MetadadoDtoCreate metadado);
        Task<MetadadoDto> Put(MetadadoDto metadado);
        Task<bool> Delete(Guid id);
    }
}
