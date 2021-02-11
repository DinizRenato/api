using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.dtos.projeto;
using Api.Domain.entities;
using Api.Domain.interfaces;
using Api.Domain.interfaces.services;
using Api.Domain.models;
using AutoMapper;

namespace Api.Service.services
{
    public class ProjetoService : IProjetoService
    {
        private IRepository<ProjetoEntity> _repository;
        private readonly IMapper _mapper;

        public ProjetoService(IRepository<ProjetoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProjetoDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ProjetoDto>(entity);
        }

        public async Task<IEnumerable<ProjetoDto>> GetAll()
        {
            var list = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ProjetoDto>>(list);
        }

        public async Task<ProjetoDto> Post(ProjetoDtoCreate projeto)
        {
            var model = _mapper.Map<ProjetoModel>(projeto);
            var entity = _mapper.Map<ProjetoEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<ProjetoDto>(result);
        }

        public async Task<ProjetoDto> Put(ProjetoDto projeto)
        {
            var model = _mapper.Map<ProjetoModel>(projeto);
            var entity = _mapper.Map<ProjetoEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ProjetoDto>(result);
        }
    }
}
