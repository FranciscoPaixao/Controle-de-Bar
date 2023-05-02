using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloProduto
{
    public class CLIProduto : TelaBase
    {
        public string nomeEntidade = "Produto";
        public string sufixo = "s";
        public CLIProduto(RepositorioProduto repositorioBase) {
            this.repositorioBase = repositorioBase;
        }

        protected override void MostrarTabela(List<EntidadeBase> registros)
        {
            Console.WriteLine("ID\tNOME\tDESCRIÇÃO\tPREÇO\tQUANTIDADE");
            foreach (Produto produto in registros)
            {
                Console.WriteLine($"{produto.id}\t{produto.nome}\t{produto.descricao}\t{produto.preco}\t{produto.quantidade}");
            }
        }

        protected override EntidadeBase ObterRegistro(EntidadeBase registro)
        {
            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição do produto: ");
            string descricao = Console.ReadLine();
            Console.WriteLine("Digite o preço do produto: ");
            double preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite a quantidade do produto: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            return new Produto(nome: nome, descricao: descricao, preco: preco, quantidade: quantidade);
        }
    }
}