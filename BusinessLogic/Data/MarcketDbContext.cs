using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class MarcketDbContext: DbContext
    {
        public MarcketDbContext(DbContextOptions<MarcketDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }





    }
}
