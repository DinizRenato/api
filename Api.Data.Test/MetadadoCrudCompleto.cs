using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.context;
using Api.Data.implementations;
using Api.Domain.entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class MetadadoCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public MetadadoCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        [Fact(DisplayName = "CRUD de Metadado")]
        [Trait("CRUD", "MetadadoEntity")]
        public async Task E_Possivel_CRUD_Metadado()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                ProjetoImplementation _repositorioProjeto = new ProjetoImplementation(context);
                ProjetoEntity _projetoEntity = new ProjetoEntity
                {
                    Name = Faker.Name.FullName()
                };

                var _projeto = await _repositorioProjeto.InsertAsync(_projetoEntity);

                MetadadoImplementation _repositorio = new MetadadoImplementation(context);

                MetadadoEntity _entity = new MetadadoEntity
                {
                    ProjetoId = _projeto.Id,
                    Name = Faker.Name.FullName(),
                    Order = 0,
                    Type = "text",
                    Options = Faker.Lorem.GetFirstWord()
                };

                var _metadadoCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_metadadoCriado);
                Assert.Equal(_entity.Name, _metadadoCriado.Name);
                Assert.False(_metadadoCriado.Id == Guid.Empty);

                _entity.Name = Faker.Company.Name();
                var _metadadoAtualizado = await _repositorio.UpdateAsync(_metadadoCriado);
                Assert.NotNull(_metadadoAtualizado);
                Assert.Equal(_metadadoAtualizado.Name, _entity.Name);

                var _metadadoSelecionado = await _repositorio.SelectAsync(_metadadoAtualizado.Id);
                Assert.NotNull(_metadadoSelecionado);
                Assert.Equal(_metadadoSelecionado.Name, _metadadoAtualizado.Name);

                var _metadadoList = await _repositorio.SelectAsync();
                Assert.NotNull(_metadadoList);
                Assert.True(_metadadoList.Count() > 0);

                var deletou = await _repositorio.DeleteAsync(_metadadoSelecionado.Id);
                Assert.True(deletou);

            }
        }
    }
}
