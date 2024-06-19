namespace gestorDeGimnasios.Models
{
    public class Rutina
    {
        private int idRutina;
        private string descripcion;
        private string tipoRutina;
        private decimal calificacionRutinaPromedio;
        //private List<Ejercicio> listaEjercicios;
        //private List<Socio> listaSocios;

        public int IdRutina { get { return this.idRutina; } set { this.idRutina = value; }}
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public string TipoRutina { get { return this.tipoRutina; } set { this.tipoRutina = value; } } 
        public decimal CalificacionRutinaPromedio { get { return this.calificacionRutinaPromedio; } set { this.calificacionRutinaPromedio = value; } }
        //public List<Ejercicio> ListaEjercicios { get {return this.listaEjercicios; } set {this.listaEjercicios = value; } }
        //public List<Socio> ListaSocios { get { return this.listaSocios; } set { this.listaSocios = value; } }

    }
}
