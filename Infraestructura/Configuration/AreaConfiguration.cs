using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Configuration
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Area", "blog");

            builder.Property(p => p.Id)
                    .IsRequired();

            builder.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

            builder.HasMany(u => u.Departamentos)
                        .WithOne(u => u.Area)
                        .HasForeignKey(u => u.AreaId)
                        .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
