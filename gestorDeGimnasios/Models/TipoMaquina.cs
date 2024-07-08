namespace gestorDeGimnasios.Models
{
    public class TipoMaquina
    {
        private int? idTipoMaquina;
        private string ?nombre;
        private int ?cantidad;

        public int? IdTipoMaquina { get { return this.idTipoMaquina; } set { this.idTipoMaquina = value; } }
        public string ?Nombre { get { return this.nombre; } set { this.nombre = value; } }

        public int? Cantidad { get { return this.cantidad; } set {this.cantidad = value; } }


    }
}
