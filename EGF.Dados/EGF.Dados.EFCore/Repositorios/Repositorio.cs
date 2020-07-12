﻿using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class Repositorio<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : Entidade
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; }

        protected Repositorio(IUnidadeDeTrabalho unidadeDeTrabalho)
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

        public virtual async Task<IEnumerable<TEntidade>> BuscarAsync()
        {
            return await Task.FromResult(UnidadeDeTrabalho.Contexto.Set<TEntidade>());
        }

        public async Task<IEnumerable<TEntidade>> BuscarAsync(Func<TEntidade, bool> func)
        {
            var retorno = await BuscarAsync();
            return retorno.Where(func).AsQueryable();
        }

        public virtual async Task<TEntidade> EditarAsync(TEntidade entidade)
        {
            return await Task.FromResult(UnidadeDeTrabalho.Contexto.Set<TEntidade>().Update(entidade).Entity);
        }

        public virtual async Task<TEntidade> InserirAsync(TEntidade entidade)
        {
            return await Task.FromResult(UnidadeDeTrabalho.Contexto.Add(entidade).Entity);
        }

        public virtual async Task<int> NumeroDeRegistrosAsync()
        {
            return await Task.FromResult(UnidadeDeTrabalho.Contexto.Set<TEntidade>().Count());
        }

        public virtual async Task RemoverAsync(TEntidade entidade)
        {
            await Task.FromResult(UnidadeDeTrabalho.Contexto.Remove(entidade));
        }

    }
}
