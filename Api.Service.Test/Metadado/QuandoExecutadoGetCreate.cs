using System;
using System.Threading.Tasks;
using Api.Domain.dtos.metadado;
using Api.Domain.interfaces.services;
using Moq;
using Xunit;

namespace Api.Service.Test.Metadado
{
    public class QuandoExecutadoGetCreate : MetadadosTeste
    {
        private IMetadadoService _service;

        private Mock<IMetadadoService> _serviceMock;
        [Fact(DisplayName = "É possível executar método Create")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_CREATE()
        {
            _serviceMock = new Mock<IMetadadoService>();
            _serviceMock.Setup(m => m.Post(metadadoDtoCreate)).ReturnsAsync(metadadoDto);
            _service = _serviceMock.Object;

            var result = await _service.Post(metadadoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NameMetadado, result.Name);
            Assert.Equal(OrderMetadado, result.Order);
            Assert.Equal(TypeMetadado, result.Type);
            Assert.Equal(OptionsMetadado, result.Options);

        }
    }
}
