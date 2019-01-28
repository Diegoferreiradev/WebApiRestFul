using House.ApiRestFul.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.ApiRestFul.AcessoDados.Entity.Context
{
    public class ApiRestFulDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public ApiRestFulDbContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
