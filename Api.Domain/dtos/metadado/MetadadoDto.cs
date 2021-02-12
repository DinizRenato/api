using System;

namespace Api.Domain.dtos.metadado
{
    public class MetadadoDto
    {
        public Guid Id { get; set; }
        public Guid ProjetoId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Options { get; set; }
    }
}
