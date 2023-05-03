using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_de_Bar.ModuloMesa;
using Controle_de_Bar.ModuloProduto;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public string nomeCliente;
        public Mesa mesa;
        public Dictionary<int, int> produtos;
        public double valorTotal;
        public DateTime dataDaConta;

        public Conta(int id = -1, string nomeCliente = "", Mesa mesa = null, Dictionary<int, int> produtos = null, double valorTotal = 0, DateTime dataDaConta = default(DateTime))
        {
            this.id = id;
            this.nomeCliente = nomeCliente;
            this.mesa = mesa;
            if (produtos == null)
            {
                this.produtos = new Dictionary<int, int>();
            }
            else
            {
                this.produtos = produtos;
            }
            this.valorTotal = valorTotal;
            this.dataDaConta = dataDaConta;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta pedidoAtualizado = (Conta)registroAtualizado;
            this.nomeCliente = pedidoAtualizado.nomeCliente;
            this.mesa = pedidoAtualizado.mesa;
            this.produtos = pedidoAtualizado.produtos;
            this.valorTotal = pedidoAtualizado.valorTotal;

        }

        public override Dictionary<string, string> Validar()
        {
            Dictionary<string, string> mensagens = new Dictionary<string, string>();
            if (nomeCliente.Length < 3)
            {
                mensagens.Add("NOME", "Nome do cliente deve ter no mínimo 3 caracteres!");
            }
            if (mesa.id < 0)
            {
                mensagens.Add("MESA", "O ID da mesa deve ser igual ou maior que 0!");
            }
            return mensagens;
        }
    }
}