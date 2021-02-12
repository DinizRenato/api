using Api.Domain.entities;
using Api.Domain.models;
using AutoMapper;

namespace Api.CrossCutting.mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<ProjetoEntity, ProjetoModel>().ReverseMap();
            CreateMap<MetadadoEntity, MetadadoModel>().ReverseMap();
        }
    }
}
