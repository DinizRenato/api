using System;
using System.Threading.Tasks;
using Api.Domain.dtos.metadado;
using Api.Domain.interfaces.services;
using Moq;
using Xunit;

namespace Api.Service.Test.Metadado
{
    public class QuandoExecutadoGetUpdate : MetadadosTeste
    {
        private IMetadadoService _service;

        private Mock<IMetadadoService> _serviceMock;
        [Fact(DisplayName = "É possível executar método Update")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_Update()
        {
            _serviceMock = new Mock<IMetadadoService>();
            _serviceMock.Setup(m => m.Put(metadadoUpdateDto)).ReturnsAsync(metadadoUpdateDto);
            _service = _serviceMock.Object;

            var result = await _service.Put(metadadoUpdateDto);
            Assert.NotNull(result);
            Assert.Equal(NameMetadadoAlterado, result.Name);
            Assert.Equal(OrderMetadadoAlterado, result.Order);
            Assert.Equal(TypeMetadadoAlterado, result.Type);
            Assert.Equal(OptionsMetadadoAlterado, result.Options);

        }
    }
}
