using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PotionMerchant.Entity;

namespace PotionMerchant.Repository
{
    public interface IIngrediantRepository
    {
        Task<IEnumerable<Ingrediant>> GetIngrediantsAsync();
        Task<Ingrediant> GetIngrediantAsync(Guid id);
        Task CreateIngrediantAsync(Ingrediant ingrediant);
        Task UpdateIngrediantAsync(Ingrediant ingrediant);
        Task DeleteIngrediantAsync(Guid id);
    }
}