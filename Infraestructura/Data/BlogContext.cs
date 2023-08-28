using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Infraestructura.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        //public DbSet<DatosAdicionalesUsuario> DatosAdicionalesUsuarios { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<UsuarioPerfil> UsuariosPerfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
