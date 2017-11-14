using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OperadorCaixaBLL
    {
        public static List<OperadorCaixa> Get()
        {
            return OperadorCaixaDAL.Get();
        }

        public static OperadorCaixa Get(string codigoOperador)
        {
            return OperadorCaixaDAL.Get(codigoOperador);
        }

        public static void Post(string nome, string usuario, string senha)
        {
            OperadorCaixaDAL.Post(nome, usuario, senha);
        }

        public static void Put(string codigoOperador, string nome, string usuario, string senha)
        {
            OperadorCaixaDAL.Put(codigoOperador, nome, usuario, senha);
        }

        public static void Delete(string codigoOperador)
        {
            OperadorCaixaDAL.Delete(codigoOperador);
        }
    }
}
