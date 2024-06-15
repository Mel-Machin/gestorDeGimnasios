using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarSocioRutinaController
    {
        public bool AgregarRutinaASocio(SocioRutina socioRutina, int idSocio, int idRutina)
        {
            return new SocioRutinaRepositorio().AgregarRutinaASocio(socioRutina, idSocio, idRutina);
        }

        public bool EliminarRutinaASocio(int idRutina)
        {
            return new SocioRutinaRepositorio().EliminarRutinaASocio(idRutina);
        }

        public bool ModificarRutinaASocio(SocioRutina socioRutina, int idRutina, int idSocio)
        {
            return new SocioRutinaRepositorio().ModificarRutinaASocio(socioRutina, idRutina, idSocio);
        }
    }
}
