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
    public class QuandoExecutadoCreate : ProjetosTeste
    {
        private IProjetoService _service;
        private Mock<IProjetoService> _serviceMock;

        [Fact(DisplayName = "É possível executar método Create")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_CREATE()
        {
            _serviceMock = new Mock<IProjetoService>();
            _serviceMock.Setup(p => p.Post(projetoDtoCreate)).ReturnsAsync(projetoDto);
            _service = _serviceMock.Object;

            var result = await _service.Post(projetoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(ProjetoName, result.Name);

        }
    }
}
