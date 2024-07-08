using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class SesionRepositorio
    {
        public bool IniciarSesion(Usuario usuario){
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM responsables WHERE usuario = @usuarioALoguiarse AND contrasenia = @contrasenia";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@usuarioALoguiarse", usuario.NombreUsuario);
            sqlCommand.Parameters.AddWithValue("@contrasenia", usuario.Contrasenia);
            SqlDataReader lector = sqlCommand.ExecuteReader();
            
            bool estado= lector.HasRows;
            conexion.Close();
            return estado;
        }
      
    }
}
