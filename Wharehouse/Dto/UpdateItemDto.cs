using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dto
{
    public record UpdateItemDto
    {
        [Required]
        public String name {get; init;}
        [Required]
        [Range(1,1000000)]
        public decimal price {get; init;}
    }
}