﻿using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BLL
{
    public class VendaBLL
    {
        public static List<Venda> Get()
        {
            return VendaDAL.Get();
        }

        public static Venda Get(string codigoVenda)
        {
            return VendaDAL.Get(codigoVenda);
        }

        public static void Post(List<ProdutoVenda> produtos, double valorTotal, FormasPagamento formaPagamento)
        {
            VendaDAL.Post(produtos, valorTotal, formaPagamento);
        }

        public static void Put(string codigoVenda, List<ProdutoVenda> produtos, double valorTotal, FormasPagamento formaPagamento)
        {
            VendaDAL.Put(codigoVenda, produtos, valorTotal, formaPagamento);
        }

        public static void Delete(string codigoVenda)
        {
            VendaDAL.Delete(codigoVenda);
        }
    }
}
