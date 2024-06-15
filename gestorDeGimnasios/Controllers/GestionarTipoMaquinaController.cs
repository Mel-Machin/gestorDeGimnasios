using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarTipoMaquinaController
    {
        public List<TipoMaquina> obtenerTiposMaquinasRegistradas() { 
            return new TipoMaquinaRepositorio().obtenerTiposMaquinasRegistradas() ; 
        }
        public bool registrarTipoMaquina(TipoMaquina tipoMaquina) { 
            return new TipoMaquinaRepositorio().registrarTipoMaquina(tipoMaquina);
        }
        public bool eliminarTipoMaquina(int idTipoMaquina) {
            return new TipoMaquinaRepositorio().eliminarTipoMaquina(idTipoMaquina);
        }
        public bool modificarTipoMaquina(TipoMaquina tipoMaquina, int idTipoMaquina) {
            return new TipoMaquinaRepositorio().modificarTipoMaquina(tipoMaquina, idTipoMaquina); 
        }
    }
}
