using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string nome { get; set; }
        public string cargo { get; set; }

        public Funcionario(int id = -1, string nome = "", string cargo = "")
        {
            this.id = id;
            this.nome = nome;
            this.cargo = cargo;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;
            this.nome = funcionarioAtualizado.nome;
            this.cargo = funcionarioAtualizado.cargo;
        }

        public override Dictionary<string, string> Validar()
        {
            Dictionary<string, string> mensagens = new Dictionary<string, string>();
            if(nome.Length < 3)
            {
                mensagens.Add("NOME", "Nome do funcionário deve ter no mínimo 3 caracteres");
            }
            if(cargo.Length < 3)
            {
                mensagens.Add("CARGO", "Cargo do funcionário deve ter no mínimo 3 caracteres");
            }
            return mensagens;
        }
    }
}