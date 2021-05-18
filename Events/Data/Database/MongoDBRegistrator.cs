using Events.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Events.Data.Database
{
    public static class MongoDBRegistrator
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, string connection)
        {
            var builder = new MongoUrlBuilder(connection);

            services.AddSingleton<IMongoClient>(f => new MongoClient(builder.ToMongoUrl()));
            services.AddSingleton(f => f.GetRequiredService<IMongoClient>().GetDatabase(builder.DatabaseName));

            services.AddSingleton(f => f.GetRequiredService<IMongoDatabase>().GetCollection<Event>("events"));

            return services;
        }
    }
}
