using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TSS.Models;

namespace TSS.Data
{
    public class TSSContext : DbContext
    {
        public TSSContext (DbContextOptions<TSSContext> options)
            : base(options)
        {
        }

        public DbSet<TSS.Models.Tipocontato> Tipocontato { get; set; } = default!;
        public DbSet<TSS.Models.Tipousuario> Tipousuario { get; set; } = default!;
        public DbSet<TSS.Models.Tipoplano> Tipoplano { get; set; } = default!;
        public DbSet<TSS.Models.Tiposervico> Tiposervico { get; set; } = default!;
        public DbSet<TSS.Models.Plano> Plano { get; set; } = default!;
        public DbSet<TSS.Models.Servico> Servico { get; set; } = default!;
        public DbSet<TSS.Models.Status> Status { get; set; } = default!;
        public DbSet<TSS.Models.Usuario> Usuario { get; set; } = default!;
    }
}
