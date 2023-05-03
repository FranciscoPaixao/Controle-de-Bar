using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_de_Bar.ModuloMesa;
using Controle_de_Bar.ModuloProduto;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloConta
{
    public class CLIConta : TelaBase
    {
        private RepositorioProduto repositorioProduto;
        private RepositorioMesa repositorioMesa;
        public CLIConta(RepositorioConta repositorioBase, RepositorioProduto repositorioProduto, RepositorioMesa repositorioMesa)
        {
            this.repositorioBase = repositorioBase;
            this.repositorioProduto = repositorioProduto;
            this.repositorioMesa = repositorioMesa;
            this.nomeEntidade = "Conta";
            this.sufixo = "s";
        }
        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Inserir {nomeEntidade}");
            Console.WriteLine($"Digite 2 para Visualizar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Adicionar um Pedido a {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 5 para Visualizar faturamento por dia\n");

            Console.WriteLine("Digite s para Sair");
            
            string opcao = Console.ReadLine();

            switch(opcao){
                case "1":
                    InserirNovoRegistro();
                    break;
                case "2":
                    MostrarTabela(repositorioBase.SelecionarTodos());
                    break;
                case "3":
                    EditarRegistro();
                    break;
                case "4":
                    AdicionarPedido();
                    break;
                case "5":
                    GerarRelatorioFaturamento();
                    break;
                default:
                    break;
            }

            return opcao;
        }
        private void GerarRelatorioFaturamento()
        {
            MostrarCabecalho($"Relatório de faturamento por dia", "Gerando relatório...");
            MostrarTabela(repositorioBase.SelecionarTodos());
            Console.WriteLine("Digite o data (d/m/a) que deseja gerar o relatório: ");
            string dataString = Console.ReadLine();
            DateTime data = Convert.ToDateTime(dataString);
            double faturamento = 0;
            foreach (Conta conta in repositorioBase.SelecionarTodos())
            {
                if (conta.dataDaConta.Date == data.Date)
                {
                    faturamento += conta.valorTotal;
                }
            }
            MostrarMensagem($"Faturamento do dia {data.Date}: R${faturamento}", ConsoleColor.Green);
        }
        private void AdicionarPedido()
        {
            MostrarCabecalho($"Adicionar Pedido a {nomeEntidade}{sufixo}", "Adicionando um novo pedido...");
            MostrarTabela(repositorioBase.SelecionarTodos());
            Console.WriteLine("Digite o ID da conta que deseja adicionar um pedido");
            int idConta = Convert.ToInt32(Console.ReadLine());
            Conta conta = (Conta)repositorioBase.SelecionarPorId(idConta);


            if (TemErrosDeValidacao(conta))
            {
                return;
            }
            ListarProdutosDisponiveis();
            Console.WriteLine("Digite o ID do produto que deseja adicionar ao pedido: ");
            int idProduto = Convert.ToInt32(Console.ReadLine());
            Produto produto = (Produto)repositorioProduto.SelecionarPorId(idProduto);
            if (produto.quantidade == 0)
            {
                MostrarMensagem("Produto indisponível", ConsoleColor.Red);
                return;
            }
            Console.WriteLine("Digite a quantidade do produto que deseja adicionar ao pedido: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            if (quantidade > produto.quantidade)
            {
                MostrarMensagem("Quantidade indisponível", ConsoleColor.Red);
                return;
            }
            produto.quantidade -= quantidade;
            repositorioProduto.Editar(idProduto, produto);
            //verifica se chave já existe
            if (conta.produtos.ContainsKey(produto.id))
            {
                conta.produtos[produto.id] += quantidade;
            }
            else
            {
                conta.produtos.Add(produto.id, quantidade);
            }
            conta.valorTotal += (double)produto.preco * conta.produtos[produto.id];
            repositorioBase.Editar(idConta, conta);
            MostrarMensagem("Pedido adicionado com sucesso!", ConsoleColor.Green);
        }
        public void ListarProdutosDisponiveis()
        {
            Console.WriteLine("ID\tNome\tPreço");
            List<Produto> listaProdutos = repositorioProduto.SelecionarTodos().Cast<Produto>().ToList();
            if (listaProdutos.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados");
                return;
            }
            foreach (Produto produto in listaProdutos)
            {
                if (produto.quantidade > 0)
                {
                    Console.WriteLine($"{produto.id}\t{produto.nome}\t{produto.preco}");
                }
            }
        }
        protected override void MostrarTabela(List<EntidadeBase> registros)
        {
            Console.WriteLine("ID\tNome Cliente\tMesa\tData\tValor Total");
            foreach (Conta conta in registros)
            {
                Console.WriteLine($"{conta.id}\t{conta.nomeCliente}\t{(conta.mesa.etiqueta)}\t{conta.dataDaConta}\t{conta.valorTotal}");
            }
        }

        protected override EntidadeBase ObterRegistro(EntidadeBase registro)
        {
            Conta conta = new Conta();
            Console.WriteLine("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            conta.nomeCliente = nome;
            Console.WriteLine("Digite o ID da mesa: ");
            int idMesa = Convert.ToInt32(Console.ReadLine());
            conta.mesa = (Mesa) repositorioMesa.SelecionarPorId(idMesa);
            conta.dataDaConta = DateTime.Now.Date;
            conta.valorTotal = 0;
            return conta;
        }
    }
}