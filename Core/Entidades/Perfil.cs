namespace Core.Entidades
{
    public class Perfil : BaseEntity
    { 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
        public ICollection<UsuarioPerfil> UsuariosPerfiles { get; set; }
    }
}