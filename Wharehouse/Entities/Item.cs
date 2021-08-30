using System;

namespace Catalog.Entities{

    public record Item {
        public Guid id {get; init;}
        public String name {get; init;}
        public decimal price {get; init;}
        public DateTimeOffset CreateData {get; init;}
    }
}