namespace Core.Entidades
{
    public class Comentario : BaseEntity
    {
        public int Id { get; set; }
        public string Asunto { get; set; }
        public string Email { get; set;}
        public string Contenido { get; set;}
        public bool Aprobado { get; set; }
        public bool EsVisible => Aprobado == true ? true : false;
        public int PublicacionId { get; set; }
        public Publicacion Publicacion { get; set; }

    }
}