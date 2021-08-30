using System.ComponentModel.DataAnnotations;
using PotionMerchant.Entity;

namespace Catalog.Dto
{
    public record CreatePotionDto
    {
        [Required]
        public string name { get; init; }
        [Required]
        public string effetti { get; init; }
        [Required]
        public string descriptionShort { get; init; }
        public string descriptionLong { get; init; }
        [Required]
        public string price { get; init; }
        [Required]
        public string weight { get; init; }
        [Required]
        public string quantity { get; init; }
        [Required]
        public CubeSize size { get; init; }
        [Required]
        public Recipe recipe { get; init; }
    }
}