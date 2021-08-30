using System;
using MongoDB.Bson.Serialization.Attributes;
using PotionMerchant.Entities;
using Realms;

namespace PotionMerchant.Entity
{
    public record Ingrediant
    {
        [PrimaryKey]
        public Guid id { get; set; }
        public string name { get; set; }
        public string effetti { get; set; }
        public string descriptionShort { get; set; }
        public string descriptionLong { get; set; }
        public string price { get; set; }
        public string weight { get; set; }
        [BsonSerializer(typeof(CubeSizeSerializer))]
        public CubeSize size { get; set; }
    }
}