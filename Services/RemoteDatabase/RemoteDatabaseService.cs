using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using RiseFoodServiceWork.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiseFoodServiceWork.Services.RemoteDatabase
{
    public class RemoteDatabaseService : IRemoteDatabaseService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoCollection<Supplie> _supplies;
        public RemoteDatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;


            var client = new MongoClient(_configuration.GetSection("DataBaseSettings").GetValue<string>("RemoteDatabase"));
            var database = client.GetDatabase("chapinha");
            _supplies = database.GetCollection<Supplie>("supplies");
        }

        public bool CollectionExist { get; private set; }

        public Task SaveSupplie(Supplie supplie)
        {
            _supplies.InsertOneAsync(supplie);
            
            return Task.CompletedTask;
        }

        public  bool IsCollectionExist()
        {
            var documents =  _supplies.CountDocuments(new BsonDocument());
            if (documents > 0) return true;

            return false;

        }
    }
}
