using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Events.Data.Database
{
    public class EventRepository : IEventRepository
    {
        private IMongoCollection<Event> _events;

        public EventRepository(IMongoCollection<Event> events)
        {
            _events = events;
        }

        public async Task<Event> Get(string id)
        {
            return await _events.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        
        public Task<IEnumerable<Event>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Add(Event eventModel)
        {
            await _events.InsertOneAsync(eventModel);

            return eventModel.Id;
        }

        public async Task Update(Event eventModel)
        {
            await _events.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(eventModel.Id)), eventModel);
        }

        public async Task Remove(string id)
        {
            await _events.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
