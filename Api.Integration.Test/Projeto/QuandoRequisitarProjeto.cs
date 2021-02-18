using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.dtos.projeto;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Projeto
{
    public class QuandoRequisitarProjeto : BaseIntegration
    {

        private string _name { get; set; }

        [Fact]
        public async Task E_Possivel_Realizar_Crud_Projeto()
        {

            _name = Faker.Name.FullName();

            var projetoDtoCreate = new ProjetoDtoCreate
            {
                Name = _name
            };

            //POST
            response = await PostJsonAsync(projetoDtoCreate, $"{hostApi}projetos", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<ProjetoDto>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPost.Name);
            Assert.True(registroPost.Id != default(Guid));

            //Get All
            response = await client.GetAsync($"{hostApi}projetos");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<ProjetoDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count() > 0);

            //PUT
            var projetoUpdate = new ProjetoDto
            {
                Id = registroPost.Id,
                Name = Faker.Name.Last(),
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(projetoUpdate),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}projetos", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<ProjetoDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Name, registroAtualizado.Name);

            //GET ID
            response = await client.GetAsync($"{hostApi}projetos/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<ProjetoDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Name, registroAtualizado.Name);

            // //DELETE
            response = await client.DeleteAsync($"{hostApi}projetos/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}projetos/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
