using MongoDB.Driver;

namespace MyBills.Infra.IoC
{
    public class DataAccess
    {
        public MongoClient client;
        public MongoServer server;
        public MongoDatabase db;

        public DataAccess()
        {
            client = new MongoClient("mongodb://localhost:27017");
            server = client.GetServer();
            db = server.GetDatabase("MyBillsDB");
        }
    }
}
