using System;
using System.Threading.Tasks;
using Api.Domain.dtos.metadado;
using Api.Domain.interfaces.services;
using Moq;
using Xunit;

namespace Api.Service.Test.Metadado
{
    public class QuandoExecutadoGetDelete : MetadadosTeste
    {
        private IMetadadoService _service;

        private Mock<IMetadadoService> _serviceMock;
        [Fact(DisplayName = "É possível executar método Delete")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_Delete()
        {
            _serviceMock = new Mock<IMetadadoService>();
            _serviceMock.Setup(m => m.Delete(IdMetadado)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdMetadado);
            Assert.True(deletado);

            _serviceMock = new Mock<IMetadadoService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);

        }
    }
}
