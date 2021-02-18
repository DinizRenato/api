using System;
using System.Threading.Tasks;
using Api.Domain.dtos.metadado;
using Api.Domain.interfaces.services;
using Moq;
using Xunit;

namespace Api.Service.Test.Metadado
{
    public class QuandoExecutadoGet : MetadadosTeste
    {
        private IMetadadoService _service;

        private Mock<IMetadadoService> _serviceMock;
        [Fact(DisplayName = "É possível executar método GET")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_GET()
        {
            _serviceMock = new Mock<IMetadadoService>();
            _serviceMock.Setup(m => m.Get(IdMetadado)).ReturnsAsync(metadadoDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdMetadado);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMetadado);
            Assert.Equal(NameMetadado, result.Name);

            _serviceMock = new Mock<IMetadadoService>();
            _serviceMock.Setup(p => p.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MetadadoDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdMetadado);
            Assert.Null(_record);
        }
    }
}
