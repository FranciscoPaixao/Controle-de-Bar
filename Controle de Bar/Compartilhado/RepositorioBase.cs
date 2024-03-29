﻿using System.Collections;

namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase
    {
        protected List<EntidadeBase> listaRegistros;
        protected int contadorRegistros = 0;

        public virtual void Inserir(EntidadeBase registro)
        {
            contadorRegistros++;

            registro.id = contadorRegistros;

            listaRegistros.Add(registro);
        }

        public virtual void Editar(int id, EntidadeBase registroAtualizado)
        {
            EntidadeBase registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Editar(EntidadeBase registroSelecionado, EntidadeBase registroAtualizado)
        {
            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Excluir(int id)
        {
            EntidadeBase registroSelecionado = SelecionarPorId(id);

            listaRegistros.Remove(registroSelecionado);
        }

        public virtual void Excluir(EntidadeBase registroSelecionado)
        {
            listaRegistros.Remove(registroSelecionado);
        }

        public virtual EntidadeBase SelecionarPorId(int id)
        {
            EntidadeBase registroSelecionado = null;

            foreach (EntidadeBase registro in listaRegistros)
            {
                if (registro.id == id)
                {
                    registroSelecionado = registro;
                    break;
                }
            }

            return registroSelecionado;
        }

        public virtual List<EntidadeBase> SelecionarTodos()
        {
            return listaRegistros;
        }

        public bool TemRegistros()
        {
            return listaRegistros.Count > 0;
        }
    }
}
