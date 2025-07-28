using MongoDB.Driver;
using Licona.MyAcademy.Students.Domain.Ports.Store;
using Licona.MyAcademy.Students.Domain.Entities.Common;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Licona.MyAcademy.Students.Infrastructure.Store;

public class EventStore(
    IConfiguration config,
    IMongoCollection<BsonDocument> collection    
) : IEventStore
{
    public async Task SaveEvent(IEventBase @event)
    {
        var client = new MongoClient(config["Mongo:ConnectionString"]);
        var database = client.GetDatabase(config["Mongo:Database"]);
        collection = database.GetCollection<BsonDocument>("events");

        var doc = new BsonDocument
        {
            { "Id", @event.Id.ToString() },
            { "occurredOn", @event.OccurredOn },
            { "eventType", @event.GetType().Name },
            { "payload", BsonDocument.Parse(JsonConvert.SerializeObject(@event.Event)) }
        };
        await collection.InsertOneAsync(doc);
    }
}
