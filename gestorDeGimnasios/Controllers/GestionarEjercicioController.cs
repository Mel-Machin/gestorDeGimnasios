using gestorDeGimnasios.Models.DataObjets.DAO;
using gestorDeGimnasios.Models;
using gestorDeGimnasios.Data;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarEjercicioController
    {
        public List<Ejercicio> ObtenerEjerciciosRegistrados(){
            return new EjercicioRepositorio().ObtenerEjerciciosRegistrados();
        }

        public bool RegistrarEjercicio(Ejercicio ejercicio) {
            return new EjercicioRepositorio().RegistrarEjercicio(ejercicio);
        }

        public bool EliminarEjercicio(int idEjercicio){
            return new EjercicioRepositorio().EliminarEjercicio(idEjercicio);
        }

        public bool ModificarEjercicio(Ejercicio ejercicio, int idEjercicio) { 
            return new EjercicioRepositorio().ModificarEjercicio(ejercicio, idEjercicio); 
        }
    }
}
