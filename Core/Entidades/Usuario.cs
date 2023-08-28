namespace Core.Entidades
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Publicacion> Publicaciones { get; set; } = new HashSet<Publicacion>();
        public ICollection<Perfil> Perfiles { get; set; } = new HashSet<Perfil>();
        public ICollection<UsuarioPerfil> UsuariosPerfiles { get; set; }
        public DatosAdicionalesUsuario DatosAdicionalesUsuario { get; set; }
        public int? EncargadoId { get; set; }
        public Usuario? Encargado { get; set; }
        public ICollection<Usuario> Colaboradores { get; set; } = new HashSet<Usuario>();
    }
}