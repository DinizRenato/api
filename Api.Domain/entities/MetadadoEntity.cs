using System;

namespace Api.Domain.entities
{
    public class MetadadoEntity : BaseEntity
    {
        public Guid ProjetoId { get; set; }

        public ProjetoEntity Projeto { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Options { get; set; }
    }
}
