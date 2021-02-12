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
    public class ProjetoCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public ProjetoCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Projeto")]
        [Trait("CRUD", "ProjetoEntity")]
        public async Task E_Possivel_CRUD_Projeto()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                ProjetoImplementation _repositorio = new ProjetoImplementation(context);
                ProjetoEntity _entity = new ProjetoEntity
                {
                    Name = Faker.Name.FullName()
                };

                var _projetoCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_projetoCriado);
                Assert.Equal(_entity.Name, _projetoCriado.Name);
                Assert.False(_projetoCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.FullName();
                var _projetoAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_projetoAtualizado);
                Assert.Equal(_entity.Name, _projetoAtualizado.Name);

                var _projetoSelecionado = await _repositorio.SelectAsync(_projetoAtualizado.Id);
                Assert.NotNull(_projetoSelecionado);
                Assert.Equal(_projetoAtualizado.Name, _projetoSelecionado.Name);

                var _projetoList = await _repositorio.SelectAsync();
                Assert.NotNull(_projetoList);
                Assert.True(_projetoList.Count() > 0);

                var deletou = await _repositorio.DeleteAsync(_projetoSelecionado.Id);
                Assert.True(deletou);


            }
        }
    }
}
