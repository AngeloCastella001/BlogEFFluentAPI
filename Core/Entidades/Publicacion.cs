namespace Core.Entidades
{
    public class Publicacion : BaseEntity
    { 
        public int Id { get; set; }
        public string Titulo { get; set;}
        public string Resumen { get; set; }
        public string Contenido { get; set; }
        public string Etiquetas { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();

    }
}