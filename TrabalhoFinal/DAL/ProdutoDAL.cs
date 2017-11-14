using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal;

namespace DAL
{
    public class ProdutoDAL
    {
        public static List<Produto> Get()
        {
            var db = ConnectionClass.Connection;
            var produtos = db.GetCollection<Produto>("produtos");
            return produtos.Find(_ => true).ToList();
        }

        public static Produto Get(string codigoBarra)
        {
            var db = ConnectionClass.Connection;
            var produtos = db.GetCollection<Produto>("produtos");
            var filter = Builders<Produto>.Filter.Eq("_id", new ObjectId(codigoBarra));
            return produtos.Find(filter).FirstOrDefault();
        }
        public static void Post(string descricao, double valorUnitario)
        {
            var db = ConnectionClass.Connection;
            var produtos = db.GetCollection<Produto>("produtos");
            produtos.InsertOne(new Produto(descricao, valorUnitario, 0));
        }

        public static void Put(string codigoBarra, string descricao, double valorUnitario)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<Produto>.Filter.Eq("_id", new ObjectId(codigoBarra));
            var produtos = db.GetCollection<Produto>("produtos");
            var update = Builders<Produto>.Update.Set("Descricao", descricao).Set("ValorUnitario", valorUnitario);
            produtos.UpdateOne(filter, update) ;
        }

        public static void Delete(string codigoBarra)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<Produto>.Filter.Eq("_id", new ObjectId(codigoBarra));
            var produtos = db.GetCollection<Produto>("produtos");
            produtos.DeleteOne(filter);
        }
    }
}
