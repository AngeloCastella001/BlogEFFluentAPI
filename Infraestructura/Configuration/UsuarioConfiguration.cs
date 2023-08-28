using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario", "blog");

        builder.HasKey(u => u.Id);

        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(250);

        builder.Property(p => p.Apellidos)
                .IsRequired()
                .HasMaxLength(250);

        builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(250);

        builder.Property(p => p.Contrasena)
                .IsRequired();

        builder.HasOne(b => b.DatosAdicionalesUsuario)
                    .WithOne(i => i.Usuario)
                    .HasForeignKey<DatosAdicionalesUsuario>(b => b.Id);

        builder.HasMany(p => p.Perfiles)
                    .WithMany(p => p.Usuarios)
                    .UsingEntity<UsuarioPerfil>(
                        j => j
                            .HasOne(pt => pt.Perfil)
                            .WithMany(t => t.UsuariosPerfiles)
                            .HasForeignKey(pt => pt.PerfilId),
                        j => j
                            .HasOne(pt => pt.Usuario)
                            .WithMany(p => p.UsuariosPerfiles)
                            .HasForeignKey(pt => pt.UsuarioId),
                        j =>
                        {
                            j.HasKey(t => new { t.UsuarioId, t.PerfilId });
                        });


        builder.HasOne(x => x.Encargado)
                    .WithMany(x => x.Colaboradores)
                    .HasForeignKey(x => x.EncargadoId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);



    }
}
