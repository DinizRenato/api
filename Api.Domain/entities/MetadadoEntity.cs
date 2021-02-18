using System;
using System.Text.Json.Serialization;

namespace Api.Domain.entities
{
    public class MetadadoEntity : BaseEntity
    {
        public Guid ProjetoId { get; set; }
        [JsonIgnore]
        public ProjetoEntity Projeto { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Options { get; set; }
    }
}
