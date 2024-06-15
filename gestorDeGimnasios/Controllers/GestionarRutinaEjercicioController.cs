using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarRutinaEjercicioController
    {
        public bool AgregarEjercicioARutina(int idRutina, int idEjercicio) {
            return new RutinaEjercicioRepositorio().AgregarEjercicioARutina(idRutina, idEjercicio);
        }
        public bool EliminarEjercicioDeRutina(int idEjercicio) {
            return new RutinaEjercicioRepositorio().EliminarEjercicioDeRutina(idEjercicio);
        }
        public bool CambiarEjercicioDeRutina(RutinaEjercicio rutinaEjercicio, int idEjercicioACambiar) {
            return new RutinaEjercicioRepositorio().CambiarEjercicioDeRutina(rutinaEjercicio, idEjercicioACambiar);
        }
    }
}
