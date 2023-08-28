using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configuration;
public class DatosAdicionalesUsuarioConfiguration : IEntityTypeConfiguration<DatosAdicionalesUsuario>
{
    public void Configure(EntityTypeBuilder<DatosAdicionalesUsuario> builder)
    {
        builder.ToTable("DatosAdicionalesUsuario", "blog");

        builder.HasKey(u => u.Id);

        builder.Property(p => p.Calle)
                .IsRequired()
                .HasMaxLength(250);

        builder.Property(p => p.Colonia)
                .IsRequired()
                .HasMaxLength(250);

        builder.Property(p => p.NumeroExterior)
                .IsRequired()
                .HasMaxLength(50);

        builder.Property(p => p.NumeroInterior)
                .HasMaxLength(50)
                .HasDefaultValue(String.Empty);

        builder.Property(p => p.CodigoPostal)
                .IsRequired()
                .HasMaxLength(10);

        builder.Property(p => p.Ciudad)
                .IsRequired()
                .HasMaxLength(250);

        builder.Property(p => p.Salario)
                    .HasColumnType("decimal(18,2)")
                    .HasDefaultValue(0M);


    }
}
