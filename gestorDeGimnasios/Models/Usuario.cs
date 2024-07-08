namespace gestorDeGimnasios.Models
{
    public class Usuario
    {
        private string ?nombreUsuario;
        private string ?contrasenia;
        private string ?tipoUsuario;

        public string ?NombreUsuario {  get { return nombreUsuario; } set { nombreUsuario = value; } }
        public string ?Contrasenia { get { return contrasenia; } set { contrasenia = value; } }

        public string ?TipoUsuario { get {return tipoUsuario; } set { tipoUsuario = value; }  }

        public bool IsTipoUsuario(string tipoUsuario)
        {
            return tipoUsuario == this.TipoUsuario;
        }


    }
}
