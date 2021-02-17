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
    public class QuandoExecutadoDelete : ProjetosTeste
    {
        private IProjetoService _service;
        private Mock<IProjetoService> _serviceMock;

        [Fact(DisplayName = "É possível executar método Delete")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_DELETE()
        {
            _serviceMock = new Mock<IProjetoService>();
            _serviceMock.Setup(p => p.Delete(IdProjeto)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdProjeto);
            Assert.True(deletado);

            _serviceMock = new Mock<IProjetoService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);

        }
    }
}
