using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarMaquinaController
    {
        public List<Maquina> obtenerMaquinasRegistradas() { 
            return new MaquinaRepositorio().obtenerMaquinasRegistradas(); 
        }
        public bool registrarMaquina(Maquina maquina) {
            return new MaquinaRepositorio().registrarMaquina(maquina); 
        }
        public bool eliminarMaquina(int idMaquina) { 
            return new MaquinaRepositorio().eliminarMaquina(idMaquina); 
        }
        public bool modificarMaquina(Maquina maquina, int idMaquina) { 
            return new MaquinaRepositorio().modificarMaquina(maquina, idMaquina); 
        }
        public List<Maquina> obtenerMaquinasPorLocal(Local local) { 
            return new MaquinaRepositorio().ObtenerMaquinasPorLocal(local); 
        }
        public List<Maquina> ordenarMaquinasPorFechaCompra(string orden) {
            return new MaquinaRepositorio().ordenarMaquinasPorFechaCompra(orden);
        }
        public int calcularVidaUtilRestante(int idMaquina)
        {
            return new MaquinaRepositorio().calcularVidaUtilRestante(idMaquina);
        }
    }
}
