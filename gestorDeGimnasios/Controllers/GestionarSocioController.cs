using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarSocioController
    {
        public List<Socio> obtenerSociosRegistrados() { 
            return new  SocioRepositorio().obtenerSociosRegistrados(); 
        }

        public bool registrarSocio(Socio socio) { 
            return new SocioRepositorio().registrarSocio(socio); 
        }

        public bool eliminarSocio(int idSocio) {
            return new SocioRepositorio().eliminarSocio(idSocio) ; 
        }

        public bool modificarSocio(Socio socio, int idSocio) {
            return new SocioRepositorio().modificarSocio(socio, idSocio); 
        }

        public List<Socio> obtenerSociosSegunTipo(string tipoSocio)
        {
            return new SocioRepositorio().obtenerSociosSegunTipo(tipoSocio);
        }
    }
}
