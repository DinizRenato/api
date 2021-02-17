using System;
using System.Threading.Tasks;
using Api.Domain.dtos.projeto;
using Api.Domain.interfaces.services;
using Moq;
using Xunit;

namespace Api.Service.Test.Projeto
{
    public class QuandoExecutadoGet : ProjetosTeste
    {
        private IProjetoService _service;
        private Mock<IProjetoService> _serviceMock;

        [Fact(DisplayName = "É possível executar método GET")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_GET()
        {
            _serviceMock = new Mock<IProjetoService>();
            _serviceMock.Setup(p => p.Get(IdProjeto)).ReturnsAsync(projetoDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdProjeto);
            Assert.NotNull(result);
            Assert.True(result.Id == IdProjeto);
            Assert.Equal(ProjetoName, result.Name);

            _serviceMock = new Mock<IProjetoService>();
            _serviceMock.Setup(p => p.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ProjetoDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdProjeto);
            Assert.Null(_record);

        }
    }
}
