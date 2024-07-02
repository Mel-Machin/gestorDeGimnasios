namespace gestorDeGimnasios.Models
{
    public class TipoMaquina
    {
        private int idTipoMaquina;
        private string nombre;

        public int IdTipoMaquina { get { return this.idTipoMaquina; } set { this.idTipoMaquina = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }

    }
}
