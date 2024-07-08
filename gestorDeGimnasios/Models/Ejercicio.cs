namespace gestorDeGimnasios.Models
{
    public class Ejercicio
    {
        private int? idEjercicio;
        private string? descripcion;
        private int? idTipoMaquina;
        private TipoMaquina? tipoMaquina;
        

        public int? IdEjercicio { get { return this.idEjercicio; } set { this.idEjercicio = value; } }
        public string? Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public int? IdTipoMaquina { get { return this.idTipoMaquina; } set { this.idTipoMaquina = value; } }
        public TipoMaquina? TipoMaquina { get { return this.tipoMaquina; } set { this.tipoMaquina = value; } }
    }
}
