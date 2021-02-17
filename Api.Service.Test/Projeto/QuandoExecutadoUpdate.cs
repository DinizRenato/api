using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.dtos.projeto;
using Api.Domain.interfaces.services;
using Moq;
using Xunit;

namespace Api.Service.Test.Projeto
{
    public class QuandoExecutadoUpdate : ProjetosTeste
    {
        private IProjetoService _service;
        private Mock<IProjetoService> _serviceMock;

        [Fact(DisplayName = "É possível executar método Update")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_UPDATE()
        {
            _serviceMock = new Mock<IProjetoService>();
            _serviceMock.Setup(p => p.Post(projetoDtoCreate)).ReturnsAsync(projetoDto);
            _service = _serviceMock.Object;

            var result = await _service.Post(projetoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(ProjetoName, result.Name);

            projetoDto.Name = ProjetoNameAlterado;

            _serviceMock = new Mock<IProjetoService>();
            _serviceMock.Setup(m => m.Put(projetoDto)).ReturnsAsync(projetoDto);
            _service = _serviceMock.Object;


            var resultUpdate = await _service.Put(projetoDto);
            Assert.NotNull(resultUpdate);
            Assert.Equal(ProjetoNameAlterado, resultUpdate.Name);

        }
    }
}
