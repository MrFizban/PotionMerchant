using System;

namespace Catalog.Dto
{
    public record ItemDto
    {
        public Guid id {get; init;}
        public String name {get; init;}
        public decimal price {get; init;}
        public DateTimeOffset CreateData {get; init;}
    }
}