using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase
    {
        public RepositorioMesa()
        {
            this.listaRegistros = new List<EntidadeBase>();
        }
    }
}