using BLL;
using DAL;
using Entities;
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
                Console.WriteLine("a) Produtos");
                Console.WriteLine("b) Estoque");
                Console.WriteLine("c) Operadores Caixa");
                Console.WriteLine("d) Vendas");
                Console.WriteLine("e) Calcular item");
                Console.WriteLine("f) Validar item estoque item");
                Console.WriteLine("g) Emitir cupom fiscal");
                Console.WriteLine("h) Calcular valor desconto forma de pagamento");
                Console.WriteLine("i) Atualizar Estoque");
                Console.WriteLine("j) Produtos em baixa");
                Console.WriteLine("0 - Finalizar\n");

                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "a": MenuProdutos(); break;
                    case "b": MenuEstoque(); break;
                    case "c": MenuOperadores(); break;
                    case "d": MenuVendas(); break;
                    case "e": CalcularItem(); break;
                    case "f": ValidarQuantidadeEstoque(); break;
                    case "g": EmitirCupomFiscal();break;
                    case "h": CalcularValorDescontoFormaPagamento(); break;
                    case "i": UpdateEstoque();break;
                    case "j": ProdutosBaixoEstoque();break;
                }

            } while (input != "0");
        }

        public static void EmitirCupomFiscal()
        {
            Console.Clear();
            Console.WriteLine("Codigo da venda : ");
            String codigoVenda = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine("Aguarde ... ");
            var venda = VendaBLL.Get(codigoVenda);
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
                Console.WriteLine("============ Venda ============");
            }
            else
            {
                Console.WriteLine("O código da venda digitada não existe na base de dados!");
                Console.ReadKey();
            }
        }

        public static void MenuProdutos()
        {
            Console.Clear();
            Console.WriteLine("============== PRODUTOS ==============\n");
            Console.WriteLine("a) Visualizar\n");
            Console.WriteLine("b) Inserir\n");
            Console.WriteLine("c) Atualizar\n");
            Console.WriteLine("d) Deletar\n");
            string input = Console.ReadLine().ToLower();
            while (input != "a" && input != "b" && input != "c" && input != "d" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("a) Visualizar\n");
                Console.WriteLine("b) Inserir\n");
                Console.WriteLine("c) Atualizar\n");
                Console.WriteLine("d) Deletar\n");
                Console.WriteLine("0 - Sair\n");
                input = Console.ReadLine().ToLower();
            }
            Console.Clear();
            switch (input)
            {
                case "a": MenuGetProdutos(); break;
                case "b": InsertProduto(); break;
                case "c": UpdateProduto(); break;
                case "d": DeleteProduto(); break;
            }
        }

        public static void MenuEstoque()
        {
            Console.Clear();
            Console.WriteLine("============== ESTOQUE ==============\n");
            Console.WriteLine("a) Inserir\n");
            Console.WriteLine("b) Remover\n");
            Console.WriteLine("0 - Sair\n");
            string input = Console.ReadLine().ToLower();
            while (input != "a" && input != "b" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("a) Inserir\n");
                Console.WriteLine("b) Remover\n");
                Console.WriteLine("0 - Sair\n");
                input = Console.ReadLine().ToLower();
            }
            Console.Clear();
            switch (input)
            {
                case "a": InsertEstoque(); break;
                case "b": DeleteEstoque(); break;
            }
        }

        public static void MenuOperadores()
        {
            Console.Clear();
            Console.WriteLine("============== OPERADORES DE CAIXA ==============\n");
            Console.WriteLine("a) Visualizar\n");
            Console.WriteLine("b) Inserir\n");
            Console.WriteLine("c) Atualizar\n");
            Console.WriteLine("d) Deletar\n");

            string input = Console.ReadLine().ToLower();
            while (input != "a" && input != "b" && input != "c" && input != "d" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("a) Visualizar\n");
                Console.WriteLine("b) Inserir\n");
                Console.WriteLine("c) Atualizar\n");
                Console.WriteLine("d) Deletar\n");
                Console.WriteLine("0 - Sair\n");
                input = Console.ReadLine().ToLower();
            }
            Console.Clear();
            switch (input)
            {
                case "a": MenuGetOperadores(); break;
                case "b": InsertOperador(); break;
                case "c": UpdateOperador(); break;
                case "d": DeleteOperador(); break;
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

            string input = Console.ReadLine().ToLower();
            while (input != "a" && input != "b" && input != "c" && input != "d" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("a) Visualizar\n");
                Console.WriteLine("b) Inserir\n");
                Console.WriteLine("c) Atualizar\n");
                Console.WriteLine("d) Deletar\n");
                Console.WriteLine("0 - Sair\n");
                input = Console.ReadLine().ToLower();
            }
            Console.Clear();
            switch (input)
            {
                case "a": menuGetVendas(); break;
                case "b": InsertVenda(); break;
                case "c": UpdateVenda(); break;
                case "d": DeleteVenda(); break;
            }
        }

        public static void MenuGetProdutos()
        {
            Console.Clear();
            Console.WriteLine("Digite :\n1 - todos os produtos\n2 - Selecionar um produto pelo código de barras\n0 - Voltar");
            string input = Console.ReadLine().ToLower();
            while (input != "1" && input != "2" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("Digite :\n1 - todos os produtos\n2 - Selecionar um produto pelo código de barras\n0 - Voltar");
                input = Console.ReadLine().ToLower();
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
                String cod = Console.ReadLine().ToLower();
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

        public static void MenuGetOperadores()
        {
            Console.Clear();
            Console.WriteLine("Digite :\n1 - todos os Operadores\n2 - Selecionar um Operador pelo código\n0 - Voltar");
            string input = Console.ReadLine().ToLower();
            while (input != "1" && input != "2" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("Digite :\n1 - todos os Operadores\n2 - Selecionar um Operador pelo código\n0 - Voltar");
                input = Console.ReadLine().ToLower();
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
                String cod = Console.ReadLine().ToLower();
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

        public static void menuGetVendas()
        {
            Console.Clear();
            Console.WriteLine("Digite :\n1 - todas as vendas\n2 - Selecionar uma venda pelo código\n0 - Voltar");
            string input = Console.ReadLine().ToLower();
            while (input != "1" && input != "2" && input != "0")
            {
                Console.Clear();
                Console.WriteLine(" ============== Opção inválida. ============== ");
                Console.WriteLine("Digite :\n1 - todas as vendas\n2 - Selecionar uma venda pelo código\n0 - Voltar");
                input = Console.ReadLine().ToLower();
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
                String cod = Console.ReadLine().ToLower();
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

        public static void InsertProduto()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite a descrição do produto (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var descricao = input;
            Console.Clear();
            Console.WriteLine("Digite o valor unitário do produto (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            double valorUnitario = 0;
            bool result = double.TryParse(input, out valorUnitario);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== ");
                Console.WriteLine("Digite o valor unitário do produto (0 - sair) :");
                input = Console.ReadLine();
                if (input == "0")
                    return;
                result = double.TryParse(input, out valorUnitario);
            }
            ProdutoBLL.Post(descricao, valorUnitario);

            Console.Clear();
            Console.WriteLine("Produto inserido com sucesso!");
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void InsertEstoque()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código de barras do produto para o qual deseja inserir estoque (0 - sair) :");
            input = Console.ReadLine().TrimEnd().TrimStart();
            if (input == "0")
                return;
            var codigoBarras = input;
            Console.Clear();
            Console.WriteLine("Digite a quantidade de estoque do produto para inserir (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            int quantidade = 0;
            bool result = int.TryParse(input, out quantidade);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== ");
                Console.WriteLine("Digite a quantidade de estoque do produto para inserir (0 - sair) :");
                input = Console.ReadLine();
                if (input == "0")
                    return;
                result = int.TryParse(input, out quantidade);
            }
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            var produto = ProdutoBLL.Get(codigoBarras);
            if (produto == null)
            {
                Console.Clear();
                Console.WriteLine("Produto inexistente!");
            }
            else
            {
                Console.Clear();
                EstoqueBLL.AdicionarAoEstoque(codigoBarras, quantidade);
                Console.WriteLine("Estoque incluído com sucesso");
            }
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void DeleteEstoque()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código de barras do produto para o qual deseja remover estoque (0 - sair) :");
            input = Console.ReadLine().TrimEnd().TrimStart();
            if (input == "0")
                return;
            var codigoBarras = input;
            Console.Clear();
            Console.WriteLine("Digite a quantidade de estoque do produto para remover (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            int quantidade = 0;
            bool result = int.TryParse(input, out quantidade);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== ");
                Console.WriteLine("Digite a quantidade de estoque do produto para remover (0 - sair) :");
                input = Console.ReadLine();
                if (input == "0")
                    return;
                result = int.TryParse(input, out quantidade);
            }
            var produto = ProdutoBLL.Get(codigoBarras);
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            if (produto == null)
            {
                Console.Clear();
                Console.WriteLine("Produto inexistente!");
            }
            else
            {
                Console.Clear();
                EstoqueBLL.AtualizarEstoque(codigoBarras, quantidade);
                Console.WriteLine("Estoque removido com sucesso");
            }
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void InsertOperador()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o nome do operador (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var nome = input;
            Console.Clear();
            Console.WriteLine("Digite o usuário do operador (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var usuario = input;
            Console.Clear();
            Console.WriteLine("Digite a senha do operador (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var senha = input;
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            OperadorCaixaBLL.Post(nome, usuario, senha);
            Console.Clear();
            Console.WriteLine("Operador inserido com sucesso!");
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void InsertVenda()
        {
            string input = String.Empty;
            Console.Clear();
            bool result = true;
            bool terminouLoop = false;
            List<Produto> produtosSelecionados = new List<Produto>();
            // ======== Buscando no banco os produtos cadastrados ======
            Console.WriteLine("Por favor aguarde ... ");
            var produtos = ProdutoBLL.Get();
            // ======== Transformando a lista de produtos em um dicionário numerado ======
            //              (para o usuário escolher mais facilmente na tela) 
            var dic = produtos.Where(p => p.QuantidadeNoEstoque > 0).Select((val, index) => new { Index = index, Value = val })
               .ToDictionary(i => i.Index, i => i.Value);
            // ======== Buscando no banco os produtos cadastrados ======
            do
            {
                // Recebendo os itens que o usuário quer
                Console.Clear();
                terminouLoop = false;
                foreach (KeyValuePair<int, Produto> produto in dic)
                {
                    if (produto.Value.QuantidadeNoEstoque > 0)
                    {
                        Console.WriteLine(produto.Key + " - " + produto.Value.Descricao);
                    }
                }
                Console.WriteLine("Digite o número do produto acima para adicioná-lo à venda (-2 para concluir, -1 - sair) :");
                input = Console.ReadLine();
                // saída do método de inserção
                if (input == "-1")
                    return;
                // término da adição de produtos à lista de produtos da venda
                if (input != "-2")
                {
                    // tratamento de exceção 
                    // (digitado um número de produto que não existe na lista ou caracteres alfanuméricos)
                    int produtoAdicionar = 0;
                    result = int.TryParse(input, out produtoAdicionar);
                    while (!result || !(dic[produtoAdicionar].QuantidadeNoEstoque > 0))
                    {
                        Console.Clear();
                        Console.WriteLine(" ============== Entrada inválida. ============== \n\n");
                        foreach (KeyValuePair<int, Produto> produto in dic)
                        {
                            if (produto.Value.QuantidadeNoEstoque > 0)
                            {
                                Console.WriteLine(produto.Key + " - " + produto.Value.Descricao);
                            }
                        }
                        Console.WriteLine("Digite o número do produto acima para adicioná-lo à venda (-2 para concluir, -1 - sair) :");
                        input = Console.ReadLine();
                        // saída do método de inserção
                        if (input == "-1")
                            return;
                        if (input == "-2")
                        {
                            // variável determinante para conseguir sair do segundo loop 
                            // (de iteração para escolha de itens)
                            terminouLoop = true;
                            break;
                        }
                        result = int.TryParse(input, out produtoAdicionar);
                    }
                    // Tratamento para certificar que o input foi correto.
                    if (dic[produtoAdicionar].QuantidadeNoEstoque > 0)
                    {
                        produtosSelecionados.Add(dic[produtoAdicionar]);
                        dic[produtoAdicionar].QuantidadeNoEstoque--;
                    }
                    if (terminouLoop)
                        break;
                }
            } while (input != "-2" && input != "-1");
            Console.Clear();
            // Recebendo e tratando formas de pagamento 
            // (formas de pagamentos estão no ENUM FormaPagamento e estão sendo listadas).
            Console.WriteLine("Digite a forma de pagamento : (-1 para sair)");
            var formasPagamento = Enum.GetValues(typeof(FormaPagamento)).Cast<FormaPagamento>();
            foreach (FormaPagamento pgto in formasPagamento)
            {
                Console.WriteLine((int)pgto + " - " + pgto.GetDescription());
            }
            input = Console.ReadLine();
            // Saída do método de inserção
            if (input == "-1")
                return;
            int formaPagamento = 0;
            // Tratamento de exceção: caracter inválido
            result = int.TryParse(input, out formaPagamento);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== \n\n");
                Console.WriteLine("Digite a forma de pagamento : (-1 para sair)");
                foreach (FormaPagamento pgto in formasPagamento)
                {
                    Console.WriteLine(pgto + " - " + pgto.GetDescription());
                }
                input = Console.ReadLine();
                if (input == "-1")
                    return;
                result = int.TryParse(input, out formaPagamento);
            }
            // Tratamento de exceção : Forma de pagamento não está na lista
            while (!formasPagamento.Any(f => f == (FormaPagamento)formaPagamento))
            {
                Console.Clear();
                Console.WriteLine(" ============== A forma de pagamento selecionada não existe na lista. Escolha outra ============== \n\n");
                Console.WriteLine("Digite a forma de pagamento : (-1 para sair)");
                foreach (FormaPagamento pgto in formasPagamento)
                {
                    Console.WriteLine(pgto + " - " + pgto.GetDescription());
                }
                input = Console.ReadLine();
                if (input == "-1")
                    return;
                result = int.TryParse(input, out formaPagamento);
            }
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            var pOnly = dic.Values.ToList();
            foreach(var p in pOnly)
            {
                EstoqueBLL.Put(p._id.ToString(), p.QuantidadeNoEstoque);
            }
            // Chamada do método do banco de dados
            VendaBLL.Post(converterListaProdutoListaProdutoVenda(produtosSelecionados), (FormaPagamento)formaPagamento);

            Console.Clear();
            Console.WriteLine("Venda inserida com sucesso!");
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void UpdateProduto()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código do produto (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var codigoProduto = input;
            Console.WriteLine("Digite a descrição do produto (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var descricao = input;
            Console.Clear();
            Console.WriteLine("Digite o valor unitário do produto (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            double valorUnitario = 0;
            bool result = double.TryParse(input, out valorUnitario);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== ");
                Console.WriteLine("Digite o valor unitário do produto (0 - sair) :");
                input = Console.ReadLine();
                if (input == "0")
                    return;
                result = double.TryParse(input, out valorUnitario);
            }
            ProdutoBLL.Put(codigoProduto, descricao, valorUnitario);

            Console.Clear();
            Console.WriteLine("Produto atualizado com sucesso!");
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void UpdateEstoque()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código de barras do produto para o qual deseja atualizar o estoque (0 - sair) :");
            input = Console.ReadLine().TrimEnd().TrimStart();
            if (input == "0")
                return;
            var codigoBarras = input;
            Console.Clear();
            Console.WriteLine("Digite a quantidade de estoque do produto para inserir (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            int quantidade = 0;
            bool result = int.TryParse(input, out quantidade);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== ");
                Console.WriteLine("Digite a quantidade de estoque do produto (0 - sair) :");
                input = Console.ReadLine();
                if (input == "0")
                    return;
                result = int.TryParse(input, out quantidade);
            }
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            var produto = ProdutoBLL.Get(codigoBarras);
            if (produto == null)
            {
                Console.Clear();
                Console.WriteLine("Produto inexistente!");
            }
            else
            {
                Console.Clear();
                EstoqueBLL.Put(codigoBarras, quantidade);
                Console.WriteLine("Estoque atualizado com sucesso");
            }
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void UpdateOperador()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código do operador (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var codigo = input;
            Console.WriteLine("Digite o nome do operador (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var nome = input;
            Console.Clear();
            Console.WriteLine("Digite o usuário do operador (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var usuario = input;
            Console.Clear();
            Console.WriteLine("Digite a senha do operador (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var senha = input;
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            OperadorCaixaBLL.Put(codigo, nome, usuario, senha);
            Console.Clear();
            Console.WriteLine("Operador atualizado com sucesso!");
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void UpdateVenda()
        {
            string input = String.Empty;
            Console.Clear();
            bool result = true;
            bool terminouLoop = false;
            List<Produto> produtosSelecionados = new List<Produto>();
            // ======== Buscando no banco os produtos cadastrados ======
            Console.WriteLine("Por favor aguarde ... ");
            var produtos = ProdutoBLL.Get();
            // ======== Transformando a lista de produtos em um dicionário numerado ======
            //              (para o usuário escolher mais facilmente na tela) 
            var dic = produtos.Select((val, index) => new { Index = index, Value = val })
               .ToDictionary(i => i.Index, i => i.Value);
            // ======== Buscando no banco os produtos cadastrados ======
            // Buscando a venda para edição
            Console.WriteLine("Digite o código da venda : ");
            var codigoVenda = Console.ReadLine();
            var venda = VendaBLL.Get(codigoVenda);
            if (venda == null)
            {
                Console.WriteLine("Venda não existe!");
                Console.ReadKey();
                return;
            }
            do
            {
                // Recebendo os itens que o usuário quer
                Console.Clear();
                terminouLoop = false;
                foreach (KeyValuePair<int, Produto> produto in dic)
                {
                    Console.WriteLine(produto.Key + " - " + produto.Value.Descricao);
                }
                Console.WriteLine("Digite o número do produto acima para adicioná-lo à venda (-2 para concluir, -1 - sair) :");
                input = Console.ReadLine();
                // saída do método de inserção
                if (input == "-1")
                    return;
                // término da adição de produtos à lista de produtos da venda
                if (input != "-2")
                {
                    // tratamento de exceção 
                    // (digitado um número de produto que não existe na lista ou caracteres alfanuméricos)
                    int produtoAdicionar = 0;
                    result = int.TryParse(input, out produtoAdicionar);
                    while (!result || !dic.ContainsKey(produtoAdicionar))
                    {
                        Console.Clear();
                        Console.WriteLine(" ============== Entrada inválida. ============== \n\n");
                        foreach (KeyValuePair<int, Produto> produto in dic)
                        {
                            Console.WriteLine(produto.Key + " - " + produto.Value.Descricao);
                        }
                        Console.WriteLine("Digite o número do produto acima para adicioná-lo à venda (-2 para concluir, -1 - sair) :");
                        input = Console.ReadLine();
                        // saída do método de inserção
                        if (input == "-1")
                            return;
                        if (input == "-2")
                        {
                            // variável determinante para conseguir sair do segundo loop 
                            // (de iteração para escolha de itens)
                            terminouLoop = true;
                            break;
                        }
                        result = int.TryParse(input, out produtoAdicionar);
                    }
                    // Tratamento para certificar que o input foi correto.
                    if (dic.ContainsKey(produtoAdicionar))
                    {
                        produtosSelecionados.Add(dic[produtoAdicionar]);
                    }
                    if (terminouLoop)
                        break;
                }
            } while (input != "-2" && input != "-1");
            Console.Clear();
            // Recebendo e tratando formas de pagamento 
            // (formas de pagamentos estão no ENUM FormaPagamento e estão sendo listadas).
            Console.WriteLine("Digite a forma de pagamento : (-1 para sair)");
            var formasPagamento = Enum.GetValues(typeof(FormaPagamento)).Cast<FormaPagamento>();
            foreach (FormaPagamento pgto in formasPagamento)
            {
                Console.WriteLine((int)pgto + " - " + pgto.GetDescription());
            }
            input = Console.ReadLine();
            // Saída do método de inserção
            if (input == "-1")
                return;
            int formaPagamento = 0;
            // Tratamento de exceção: caracter inválido
            result = int.TryParse(input, out formaPagamento);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== \n\n");
                Console.WriteLine("Digite a forma de pagamento : (-1 para sair)");
                foreach (FormaPagamento pgto in formasPagamento)
                {
                    Console.WriteLine(pgto + " - " + pgto.GetDescription());
                }
                input = Console.ReadLine();
                if (input == "-1")
                    return;
                result = int.TryParse(input, out formaPagamento);
            }
            // Tratamento de exceção : Forma de pagamento não está na lista
            while (!formasPagamento.Any(f => f == (FormaPagamento)formaPagamento))
            {
                Console.Clear();
                Console.WriteLine(" ============== A forma de pagamento selecionada não existe na lista. Escolha outra ============== \n\n");
                Console.WriteLine("Digite a forma de pagamento : (-1 para sair)");
                foreach (FormaPagamento pgto in formasPagamento)
                {
                    Console.WriteLine(pgto + " - " + pgto.GetDescription());
                }
                input = Console.ReadLine();
                if (input == "-1")
                    return;
                result = int.TryParse(input, out formaPagamento);
            }
            // Chamada do método do banco de dados
            VendaBLL.Put(codigoVenda, converterListaProdutoListaProdutoVenda(produtosSelecionados), (FormaPagamento)formaPagamento);

            Console.Clear();
            Console.WriteLine("Venda atualizada com sucesso!");
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void DeleteProduto()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código do produto (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var codigoBarras = input;
            var produto = ProdutoBLL.Get(codigoBarras);
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            if (produto == null)
            {
                Console.Clear();
                Console.WriteLine("Produto inexistente!");
            }
            else
            {
                Console.Clear();
                ProdutoBLL.Delete(codigoBarras);
                Console.WriteLine("Produto removido com sucesso!");
            }
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void DeleteOperador()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código do operador (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var codigo = input;
            var produto = OperadorCaixaBLL.Get(codigo);
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            if (produto == null)
            {
                Console.Clear();
                Console.WriteLine("Operador inexistente!");
            }
            else
            {
                Console.Clear();
                OperadorCaixaBLL.Delete(codigo);
                Console.WriteLine("Operador removido com sucesso!");
            }
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void DeleteVenda()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código da venda (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var codigo = input;
            var produto = VendaBLL.Get(codigo);
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            if (produto == null)
            {
                Console.Clear();
                Console.WriteLine("Venda inexistente!");
            }
            else
            {
                Console.Clear();
                VendaBLL.Delete(codigo);
                Console.WriteLine("Venda removida com sucesso!");
            }
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void CalcularItem()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código de barras do produto (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var codigo = input;
            Console.Clear();
            Console.WriteLine("Digite a quantidade adquirida (-1 - sair) :");
            input = Console.ReadLine();
            if (input == "-1")
                return;
            int quantidade = 0;
            bool result = int.TryParse(input, out quantidade);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== ");
                Console.WriteLine("Digite a quantidade adquirida (-1 - sair) :");
                input = Console.ReadLine();
                if (input == "-1")
                    return;
                result = int.TryParse(input, out quantidade);
            }
            Console.Clear();
            Console.WriteLine("O valor total é : " + ProdutoBLL.CalcularValorDoItem(codigo, quantidade));
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void ValidarQuantidadeEstoque()
        {
            string input = String.Empty;
            Console.Clear();
            Console.WriteLine("Digite o código de barras do produto (0 - sair) :");
            input = Console.ReadLine();
            if (input == "0")
                return;
            var codigo = input;
            Console.Clear();
            Console.WriteLine("Digite a quantidade adquirida (-1 - sair) :");
            input = Console.ReadLine();
            if (input == "-1")
                return;
            int quantidade = 0;
            bool result = int.TryParse(input, out quantidade);
            while (!result)
            {
                Console.Clear();
                Console.WriteLine(" ============== Entrada inválida. ============== ");
                Console.WriteLine("Digite a quantidade adquirida (-1 - sair) :");
                input = Console.ReadLine();
                if (input == "-1")
                    return;
                result = int.TryParse(input, out quantidade);
            }
            if (EstoqueBLL.ValidarQuantidadeEstoque(codigo, quantidade))
            {
                Console.WriteLine("Há unidades suficientes do produto para vender!");
            }
            else
            {
                Console.WriteLine("Não há unidades suficientes do produto para vender!");
            }
            Console.WriteLine("Digite qualquer tecla para voltar");
            Console.ReadKey();
        }

        public static void CalcularValorDescontoFormaPagamento()
        {
            Console.Clear();
            Console.WriteLine("Codigo da venda : (-1 para sair)");
            String cod = Console.ReadLine().ToLower();
            if (cod == "-1")
                return;
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            var venda = VendaBLL.Get(cod);
            Console.Clear();
            switch ((FormaPagamento)venda.FormaPagamento)
            {
                case FormaPagamento.A_VISTA_DEBITO: Console.WriteLine(" Valor total da venda : "+ String.Format(new CultureInfo("pt-BR"), "{0:C}", venda.ValorTotal * 0.98) + "( 2 % de desconto) \n\n"); break;
                case FormaPagamento.A_VISTA_DINHEIRO: Console.WriteLine(" Valor total da venda : " + String.Format(new CultureInfo("pt-BR"), "{0:C}", venda.ValorTotal * 0.95) + "( 5 % de desconto) \n\n"); break;
                case FormaPagamento.OUTROS: Console.WriteLine(" Valor total da venda : " + String.Format(new CultureInfo("pt-BR"), "{0:C}", venda.ValorTotal) + "(sem desconto) \n\n"); break;
            }

            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();

        }

        public static void ProdutosBaixoEstoque()
        {
            Console.Clear();
            Console.WriteLine("Por favor aguarde ... ");
            var produtos = EstoqueBLL.ProdutosBaixaEstoque();
            Console.Clear();
            Console.WriteLine("Os seguintes produtos estão com baixo estoque : ");
            foreach(var p in produtos)
            {
                Console.WriteLine(p.Descricao+" - x"+p.QuantidadeNoEstoque);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ");
            Console.ReadKey();
        }

        private static List<ProdutoVenda> converterListaProdutoListaProdutoVenda(List<Produto> lista)
        {
            List<ProdutoVenda> retorno = new List<ProdutoVenda>();
            var grouping = lista.GroupBy(p => p._id);
            foreach (var g in grouping)
            {
                var listaAgrupada = g.ToList();
                var qtd = listaAgrupada.Count;
                var vlrTotal = listaAgrupada.Sum(p => p.ValorUnitario);
                retorno.Add(new ProdutoVenda(listaAgrupada.FirstOrDefault().Descricao,
                    listaAgrupada.FirstOrDefault().ValorUnitario, qtd, vlrTotal));
            }
            return retorno;
        }
    }
}
