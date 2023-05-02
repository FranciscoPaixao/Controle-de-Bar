using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloFuncionario
{
    public class CLIFuncionario : TelaBase
    {
        public CLIFuncionario(RepositorioFuncionario repositorio)
        {
            this.repositorioBase = repositorio;
            this.nomeEntidade = "Funcionário";
            this.sufixo = "s";
        }
        protected override void MostrarTabela(List<EntidadeBase> registros)
        {
            Console.WriteLine("ID\tNOME\tCARGO");
            foreach (Funcionario funcionario in registros)
            {
                Console.WriteLine($"{funcionario.id}\t{funcionario.nome}\t{funcionario.cargo}");
            }
        }

        protected override EntidadeBase ObterRegistro(EntidadeBase registro)
        {
            Console.WriteLine("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o cargo do funcionário: ");
            string cargo = Console.ReadLine();
            return new Funcionario(nome: nome, cargo: cargo);
        }
    }
}