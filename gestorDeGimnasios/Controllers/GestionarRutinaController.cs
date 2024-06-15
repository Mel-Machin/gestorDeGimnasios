using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarRutinaController
    {
        public List<Rutina> ObtenerRutinasResgistradas() { 
            return new RutinaRepositorio().ObtenerRutinasResgistradas(); 
        }
        public bool RegistrarRutina(Rutina rutina) { 
            return new RutinaRepositorio().RegistrarRutina(rutina); 
        }
        public bool EliminarRutina(int idRutina) { 
            return new RutinaRepositorio().EliminarRutina(idRutina); 
        }
        public bool ModificarRutina(Rutina rutina, int idRutina) { 
            return new RutinaRepositorio().ModificarRutina(rutina, idRutina); 
        }
    }
}
