using Api.Domain.dtos.projeto;
using Api.Domain.models;
using AutoMapper;

namespace Api.CrossCutting.mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<ProjetoModel, ProjetoDto>().ReverseMap();
            CreateMap<ProjetoModel, ProjetoDtoCreate>().ReverseMap();
        }
    }
}
