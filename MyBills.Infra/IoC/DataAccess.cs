using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MyBills.Infra.IoC
{
    public class DataAccess
    {
        public MongoClient client;
        public MongoServer server;
        public MongoDatabase db;

        public DataAccess(IConfiguration configuration)
        {
            client = new MongoClient(configuration["DefaultConnection:Url"]);
            server = client.GetServer();
            db = server.GetDatabase(configuration["DefaultConnection:DataBase"]);
        }
    }
}
