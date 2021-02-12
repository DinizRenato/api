using System.Collections.Generic;

namespace Api.Domain.entities
{
    public class ProjetoEntity : BaseEntity
    {

        public string Name { get; set; }

        public IEnumerable<MetadadoEntity> Metadados { get; set; }
    }
}
