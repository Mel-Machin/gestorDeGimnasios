namespace gestorDeGimnasios.Models
{
    public class Administrador : Usuario
    {
        private string ?telefono;
        private string ?nombre;

        public string ?Telefono { get { return this.telefono; } set { this.telefono = value; } }
        public string ?Nombre { get { return this.nombre; } set {this.nombre = value; } }

    }
}
