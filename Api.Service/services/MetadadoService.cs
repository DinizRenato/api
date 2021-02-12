using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.dtos.metadado;
using Api.Domain.entities;
using Api.Domain.interfaces;
using Api.Domain.interfaces.services;
using Api.Domain.models;
using AutoMapper;

namespace Api.Service.services
{
    public class MetadadoService : IMetadadoService
    {

        private IRepository<MetadadoEntity> _repository;

        private readonly IMapper _mapper;

        public MetadadoService(IRepository<MetadadoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<MetadadoDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MetadadoDto>(entity);
        }

        public async Task<IEnumerable<MetadadoDto>> GetAll()
        {
            var list = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<MetadadoDto>>(list);
        }

        public async Task<MetadadoDto> Post(MetadadoDtoCreate metadado)
        {
            var model = _mapper.Map<MetadadoModel>(metadado);
            var entity = _mapper.Map<MetadadoEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<MetadadoDto>(result);
        }

        public async Task<MetadadoDto> Put(MetadadoDto metadado)
        {
            var model = _mapper.Map<MetadadoModel>(metadado);
            var entity = _mapper.Map<MetadadoEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<MetadadoDto>(result);
        }

    }
}
