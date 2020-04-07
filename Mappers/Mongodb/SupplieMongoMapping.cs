using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using RiseFoodServiceWork.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiseFoodServiceWork.Mappers
{
    public static class SupplieMongoMapping
    {
        public static void Mapper()
        {
            BsonClassMap.RegisterClassMap<Supplie>(map =>
            {
                map.AutoMap();
                map.UnmapMember(s => s.Id);
                map.MapMember(s => s.Price).SetSerializer(new DecimalSerializer(BsonType.Decimal128));
            });
        }

    }
}
