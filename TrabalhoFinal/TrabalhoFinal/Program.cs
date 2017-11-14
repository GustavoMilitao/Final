using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            do
            {
                Console.WriteLine(" ============== Sistema de gestão de vendas e produtos (SGVP) ==============\n\n");

                Console.WriteLine(" ============== Digite a opção desejada e tecle ENTER ==============");


            } while (input != "0");
        }

        public static void EmitirCupomFiscal(string codigoVenda)
        {
            var venda = VendaBLL.Get(codigoVenda);
            if (venda != null)
            {
                Console.WriteLine("============ Venda ============");
                Console.WriteLine(venda._id);
                Console.WriteLine("============ Produtos ============");
                foreach (var produtoVenda in venda.Produtos)
                {
                    Console.WriteLine("\t" + produtoVenda.Quantidade + " x " + produtoVenda.Descricao
                        + "(R$ " + String.Format(new CultureInfo("pt-BR"), "{0:C}", produtoVenda.ValorUnitario) + ")"
                        + " = R$ " + String.Format(new CultureInfo("pt-BR"), "{0:C}", produtoVenda.ValorTotalProdutoVenda));
                }
                Console.WriteLine("============ Venda ============");
            }
            else
            {
                Console.WriteLine("O código da venda digitada não existe na base de dados!");
                Console.ReadKey();
            }
        }

        public static void menuGetProdutos()
        {
            Console.WriteLine("Digite :\n1 - todos os produtos\n2 - Selecionar um produto pelo código de barras\n0 - Voltar)");
            string input = Console.ReadLine();
            do
            {
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("Digite :\n1 - todos os produtos\n2 - Selecionar um produto pelo código de barras\n0 - Voltar)");
            } while (input != "1" && input != "2" && input != "0");
            if (input == "1")
            {
                var produtos = ProdutoBLL.Get();
                Console.WriteLine(" ============== PRODUTOS ============== ");
                foreach (var produto in produtos)
                {
                    Console.WriteLine("Codigo de barras : " + produto._id);
                    Console.WriteLine("Descrição : " + produto.Descricao);
                    Console.WriteLine("Valor unitário : " + String.Format(new CultureInfo("pt-BR"), "{0:C}", produto.ValorUnitario));
                    Console.WriteLine("\n");
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("Codigo de barras : ");
                String cod = Console.ReadLine();
                var produto = ProdutoBLL.Get(cod);
                if (produto != null)
                {

                }
                else
                {

                }
            }
        }
    }
}
