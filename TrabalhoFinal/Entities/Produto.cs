using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Produto
    {
        public ObjectId _id { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeNoEstoque { get; set; }
        public double ValorUnitario { get; set; }

        public Produto(string descricao, double valorUnitario, int quantidadeNoEstoque)
        {
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            QuantidadeNoEstoque = quantidadeNoEstoque;
        }
    }
}
