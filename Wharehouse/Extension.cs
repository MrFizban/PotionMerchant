using Catalog.Dto;
using Catalog.Entities;
using PotionMerchant.Entity;

namespace Catalog
{
    public static class Extension
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                id = item.id,
                name = item.name,
                price = item.price,
                CreateData = item.CreateData
            };
        }
        
        public static IngrediantDto AsDto(this Ingrediant ingrediant)
        {
            return new IngrediantDto()
            {
                id = ingrediant.id,
                name = ingrediant.name,
                effetti = ingrediant.effetti,
                descriptionShort = ingrediant.descriptionShort,
                descriptionLong = ingrediant.descriptionLong,
                price = ingrediant.price,
                weight = ingrediant.weight,
                size = ingrediant.size
            };
        }
    }
}