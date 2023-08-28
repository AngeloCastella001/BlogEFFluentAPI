namespace Core.Entidades
{
    public class UsuarioPerfil 
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}