using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PotionMerchant.Entity;

namespace PotionMerchant.Repository
{
    public interface IPotionRepository
    {
        Task<IEnumerable<Potion>> GetItemsAsync();
        Task<Potion> GetItemAsync(Guid id);
        Task CreateItemAsync(Potion item);
        Task UpdateItemAsync(Potion item);
        Task DeleteItemAsync(Guid id);
    }
}