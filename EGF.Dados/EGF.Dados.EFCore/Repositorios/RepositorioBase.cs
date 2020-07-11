﻿using EGF.Dados.EFCore.Contexto;
using EGF.Dados.EFCore.UnidadesDeTrabalho;
using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;
using System.Linq;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class RepositorioBase<TEntidade, TContexto> : IRepositorioBase<TEntidade>
        where TContexto : ContextoDaAplicacaoBase
        where TEntidade : EntidadeBase
    {
        protected UnidadeDeTrabalhoBase<TContexto> UnidadeDeTrabalho { get; }

        protected RepositorioBase(UnidadeDeTrabalhoBase<TContexto> unidadeDeTrabalho)
        {
            UnidadeDeTrabalho = unidadeDeTrabalho;
        }

        public virtual IEnumerable<TEntidade> Buscar()
        {
            return UnidadeDeTrabalho.Contexto.Set<TEntidade>();
        }

        public virtual IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa)
        {
            return UnidadeDeTrabalho.Contexto.Set<TEntidade>().Where(pesquisa);
        }

        public virtual TEntidade Editar(TEntidade entidade)
        {
            return UnidadeDeTrabalho.Contexto.Update(entidade).Entity;
        }

        public virtual TEntidade Inserir(TEntidade entidade)
        {
            return UnidadeDeTrabalho.Contexto.Add(entidade).Entity;
        }

        public virtual int NumeroDeRegistros()
        {
            return UnidadeDeTrabalho.Contexto.Set<TEntidade>().Count();
        }

        public virtual void Remover(TEntidade entidade)
        {
            UnidadeDeTrabalho.Contexto.Remove(entidade);
        }
    }
}
