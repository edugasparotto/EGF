﻿using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;

namespace EGF.Dominio.Servicos
{
    public abstract class ServicoDePersistencia<TEntidade, TRepositorio> : IServicoDePersistencia<TEntidade>
        where TRepositorio : IRepositorioBase<TEntidade>
        where TEntidade : Entidade
    {
        protected TRepositorio Repositorio { get; }

        protected ServicoDePersistencia(TRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IEnumerable<TEntidade> Buscar()
        {
            return Repositorio.Buscar();
        }

        public IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa)
        {
            return Repositorio.Buscar(pesquisa);
        }

        public TEntidade Inserir(TEntidade entidade)
        {
            return Repositorio.Inserir(entidade);
        }

        public TEntidade Editar(TEntidade entidade)
        {
            return Repositorio.Editar(entidade);
        }

        public void Remover(TEntidade entidade)
        {
            Repositorio.Remover(entidade);
        }
    }
}
