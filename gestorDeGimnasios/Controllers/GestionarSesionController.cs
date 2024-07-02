using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarSesionController
    {
        public Usuario ObtenerDatosUsuario(int idUsuario)
        {
            return new SesionRepositorio().ObtenerDatosUsuario(idUsuario);
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            return new SesionRepositorio().RegistrarUsuario(usuario);
        }

        public Usuario IniciarSesion(string nombreUsuario, string email, string password)
        {
            return new SesionRepositorio().IniciarSesion(nombreUsuario, email, password);
        }

    }
}
