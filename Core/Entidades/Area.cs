namespace Core.Entidades
{
    public class Area : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Departamento> Departamentos { get; set; } = new HashSet<Departamento>();
    }
}
