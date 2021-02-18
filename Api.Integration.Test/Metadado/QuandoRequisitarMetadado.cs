using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.dtos.metadado;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Metadado
{
    public class QuandoRequisitarMetadado : BaseIntegration
    {
        private int _order { get; set; }
        private string _name { get; set; }
        private string _type { get; set; }
        private string _options { get; set; }

        [Fact]
        public async Task E_Possivel_Realizar_Crud_Metadado()
        {

            _order = Faker.RandomNumber.Next(1, 1000);
            _name = Faker.Name.FullName();
            _type = Faker.Lorem.GetFirstWord();
            _options = Faker.Internet.DomainWord();

            var metadadoCreate = new MetadadoDtoCreate
            {

                ProjetoId = new Guid("99AFCD07-A341-4530-BC81-A61C7E333C38"),
                Order = _order,
                Name = _name,
                Type = _type,
                Options = _options

            };

            //Post
            var response = await PostJsonAsync(metadadoCreate, $"{hostApi}metadados", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<MetadadoDto>(postResult);
            Assert.Equal(_order, registroPost.Order);
            Assert.Equal(_name, registroPost.Name);
            Assert.Equal(_type, registroPost.Type);
            Assert.Equal(_options, registroPost.Options);
            Assert.True(registroPost.Id != default(Guid));

            //Get All
            response = await client.GetAsync($"{hostApi}metadados");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<MetadadoDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);

            var metadadoUpdate = new MetadadoDto
            {
                Id = registroPost.Id,
                ProjetoId = new Guid("99AFCD07-A341-4530-BC81-A61C7E333C38"),
                Order = _order,
                Name = Faker.Name.FullName(),
                Type = _type,
                Options = _options

            };

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(metadadoUpdate),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}metadados", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<MetadadoDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.False(registroPost.Name == registroAtualizado.Name);


            //GET Id
            response = await client.GetAsync($"{hostApi}metadados/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<MetadadoDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Name, registroAtualizado.Name);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}metadados/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}metadados/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
