using Api.Domain.dtos.projeto;
using Api.Domain.entities;
using AutoMapper;

namespace Api.CrossCutting.mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ProjetoDto, ProjetoEntity>().ReverseMap();

            CreateMap<ProjetoDtoCreate, ProjetoEntity>().ReverseMap();
        }
    }
}
