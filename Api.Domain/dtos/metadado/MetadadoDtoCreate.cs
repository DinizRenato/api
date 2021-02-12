using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.dtos.metadado
{
    public class MetadadoDtoCreate
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid ProjetoId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Order é campo obrigatório")]
        public int Order { get; set; }

        [Required(ErrorMessage = "Name é campo obrigatório")]
        [StringLength(50, ErrorMessage = "Name deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type é campo obrigatório")]
        [StringLength(50, ErrorMessage = "Type deve ter no máximo {1} caracteres")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Options é campo obrigatório")]
        public string Options { get; set; }
    }
}
