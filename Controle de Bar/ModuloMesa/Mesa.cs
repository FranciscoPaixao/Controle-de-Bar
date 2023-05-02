using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public bool ocupada { get; set; }
        public string etiqueta { get; set; }

        public Mesa(int id = -1, string etiqueta = "", bool ocupada = false)
        {
            this.id = id;
            this.etiqueta = etiqueta;
            this.ocupada = ocupada;
        }
        
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;
            this.etiqueta = mesaAtualizada.etiqueta;
            this.ocupada = mesaAtualizada.ocupada;   
        }

        public override Dictionary<string, string> Validar()
        {
            Dictionary<string, string> mensagens = new Dictionary<string, string>();
            if(ocupada == true)
            {
                mensagens.Add("OCUPADA", "Mesa ocupada");
            }
            if(etiqueta.Length < 3)
            {
                mensagens.Add("ETIQUETA", "Etiqueta da mesa deve ter no mínimo 3 caracteres!");
            }
            return mensagens;
        }
    }
}