using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Exemplo_3_Endpoint_ASPNET_Banco.database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {  }
        public DbSet<Models.Usuario> Usuarios {get; set;}
    }
}