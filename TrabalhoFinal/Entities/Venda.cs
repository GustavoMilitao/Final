using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Entities
{
    public class Venda
    {
        public ObjectId _id { get; set; }
        public List<ProdutoVenda> Produtos { get; set; }
        public double ValorTotal { get; set; }
        public FormasPagamento? FormaPagamento { get; set; }

        public Venda(List<ProdutoVenda> produtos, double valorTotal, FormasPagamento? formaPagamento = null)
        {
            Produtos = produtos;
            ValorTotal = valorTotal;
            FormaPagamento = formaPagamento;
        }
    }
}
