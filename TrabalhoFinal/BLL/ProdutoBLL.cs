using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProdutoBLL
    {
        public static List<Produto> Get()
        {
            return ProdutoDAL.Get();
        }

        public static Produto Get(string codigoBarra)
        {
            return ProdutoDAL.Get(codigoBarra);
        }

        public static void Post(string descricao, double valorUnitario)
        {
            ProdutoDAL.Post(descricao, valorUnitario);
        }

        public static void Put(string codigoBarra, string descricao, double valorUnitario)
        {
            ProdutoDAL.Put(codigoBarra, descricao, valorUnitario);
        }

        public static void Delete(string codigoBarra)
        {
            ProdutoDAL.Delete(codigoBarra);
        }
        public static double CalcularValorDoItem(string codigoBarra, int quantidadeAdquirida)
        {
            var produto = ProdutoDAL.Get(codigoBarra);
            return produto != null ? produto.ValorUnitario * quantidadeAdquirida : -1;
        }
    }
}
