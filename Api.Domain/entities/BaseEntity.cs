using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

    }
}
