using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProdutoVenda
    {
        public ObjectId _id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotalProdutoVenda { get; set; }
        public ProdutoVenda(string descricao, double valorUnitario, int quantidade, double valorTotalProdutoVenda)
        {
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
            ValorTotalProdutoVenda = valorTotalProdutoVenda;
        }
    }
}
