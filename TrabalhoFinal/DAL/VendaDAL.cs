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
using Util;

namespace DAL
{
    public class VendaDAL
    {
        public static List<Venda> Get()
        {
            var db = ConnectionClass.Connection;
            var vendas = db.GetCollection<Venda>("vendas");
            return vendas.Find(_ => true).ToList();
        }

        public static Venda Get(string codigoVenda)
        {
            var db = ConnectionClass.Connection;
            var vendas = db.GetCollection<Venda>("vendas");
            var filter = Builders<Venda>.Filter.Eq("_id", new ObjectId(codigoVenda));
            return vendas.Find(filter).FirstOrDefault();
        }

        public static void Post(List<ProdutoVenda> produtos, double valorTotal, FormasPagamento formaPagamento)
        {
            var db = ConnectionClass.Connection;
            var vendas = db.GetCollection<Venda>("vendas");
            vendas.InsertOne(new Venda(produtos, valorTotal, formaPagamento));
        }

        public static void Put(string codigoVenda, List<ProdutoVenda> produtos, double valorTotal, FormasPagamento formaPagamento)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<Venda>.Filter.Eq("_id", new ObjectId(codigoVenda));
            var vendas = db.GetCollection<Venda>("vendas");
            var update = Builders<Venda>.Update.Set("Produtos", produtos)
                .Set("ValorTotal", valorTotal)
                .Set("FormaPagamento", formaPagamento);
            vendas.UpdateOne(filter, update);
        }

        public static void Delete(string codigoVenda)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<Venda>.Filter.Eq("_id", new ObjectId(codigoVenda));
            var vendas = db.GetCollection<Venda>("vendas");
            vendas.DeleteOne(filter);
        }
    }
}
