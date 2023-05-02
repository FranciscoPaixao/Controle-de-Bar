using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase
    {
        public RepositorioProduto()
        {
            this.listaRegistros = new List<EntidadeBase>();
        }
    }
}