using System.ComponentModel.DataAnnotations;

namespace Api.Domain.dtos.projeto
{
    public class ProjetoDtoCreate
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string name { get; set; }
    }
}
