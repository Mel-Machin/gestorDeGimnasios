namespace gestorDeGimnasios.Models
{
    public class Usuario
    {
        private int idUsuario;
        private string nombreUsuario;
        private string password;
        private string email;
        private string nombre;
        private string apellido;

        public int IdUsuario { get { return this.idUsuario; } set { this.idUsuario = value; } }
        public string NombreUsuario { get { return this.nombreUsuario; } set { this.nombreUsuario = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Apellido { get { return this.apellido; } set { this.apellido = value; } }

    }
}
