using System;
using System.Collections.Generic;
using Api.Domain.dtos.projeto;

namespace Api.Service.Test.Projeto
{
    public class ProjetosTeste
    {
        public static Guid IdProjeto { get; set; }
        public static string ProjetoName { get; set; }
        public static string ProjetoNameAlterado { get; set; }

        public List<ProjetoDto> listaProjetoDto = new List<ProjetoDto>();
        public ProjetoDto projetoDto;
        public ProjetoDtoCreate projetoDtoCreate;

        public ProjetosTeste()
        {
            IdProjeto = Guid.NewGuid();
            ProjetoName = Faker.Name.FullName();
            ProjetoNameAlterado = Faker.Name.FullName();

            for (int i = 0; i < 10; i++)
            {

                var dto = new ProjetoDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName()
                };

                listaProjetoDto.Add(dto);

            }

            projetoDto = new ProjetoDto()
            {
                Id = IdProjeto,
                Name = ProjetoName
            };

            projetoDtoCreate = new ProjetoDtoCreate()
            {
                Name = ProjetoName
            };
        }

    }
}
