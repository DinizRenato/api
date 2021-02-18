using System;
using System.Collections.Generic;
using Api.Domain.dtos.metadado;

namespace Api.Service.Test.Metadado
{
    public class MetadadosTeste
    {

        public static Guid IdMetadado { get; set; }
        public static Guid IdProjeto { get; set; }
        public static int OrderMetadado { get; set; }
        public static string NameMetadado { get; set; }
        public static string TypeMetadado { get; set; }
        public static string OptionsMetadado { get; set; }
        public static int OrderMetadadoAlterado { get; set; }
        public static string NameMetadadoAlterado { get; set; }
        public static string TypeMetadadoAlterado { get; set; }
        public static string OptionsMetadadoAlterado { get; set; }

        public List<MetadadoDto> listaMetadadoDto = new List<MetadadoDto>();

        public MetadadoDto metadadoDto;
        public MetadadoDto metadadoUpdateDto;

        public MetadadoDtoCreate metadadoDtoCreate;

        public MetadadosTeste()
        {
            IdMetadado = Guid.NewGuid();
            IdProjeto = Guid.NewGuid();
            OrderMetadado = Faker.RandomNumber.Next(1, 1000);
            NameMetadado = Faker.Name.FullName();
            TypeMetadado = Faker.Name.FullName();
            OptionsMetadado = Faker.Name.First();

            OrderMetadadoAlterado = Faker.RandomNumber.Next(1, 1000);
            NameMetadadoAlterado = Faker.Name.FullName();
            TypeMetadadoAlterado = Faker.Name.FullName();
            OptionsMetadadoAlterado = Faker.Name.First();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MetadadoDto()
                {
                    Id = Guid.NewGuid(),
                    ProjetoId = Guid.NewGuid(),
                    Order = Faker.RandomNumber.Next(1, 1000),
                    Name = Faker.Name.FullName(),
                    Type = Faker.Name.FullName(),
                    Options = Faker.Name.First()
                };

                listaMetadadoDto.Add(dto);
            }

            metadadoDto = new MetadadoDto()
            {
                Id = IdMetadado,
                ProjetoId = IdProjeto,
                Order = OrderMetadado,
                Name = NameMetadado,
                Type = TypeMetadado,
                Options = OptionsMetadado
            };

            metadadoDtoCreate = new MetadadoDtoCreate()
            {
                ProjetoId = IdProjeto,
                Order = OrderMetadado,
                Name = NameMetadado,
                Type = TypeMetadado,
                Options = OptionsMetadado
            };

            metadadoUpdateDto = new MetadadoDto()
            {
                Id = IdMetadado,
                ProjetoId = IdProjeto,
                Order = OrderMetadadoAlterado,
                Name = NameMetadadoAlterado,
                Type = TypeMetadadoAlterado,
                Options = OptionsMetadadoAlterado
            };
        }

    }
}
