namespace gestorDeGimnasios.Models
{
    public class Socio
    {
        private int idSocio;
        private string nombre;
        private string apellido;
        private string tipo;
        private string telefono;
        private string correoElectronico;
        private int idLocal;
        private List<Rutina> listaRutinas;

        public int IdSocio { get { return this.idSocio; } set {this.idSocio =value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Apellido { get { return this.apellido; } set { this.apellido = value; } }

        public string Tipo { get { return this.tipo; } set { this.tipo = value; } }
        public string Telefono { get { return this.telefono; } set { this.telefono = value; } }
        public string CorreoElectronico { get { return this.correoElectronico; } set { this.correoElectronico = value; } }
        public int IdLocal { get { return this.idLocal; } set { this.idLocal = value; } }
        public List<Rutina> ListaRutinas { get { return this.listaRutinas; } set { this.listaRutinas = value; } }

    }
}
