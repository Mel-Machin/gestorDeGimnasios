using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO{
    public class SesionRepositorio{

        public Usuario obtenerDatosUsuario(int idUsuario){
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM usuarios WHERE idUsuario = @idUsuario";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader lector = sqlCommand.ExecuteReader();
            Usuario usuario = new();
            if (lector.Read()){
                usuario = new Usuario{
                    IdUsuario = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Apellido = lector.GetString(2),
                };
            }

            conexion.Close();
            return usuario;
        }

        public bool registrarUsuario(Usuario usuario) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO usuarios (nombreUsuario, password, email, nombre, apellido) VALUES (@NombreUsuario, @Password, @Email, @Nombre, @Apellido)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
            sqlCommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            sqlCommand.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            sqlCommand.Parameters.AddWithValue("@Password", usuario.Password);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

        public Usuario iniciarSesion(string nombreUsuario, string email, string password) {
            Usuario usuario = new();
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM usuarios WHERE (nombreUsuario = @nombreUsuario OR email = @email) AND password = @password";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@password", password);
            SqlDataReader lector = sqlCommand.ExecuteReader();
            if (lector.Read())
            {
                usuario = new Usuario
                {
                    IdUsuario = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Apellido = lector.GetString(2),
                };
            }

            conexion.Close();
            return usuario;
        }
    }
}
