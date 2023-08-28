namespace Core.Entidades
{
    public class DatosAdicionalesUsuario : BaseEntity
    {
        public int Id { get; set; } = new int();
        public string Calle { get; set; }
        public string Colonia { get; set;}
        public string NumeroExterior { get; set;}
        public string NumeroInterior { get; set;}
        public string CodigoPostal { get; set;}
        public string Ciudad { get; set;}
        public decimal Salario { get; set;}
        public Usuario Usuario { get; set;}
    }
}