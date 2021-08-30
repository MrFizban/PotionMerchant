using MongoDB.Bson.Serialization.Attributes;

namespace PotionMerchant.Entity
{
    public class CubeSize
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        [BsonConstructor]
        public CubeSize(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    
    
}