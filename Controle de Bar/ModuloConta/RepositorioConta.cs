using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta()
        {
            this.listaRegistros = new List<EntidadeBase>();
        }
    }
}