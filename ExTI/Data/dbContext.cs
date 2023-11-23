using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExTI.Models;

namespace ExTI.Data
{
    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<ExTI.Models.CadClientes> CadClientes { get; set; } = default!;

        public DbSet<ExTI.Models.CadMaquinas> CadMaquinas { get; set; } = default!;

        public DbSet<ExTI.Models.Inventario> Inventario { get; set; } = default!;
    }
}
