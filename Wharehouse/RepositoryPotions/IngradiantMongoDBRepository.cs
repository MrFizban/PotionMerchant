using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using PotionMerchant.Entity;

namespace PotionMerchant.Repository
{
    public class IngradiantMongoDBRepository : IIngrediantRepository
    {
        
        
        private readonly IMongoCollection<Ingrediant> ingrediantsCollection;
        private readonly FilterDefinitionBuilder<Ingrediant> _filterDefinitionBuilder = Builders<Ingrediant>.Filter;

        public IngradiantMongoDBRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase("PotionsCatalog");
            ingrediantsCollection = database.GetCollection<Ingrediant>("ingediant");
        }


        public async Task<IEnumerable<Ingrediant>> GetIngrediantsAsync()
        {
            return await ingrediantsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Ingrediant> GetIngrediantAsync(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(ingrediant => ingrediant.id, id);
            return await ingrediantsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateIngrediantAsync(Ingrediant ingrediant)
        {
            await this.ingrediantsCollection.InsertOneAsync(ingrediant);
            Console.WriteLine("ingrediant iserted");
        }

        public async Task UpdateIngrediantAsync(Ingrediant ingrediant)
        {
            var filter = _filterDefinitionBuilder.Eq(existingigrediant => existingigrediant.id, ingrediant.id);
            await this.ingrediantsCollection.ReplaceOneAsync(filter, ingrediant);
        }

        public async Task DeleteIngrediantAsync(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(existingigrediant => existingigrediant.id, id);
            await this.ingrediantsCollection.DeleteOneAsync(filter);
        }
    }
}