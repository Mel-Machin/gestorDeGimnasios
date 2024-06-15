using gestorDeGimnasios.Models.DataObjets.DAO;
using gestorDeGimnasios.Models;

namespace gestorDeGimnasios.Controllers{
    public class GestionarSesionController{
        public Usuario obtenerDatosUsuario(int idUsuario){
            return new SesionRepositorio().obtenerDatosUsuario(idUsuario);
        }

        public bool registrarUsuario(Usuario usuario) { 
            return new SesionRepositorio().registrarUsuario(usuario); 
        }

        public Usuario iniciarSesion(string nombreUsuario, string email, string password){ 
            return new SesionRepositorio().iniciarSesion(nombreUsuario, email, password); 
        }

    }
}
