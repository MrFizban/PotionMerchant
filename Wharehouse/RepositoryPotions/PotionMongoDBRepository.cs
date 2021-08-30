using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PotionMerchant.Entity;

namespace PotionMerchant.Repository
{
    public class PotionMongoDBRepository: IPotionRepository
    {
        
        private readonly IMongoCollection<Potion> ingrediantsCollection;
        private readonly FilterDefinitionBuilder<Potion> _filterDefinitionBuilder = Builders<Potion>.Filter;

        public PotionMongoDBRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase("PotionsCatalog");
            ingrediantsCollection = database.GetCollection<Potion>("ingediant");
        }
        
        public Task<IEnumerable<Potion>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Potion> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CreateItemAsync(Potion item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(Potion item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}