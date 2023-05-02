using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace Controle_de_Bar.ModuloMesa
{
    public class CLIMesa : TelaBase
    {
        public string nomeEntidade = "Mesa";
        public string sufixo = "s";

        public CLIMesa(RepositorioMesa repositorioBase) {
            this.repositorioBase = repositorioBase;
        }

        protected override void MostrarTabela(List<EntidadeBase> registros)
        {
            Console.WriteLine("ID\tETIQUETA\tOCUPADA");
            foreach (Mesa mesa in registros)
            {
                Console.WriteLine($"{mesa.id}\t{mesa.etiqueta}\t{mesa.ocupada}");
            }
        }

        protected override EntidadeBase ObterRegistro(EntidadeBase registro)
        {
            Console.WriteLine("Digite a etiqueta da mesa: ");
            string etiqueta = Console.ReadLine();
            return new Mesa(etiqueta: etiqueta);
        }
    }
}