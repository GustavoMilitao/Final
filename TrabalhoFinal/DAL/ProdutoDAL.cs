using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal;

namespace DAL
{
    public class ProdutoDAL
    {
        public static List<Produto> Get()
        {
            var db = ConnectionClass.Connection;
            var cidades = db.GetCollection<Produto>("produtos");
            return cidades.FindSync<Produto>(null).Current.ToList();
        }
    }
}
