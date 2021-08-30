using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using PotionMerchant.Entity;

namespace PotionMerchant.Entities
{
    public class CubeSizeSerializer : IBsonSerializer<CubeSize>
    {
      

        public Type ValueType => typeof(CubeSize);

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, CubeSize value)
        {
            BsonSerializer.Serialize(context.Writer, value);
        }

        CubeSize IBsonSerializer<CubeSize>.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            System.Console.WriteLine("Deserilize B");
            CubeSize p = BsonSerializer.Deserialize<CubeSize>(context.Reader);
            return new CubeSize(p.x, p.y, p.z);
        }

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            System.Console.WriteLine("Deserilize A");
            BsonDocument d = BsonSerializer.Deserialize<BsonDocument>(context.Reader);
            
            float x = 0;
            float y = 0;
            float z = 0;

            if (d["_t"] == "CubeSize")
            {
                x = (float) Convert.ToDecimal(d["x"]);
                y = (float) Convert.ToDecimal(d["y"]);
                z = (float) Convert.ToDecimal(d["z"]);
            }

            return new CubeSize(x, y, z);
        }
      
        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            BsonSerializer.Serialize(context.Writer, value);
        }
    }
}