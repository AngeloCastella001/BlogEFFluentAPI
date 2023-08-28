using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configuration;
public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.ToTable("Comentario", "blog");

        builder.HasKey(u => u.Id);

        builder.Property(p => p.Asunto)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(p => p.Contenido)
                .IsRequired()
                .HasMaxLength(500);


    }
}
