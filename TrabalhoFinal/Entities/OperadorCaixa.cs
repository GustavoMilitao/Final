using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OperadorCaixa
    {
        public ObjectId _id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public OperadorCaixa(string nome, string usuario, string senha)
        {
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
        }
    }
}
