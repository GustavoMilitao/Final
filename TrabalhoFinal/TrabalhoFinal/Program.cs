using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace TrabalhoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            do
            {
                Console.Clear();
                Console.WriteLine("============== Sistema de gestão de vendas e produtos (SGVP) ==============\n\n");

                Console.WriteLine("============== Digite a opção desejada e tecle ENTER ==============\n");
                Console.WriteLine("a) Produtos\n");
                Console.WriteLine("b) Operadores Caixa\n");
                Console.WriteLine("c) Vendas\n");

                input = Console.ReadLine();
                switch (input)
                {
                    case "a": menuGetProdutos(); break;
                    case "b":menuGetOperadoresCaixa();break;
                    case "c": MenuVendas(); break;
                }

            } while (input != "0");
        }

        public static void EmitirCupomFiscal(string codigoVenda)
        {
            Console.Clear();
            var venda = VendaBLL.Get(codigoVenda);
            if (venda != null)
            {
                Console.WriteLine("============ Venda ============");
                Console.WriteLine("Código venda : "+venda._id);
                Console.WriteLine("============ Produtos ============");
                foreach (var produtoVenda in venda.Produtos)
                {
                    Console.WriteLine("\t" + produtoVenda.Quantidade + " x " + produtoVenda.Descricao
                        + "(" + String.Format(new CultureInfo("pt-BR"), "{0:C}", produtoVenda.ValorUnitario) + ")"
                        + " = " + String.Format(new CultureInfo("pt-BR"), "{0:C}", produtoVenda.ValorTotalProdutoVenda));
                }
                Console.WriteLine("============ Venda ============");
            }
            else
            {
                Console.WriteLine("O código da venda digitada não existe na base de dados!");
                Console.ReadKey();
            }
        }

        public static void MenuVendas()
        {
            Console.Clear();
            Console.WriteLine("============== VENDAS ==============\n");
            Console.WriteLine("a) Visualizar\n");
            Console.WriteLine("b) Inserir\n");
            Console.WriteLine("c) Atualizar\n");
            Console.WriteLine("d) Deletar\n");
            Console.WriteLine("0 - Sair\n");

            string input = Console.ReadLine();
            while (input != "a" && input != "b" && input != "c" && input != "d" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("a) Visualizar\n");
                Console.WriteLine("b) Inserir\n");
                Console.WriteLine("c) Atualizar\n");
                Console.WriteLine("d) Deletar\n");
                Console.WriteLine("0 - Sair\n");
                input = Console.ReadLine();
            }
            Console.Clear();
            switch (input)
            {
                case "a": menuGetVendas();break;
            }
        }

        public static void MenuEstoque()
        {
            Console.WriteLine("============== ESTOQUE ==============\n");
            Console.WriteLine("b) Inserir\n");
            Console.WriteLine("c) Remover\n");
        }

        public static void MenuOperadores()
        {
            Console.WriteLine("============== OPERADORES DE CAIXA ==============\n");
            Console.WriteLine("a) Visualizar\n");
            Console.WriteLine("b) Inserir\n");
            Console.WriteLine("c) Atualizar\n");
            Console.WriteLine("d) Deletar\n");
        }

        public static void MenuProdutos()
        {
            Console.WriteLine("============== PRODUTOS ==============\n");
            Console.WriteLine("a) Visualizar\n");
            Console.WriteLine("b) Inserir\n");
            Console.WriteLine("c) Atualizar\n");
            Console.WriteLine("d) Deletar\n");
        }
        public static void menuGetVendas()
        {
            Console.Clear();
            Console.WriteLine("Digite :\n1 - todas as vendas\n2 - Selecionar uma venda pelo código\n0 - Voltar");
            string input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("Digite :\n1 - todas as vendas\n2 - Selecionar uma venda pelo código\n0 - Voltar");
                input = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            if (input == "1")
            {
                var vendas = VendaBLL.Get();
                Console.Clear();
                Console.WriteLine(" ============== VENDAS ============== ");
                foreach (var venda in vendas)
                {
                    Console.WriteLine("============ Venda ============");
                    Console.WriteLine("Código venda : " + venda._id);
                    Console.WriteLine("============ Produtos ============");
                    foreach (var produtoVenda in venda.Produtos)
                    {
                        Console.WriteLine("\t" + produtoVenda.Quantidade + " x " + produtoVenda.Descricao
                            + "(" + String.Format(new CultureInfo("pt-BR"), "{0:C}", produtoVenda.ValorUnitario) + ")"
                            + " = " + String.Format(new CultureInfo("pt-BR"), "{0:C}", produtoVenda.ValorTotalProdutoVenda));
                    }
                    Console.WriteLine("Total venda : " + String.Format(new CultureInfo("pt-BR"), "{0:C}", venda.ValorTotal));
                    Console.WriteLine("Método de pagamento : " + venda.FormaPagamento.Value.GetDescription());
                    Console.WriteLine("============ Venda ============");
                }
                Console.WriteLine("Digite qualquer tecla para voltar");
                Console.ReadKey();
            }
            else if (input == "2")
            {
                Console.WriteLine("Codigo da venda : ");
                String cod = Console.ReadLine();
                var venda = VendaBLL.Get(cod);
                Console.Clear();
                if (venda != null)
                {
                    Console.WriteLine("============ Venda ============");
                    Console.WriteLine("Código venda : " + venda._id);
                    Console.WriteLine("============ Produtos ============");
                    foreach (var produtoVenda in venda.Produtos)
                    {
                        Console.WriteLine("\t" + produtoVenda.Quantidade + " x " + produtoVenda.Descricao
                            + "(" + String.Format(new CultureInfo("pt-BR"), "{0:C}", produtoVenda.ValorUnitario) + ")"
                            + " = " + String.Format(new CultureInfo("pt-BR"), "{0:C}", produtoVenda.ValorTotalProdutoVenda));
                    }
                    Console.WriteLine("Total venda : " + String.Format(new CultureInfo("pt-BR"), "{0:C}", venda.ValorTotal));
                    Console.WriteLine("============ Venda ============");
                }
                else
                {
                    Console.WriteLine("venda não cadastrada.");
                }
                Console.WriteLine("Digite qualquer tecla para voltar");
                Console.ReadKey();
            }
        }

        public static void menuGetOperadoresCaixa()
        {
            Console.Clear();
            Console.WriteLine("Digite :\n1 - todos os Operadores\n2 - Selecionar um Operador pelo código\n0 - Voltar");
            string input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("Digite :\n1 - todos os Operadores\n2 - Selecionar um Operador pelo código\n0 - Voltar");
                input = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            if (input == "1")
            {
                var operadores = OperadorCaixaBLL.Get();
                Console.Clear();
                Console.WriteLine(" ============== OPERADORES ============== ");
                foreach (var operador in operadores)
                {
                    Console.WriteLine("Codigo : " + operador._id);
                    Console.WriteLine("Nome : " + operador.Nome);
                    Console.WriteLine("Usuário : " + operador.Usuario);
                    Console.WriteLine("Senha : " + operador.Senha);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("Digite qualquer tecla para voltar");
                Console.ReadKey();
            }
            else if (input == "2")
            {
                Console.WriteLine("Codigo de barras : ");
                String cod = Console.ReadLine();
                var operador = OperadorCaixaBLL.Get(cod);
                Console.Clear();
                if (operador != null)
                {
                    Console.WriteLine("Codigo : " + operador._id);
                    Console.WriteLine("Nome : " + operador.Nome);
                    Console.WriteLine("Usuário : " + operador.Usuario);
                    Console.WriteLine("Senha : " + operador.Senha);
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("operador não cadastrado.");
                }
                Console.WriteLine("Digite qualquer tecla para voltar");
                Console.ReadKey();
            }
        }

        public static void menuGetProdutos()
        {
            Console.Clear();
            Console.WriteLine("Digite :\n1 - todos os produtos\n2 - Selecionar um produto pelo código de barras\n0 - Voltar");
            string input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("Digite :\n1 - todos os produtos\n2 - Selecionar um produto pelo código de barras\n0 - Voltar");
                input = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            if (input == "1")
            {
                var produtos = ProdutoBLL.Get();
                Console.Clear();
                Console.WriteLine(" ============== PRODUTOS ============== ");
                foreach (var produto in produtos)
                {
                    Console.WriteLine("Codigo de barras : " + produto._id);
                    Console.WriteLine("Descrição : " + produto.Descricao);
                    Console.WriteLine("Valor unitário : " + String.Format(new CultureInfo("pt-BR"), "{0:C}", produto.ValorUnitario));
                    Console.WriteLine("Quantidade no estoque : " + produto.QuantidadeNoEstoque);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("Digite qualquer tecla para voltar");
                Console.ReadKey();
            }
            else if (input == "2")
            {
                Console.WriteLine("Codigo de barras : ");
                String cod = Console.ReadLine();
                var produto = ProdutoBLL.Get(cod);
                Console.Clear();
                if (produto != null)
                {
                    Console.WriteLine("Codigo de barras : " + produto._id);
                    Console.WriteLine("Descrição : " + produto.Descricao);
                    Console.WriteLine("Valor unitário : " + String.Format(new CultureInfo("pt-BR"), "{0:C}", produto.ValorUnitario));
                    Console.WriteLine("Quantidade no estoque : " + produto.QuantidadeNoEstoque);
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("Produto não cadastrado.");
                }
                Console.WriteLine("Digite qualquer tecla para voltar");
                Console.ReadKey();
            }
        }
    }
}
