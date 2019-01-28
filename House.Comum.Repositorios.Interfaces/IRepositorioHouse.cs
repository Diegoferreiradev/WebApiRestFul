using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace House.Comum.Repositorios.Interfaces
{
    public interface IRepositorioHouse<TDominio, TChave>
        where TDominio : class
    {
        List<TDominio> Selecionar(Expression<Func<TDominio, bool>> where = null);

        TDominio SelecionarPorId(TChave id);

        void Inserir(TDominio dominio);

        void Atualizar(TDominio dominio);

        void Excluir(TDominio dominio);

        void ExcluirPorId(TChave id);
    }
}
