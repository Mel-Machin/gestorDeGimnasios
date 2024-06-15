using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarResponsableController
    {
        public List<Responsable> obtenerResponsablesRegistrados() { 
            return new ResponsableReposiotorio().obtenerResponsablesRegistrados();
        }
        public bool registrarResponsable(Responsable responsable) { 
            return new ResponsableReposiotorio().registrarResponsable(responsable); 
        }
        public bool modificarResponsable(Responsable responsable, int idResponsable) { 
            return new ResponsableReposiotorio().modificarResponsable(responsable, idResponsable);
        }
        public bool eliminarResponsable(int idResponsable) { 
            return new ResponsableReposiotorio().eliminarResponsable(idResponsable); 
        }
    }
}
