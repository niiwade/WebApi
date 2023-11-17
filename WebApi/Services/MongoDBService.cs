using WebApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Cryptography.X509Certificates;

namespace WebApi.Services
{
    public class MongoDBService
    {

        private readonly IMongoCollection<Startup> _startupCollection;
        //private readonly IMongoCollection<User> _userColection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBsettings)
        {
            MongoClient client = new MongoClient (mongoDBsettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBsettings.Value.DatabaseName);
            _startupCollection = database.GetCollection<Startup>(mongoDBsettings.Value.CollectionName);
           // _userColection = database.GetCollection<User>(mongoDBsettings.Value.CollectionName);

           

        }

        public async Task CreateAsync(Startup startup)
        {
            await _startupCollection.InsertOneAsync(startup);
            return;
        }


        public async Task<List<Startup>> GetAsync()
        {
            return await _startupCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddtoStartup(string id, string startupId)
        {
            FilterDefinition<Startup> filter = Builders<Startup>.Filter.Eq("Id", id);
            UpdateDefinition<Startup> update = Builders<Startup>.Update.AddToSet<string>("startupId", startupId);
            await _startupCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Startup> filter = Builders<Startup>.Filter.Eq("Id", id);
            await _startupCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
