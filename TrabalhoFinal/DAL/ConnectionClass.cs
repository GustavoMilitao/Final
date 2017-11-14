using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    public class ConnectionClass
    {
        public static string connectionString = @"mongodb://eckounltd:cefet123@custerpokemon-shard-00-00-zznsg.mongodb.net:27017,custerpokemon-shard-00-01-zznsg.mongodb.net:27017,custerpokemon-shard-00-02-zznsg.mongodb.net:27017/test?ssl=true&replicaSet=CusterPokemon-shard-0&authSource=admin";

        public static IMongoDatabase Connection {
            get { if (Connection == null) { Connection = getNewConnection("SGN") } }
        }
        static IMongoDatabase getNewConnection(string dataBase)
        {
            MongoClient client = new MongoClient(connectionString);
            return client.GetDatabase(dataBase);
        }
    }
}
