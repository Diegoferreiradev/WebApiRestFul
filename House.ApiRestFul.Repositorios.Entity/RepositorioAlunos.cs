using House.ApiRestFul.AcessoDados.Entity.Context;
using House.ApiRestFul.Dominio;
using House.Comum.Repositorios.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.ApiRestFul.Repositorios.Entity
{
    public class RepositorioAlunos : RepositorioHouse<Aluno, int>
    {
        public RepositorioAlunos(ApiRestFulDbContext context)
            :base (context)
        {

        }
    }
}
