using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuracion
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Nombre).HasMaxLength(250);
            builder.Property(p => p.Descripcion).HasMaxLength(500);
            builder.Property(p => p.Imagen).HasMaxLength(1000);
            builder.HasOne(m => m.Marca).WithMany().HasForeignKey(p => p.MarcaId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
