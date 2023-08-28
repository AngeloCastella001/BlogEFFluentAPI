using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configuration;

public class PublicacionConfiguration : IEntityTypeConfiguration<Publicacion>
{
    public void Configure(EntityTypeBuilder<Publicacion> builder)
    {

        builder.ToTable("Publicacion", "blog");

        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(p => p.Resumen)
                .IsRequired()
                .HasMaxLength(250);

        builder.Property(p => p.Contenido)
                .IsRequired()
                .HasMaxLength(1000);

        builder.Property(p => p.Etiquetas)
                .IsRequired()
                .HasMaxLength(500);

        builder.HasMany(u => u.Comentarios)
                    .WithOne(u => u.Publicacion)
                    .HasForeignKey(u => u.PublicacionId)
                    .OnDelete(DeleteBehavior.Cascade);


    }
}

