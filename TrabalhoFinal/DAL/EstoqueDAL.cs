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
    public class EstoqueDAL
    {
        public static int Get(string codigoBarra)
        {
            var db = ConnectionClass.Connection;
            var produtos = db.GetCollection<Produto>("produtos");
            var filter = Builders<Produto>.Filter.Eq("_id", new ObjectId(codigoBarra));
            return produtos.Find(filter).FirstOrDefault().QuantidadeNoEstoque;
        }
        public static List<Produto> GetProdutosQtdAte(int quantidade)
        {
            var db = ConnectionClass.Connection;
            var produtos = db.GetCollection<Produto>("produtos");
            var filter = Builders<Produto>.Filter.Lte("QuantidadeNoEstoque", quantidade);
            return produtos.Find(filter).ToList();
        }
        public static void Put(string codigoBarra, int quantidadeEstoque)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<Produto>.Filter.Eq("_id", new ObjectId(codigoBarra));
            var produtos = db.GetCollection<Produto>("produtos");
            var update = Builders<Produto>.Update.Set("QuantidadeNoEstoque", quantidadeEstoque);
            produtos.UpdateOne(filter, update);
        }

        public static void Delete(string codigoBarra, int quantidadeARetirar)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<Produto>.Filter.Eq("_id", new ObjectId(codigoBarra));
            var produtos = db.GetCollection<Produto>("produtos");
            var novaQtd = (ProdutoDAL.Get(codigoBarra).QuantidadeNoEstoque - quantidadeARetirar < 0) ? 0 
                : ProdutoDAL.Get(codigoBarra).QuantidadeNoEstoque - quantidadeARetirar;
            var update = Builders<Produto>.Update.Set("QuantidadeNoEstoque", novaQtd);
            produtos.UpdateOne(filter, update);
        }

        public static void AdicionarAoEstoque(string codigoBarra, int quantidadeAAdicionar)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<Produto>.Filter.Eq("_id", new ObjectId(codigoBarra));
            var produtos = db.GetCollection<Produto>("produtos");
            var novaQtd = ProdutoDAL.Get(codigoBarra).QuantidadeNoEstoque + quantidadeAAdicionar;
            var update = Builders<Produto>.Update.Set("QuantidadeNoEstoque", novaQtd);
            produtos.UpdateOne(filter, update);
        }
    }
}
