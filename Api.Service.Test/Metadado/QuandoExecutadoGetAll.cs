using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.dtos.metadado;
using Api.Domain.interfaces.services;
using Moq;
using Xunit;

namespace Api.Service.Test.Metadado
{
    public class QuandoExecutadoGetAll : MetadadosTeste
    {
        private IMetadadoService _service;

        private Mock<IMetadadoService> _serviceMock;
        [Fact(DisplayName = "É possível executar método GET All")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_GET_ALL()
        {
            _serviceMock = new Mock<IMetadadoService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaMetadadoDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<MetadadoDto>();
            _serviceMock = new Mock<IMetadadoService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
