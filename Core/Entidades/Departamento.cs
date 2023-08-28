namespace Core.Entidades
{
    public class Departamento : BaseEntity
    { 
        public int Id { get; set; }
        public string Nombre { get; set;}
        public int AreaId { get; set;}
        public Area Area { get; set;}
        public ICollection<Usuario> Usuarios { get; set;} = new HashSet<Usuario>();
    }
}