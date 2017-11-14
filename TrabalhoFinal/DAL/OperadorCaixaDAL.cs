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
    public class OperadorCaixaDAL
    {
        public static List<OperadorCaixa> Get()
        {
            var db = ConnectionClass.Connection;
            var OperadoresCaixa = db.GetCollection<OperadorCaixa>("OperadoresCaixa");
            return OperadoresCaixa.Find(_ => true).ToList();
        }

        public static OperadorCaixa Get(string codigoOperador)
        {
            var db = ConnectionClass.Connection;
            var OperadoresCaixa = db.GetCollection<OperadorCaixa>("OperadoresCaixa");
            var filter = Builders<OperadorCaixa>.Filter.Eq("_id", new ObjectId(codigoOperador));
            return OperadoresCaixa.Find(filter).FirstOrDefault();
        }

        public static void Post(string nome, string usuario, string senha)
        {
            var db = ConnectionClass.Connection;
            var OperadoresCaixa = db.GetCollection<OperadorCaixa>("OperadoresCaixa");
            OperadoresCaixa.InsertOne(new OperadorCaixa(nome, usuario, senha));
        }

        public static void Put(string codigoOperador, string nome, string usuario, string senha)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<OperadorCaixa>.Filter.Eq("_id", new ObjectId(codigoOperador));
            var OperadoresCaixa = db.GetCollection<OperadorCaixa>("OperadoresCaixa");
            var update = Builders<OperadorCaixa>.Update.Set("Nome", nome).Set("Usuario", usuario).Set("Senha", senha);
            OperadoresCaixa.UpdateOne(filter, update) ;
        }

        public static void Delete(string codigoOperador)
        {
            var db = ConnectionClass.Connection;
            var filter = Builders<OperadorCaixa>.Filter.Eq("_id", new ObjectId(codigoOperador));
            var OperadoresCaixa = db.GetCollection<OperadorCaixa>("OperadoresCaixa");
            OperadoresCaixa.DeleteOne(filter);
        }
    }
}
