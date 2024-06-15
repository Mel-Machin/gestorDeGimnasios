using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarLocalController
    {
        public List<Local> obtenerLocalesRegistrados() { 
            return new LocalRepositorio().obtenerLocalesRegistrados(); 
        }
        public bool registrarLocal(Local local) { 
            return new LocalRepositorio().registrarLocal(local);
        }
        public bool eliminarLocal(int idLocal) {
            return new LocalRepositorio().eliminarLocal(idLocal); 
        }
        public bool modificarLocal(Local local, int idLocal) { 
            return new LocalRepositorio().modificarLocal(local, idLocal); 
        }
    }
}
