using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EstoqueBLL
    {
        public static bool ValidarQuantidadeEstoque(string codigoBarra, int quantidadeAdquirida)
        {
            var produto = ProdutoDAL.Get(codigoBarra);
            return produto != null && produto.QuantidadeNoEstoque >= quantidadeAdquirida;
        }

        public static void AtualizarEstoque(string codigoBarra, int quantidadeAdquirida)
        {
            EstoqueDAL.Delete(codigoBarra, quantidadeAdquirida);
        }

        public static void Put(string codigoBarra, int quantidade)
        {
            EstoqueDAL.Put(codigoBarra, quantidade);
        }

        public static void AdicionarAoEstoque(string codigoBarra, int quantidadeAAdicionar)
        {
            EstoqueDAL.AdicionarAoEstoque(codigoBarra, quantidadeAAdicionar);
        }

        public static int GetQuantidadeNoEstoque(string codigoBarra)
        {
            return EstoqueDAL.Get(codigoBarra);
        }

        public static List<Produto> ProdutosBaixaEstoque()
        {
            return EstoqueDAL.GetProdutosQtdAte(2);
        }
    }
}
