namespace gestorDeGimnasios.Models
{
    public class Local
    {
        private int ?idLocal;
        private string? nombre;
        private string? ciudad;
        private string? direccion;
        private string? telefono;
        private int? idResponsable;
        private Responsable? responsable;

        public int ?IdLocal { get { return this.idLocal; } set { this.idLocal = value; } }
        public string ?Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string ?Ciudad { get { return this.ciudad; } set { this.ciudad = value; } }
        public string ?Direccion { get { return this.direccion; } set { this.direccion = value; } }
        public string ?Telefono { get { return this.telefono; } set { this.telefono = value; } }
        public int? IdResponsable { get { return this.idResponsable; } set { this.idResponsable = value; } }
        public Responsable? Responsable { get { return this.responsable; } set { this.responsable = value; } }



    }
}
