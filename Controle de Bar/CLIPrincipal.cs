using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_de_Bar.ModuloProduto;
using Controle_de_Bar.ModuloFuncionario;
using Controle_de_Bar.ModuloConta;
using Controle_de_Bar.ModuloMesa;

namespace Controle_de_Bar
{
    public class CLIPrincipal
    {
        RepositorioProduto repositorioProduto;
        CLIProduto cliProduto;

        RepositorioFuncionario repositorioFuncionario;

        CLIFuncionario cliFuncionario;

        CLIConta cliConta;
        RepositorioConta repositorioConta;
        
        CLIMesa cliMesa;
        RepositorioMesa repositorioMesa;

        Dictionary<int, int> listaProdutos;


        public CLIPrincipal()
        {
            this.repositorioProduto = new RepositorioProduto();
            this.repositorioFuncionario = new RepositorioFuncionario();
            this.repositorioConta = new RepositorioConta();
            this.repositorioMesa = new RepositorioMesa();

            this.cliProduto = new CLIProduto(repositorioProduto);
            this.cliFuncionario = new CLIFuncionario(repositorioFuncionario);
            this.cliConta = new CLIConta(repositorioConta, repositorioProduto, repositorioMesa);
            this.cliMesa = new CLIMesa(repositorioMesa);

            this.repositorioProduto.Inserir(new Produto(1, "Cerveja", "Gelada",5.00, 10));
            this.repositorioMesa.Inserir(new Mesa(1, "Mesa A", false));
        }
        public void MenuPrincipal(){
            Console.WriteLine("Bem vindo ao Controle de Bar");
            Console.WriteLine("Digite 1 para acessar o módulo de Produtos");
            Console.WriteLine("Digite 2 para acessar o módulo de Funcionários");
            Console.WriteLine("Digite 3 para acessar o módulo de Contas");
            Console.WriteLine("Digite 4 para acessar o módulo de Mesas");
            Console.WriteLine("Digite s para sair");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    cliProduto.ApresentarMenu();
                    break;
                case "2":
                    cliFuncionario.ApresentarMenu();
                    break;
                case "3":
                    cliConta.ApresentarMenu();
                    break;
                case "4":
                    cliMesa.ApresentarMenu();
                    break;
                case "s":
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuPrincipal();
        }
    }
}