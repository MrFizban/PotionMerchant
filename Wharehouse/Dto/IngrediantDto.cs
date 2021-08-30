using System;
using PotionMerchant.Entity;

namespace Catalog.Dto
{
    public record IngrediantDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string effetti { get; set; }
        public string descriptionShort { get; set; }
        public string descriptionLong { get; set; }
        public string price { get; set; }
        public string weight { get; set; }
        public CubeSize size { get; set; }
    }
}