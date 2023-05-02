using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }
        public Produto(int id = -1, string nome = "", string descricao = "", double preco = 0, int quantidade = 0)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
            this.quantidade = quantidade;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;
            this.nome = produtoAtualizado.nome;
            this.descricao = produtoAtualizado.descricao;
            this.preco = produtoAtualizado.preco;
            this.quantidade = produtoAtualizado.quantidade;
        }

        public override Dictionary<string, string> Validar()
        {
            Dictionary<string, string> mensagens = new Dictionary<string, string>();
            if (nome.Length < 3)
            {
                mensagens.Add("NOME", "Nome do produto deve ter no mínimo 3 caracteres");
            }
            if (descricao.Length < 3)
            {
                mensagens.Add("DESCRICAO","Descrição do produto deve ter no mínimo 3 caracteres");
            }
            if (preco < 0)
            {
                mensagens.Add("PRECO","Preço do produto deve ser maior que 0");
            }
            if (quantidade < 0)
            {
                mensagens.Add("QUANTIDADE","Quantidade do produto deve ser maior que 0");
            }
            return mensagens;
        }
    }
}