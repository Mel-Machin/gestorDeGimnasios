namespace gestorDeGimnasios.Models
{
    public class Maquina
    {
        private int idMaquina;
        private int idLocal;
        private DateTime fechaCompra;
        private decimal precio;
        private int vidaUtil;
        private int idTipoMaquina;
        private string disponibilidad;

        public int IdMaquina { get { return this.idMaquina; } set { this.idMaquina = value; } }
        public int IdLocal { get { return this.idLocal; } set { this.idLocal = value; } }
        public DateTime FechaCompra { get { return this.fechaCompra; } set { this.fechaCompra = value; } }
        public decimal Precio { get { return this.precio; } set { this.precio = value; } }
        public int VidaUtil { get { return this.vidaUtil; } set { this.vidaUtil = value; } }
        public int IdTipoMaquina { get { return this.idTipoMaquina; } set { this.idTipoMaquina = value; } }
        public string Disponibilidad { get { return this.disponibilidad; } set { this.disponibilidad = value; } }

    }
}
