using System.Runtime.InteropServices.Marshalling;

namespace gestorDeGimnasios.Models
{
    public class SocioRutina
    {
        
        private int idSocio;
        private int idRutina;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private decimal calificacion;

        public int IdSocio { get{return this.idSocio;} set{this.idSocio = value;} }
        public int IdRutina { get { return this.idRutina; } set { this.idRutina = value; } }
        public DateTime FechaInicio { get { return this.fechaInicio; } set { this.fechaInicio = value; } }
        public DateTime FechaFin { get { return this.fechaFin; } set { this.fechaFin = value; } }
        public decimal Calificacion { get{return this.calificacion; } set{ this.calificacion = value; } }
    }
}
