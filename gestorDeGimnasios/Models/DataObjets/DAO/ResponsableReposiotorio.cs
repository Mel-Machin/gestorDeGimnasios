using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class ResponsableReposiotorio
    {
        public List<Responsable> ObtenerResponsablesRegistrados()
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM Responsables";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<Responsable> responsables = new List<Responsable>();
            while (lector.Read())
            {
                Responsable responsable = new Responsable();
                responsable.IdResponsable = lector.GetInt32(0);
                responsable.Nombre = lector.GetString(1);
                responsable.Telefono = lector.GetString(2);
                responsable.NombreUsuario = lector.GetString(3);
                responsable.Contrasenia = lector.GetString(4);
                responsable.TipoUsuario = "responsable";
                responsables.Add(responsable);


            }

            conexion.Close();
            return responsables;
        }
        public Responsable ObtenerResponsable(int? idResponsable)
        {
            if (idResponsable != null)
            {
                SqlConnection conexion = new Connection().obtenerConexion();
                conexion.Open();
                string consulta = "SELECT * FROM Responsables WHERE id_responsable = @IdResponsable";
                SqlCommand sqlComando = new SqlCommand(consulta, conexion);
                sqlComando.Parameters.AddWithValue("@IdResponsable", idResponsable);
                SqlDataReader lector = sqlComando.ExecuteReader();
                lector.Read();
                Responsable responsable = new Responsable();
                responsable.IdResponsable = lector.GetInt32(0);
                responsable.Nombre = lector.GetString(1);
                responsable.Telefono = lector.GetString(2);
                responsable.NombreUsuario = lector.GetString(3);
                responsable.Contrasenia = lector.GetString(4);
                responsable.TipoUsuario = "responsable";
                conexion.Close();
                return responsable;
            }
            else
            {
                return null;
            }
        }
        public bool RegistrarResponsable(Responsable responsable)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO Responsables (Nombre_responsable,Telefono_responsable,usuario,contrasenia) VALUES (@Nombre, @Telefono,@usuario,@contrasenia)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@Nombre", responsable.Nombre);
            sqlCommand.Parameters.AddWithValue("@Telefono", responsable.Telefono);
            sqlCommand.Parameters.AddWithValue("@usuario", responsable.NombreUsuario);
            sqlCommand.Parameters.AddWithValue("@contrasenia", responsable.Contrasenia);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }
        public bool ModificarResponsable(Responsable responsable)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE Responsables SET nombre_responsable = @Nombre, telefono_responsable = @Telefono , usuario = @Usuario ,contrasenia = @Contrasenia WHERE id_responsable = @idResponsable";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idResponsable", responsable.IdResponsable);
            sqlCommand.Parameters.AddWithValue("@Nombre", responsable.Nombre);
            sqlCommand.Parameters.AddWithValue("@Telefono", responsable.Telefono);
            sqlCommand.Parameters.AddWithValue("@Usuario", responsable.NombreUsuario);
            sqlCommand.Parameters.AddWithValue("@Contrasenia", responsable.Contrasenia);

            int actualizado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return actualizado > 0;
        }
        public bool EliminarResponsable(int? idResponsable)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from Responsables WHERE id_responsable = @idResponsable";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idResponsable", idResponsable);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }


        public bool ExisteUsuarioResponsable(string? nombreUsuario )
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM Responsables WHERE usuario = @usuario ";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@usuario", nombreUsuario);
            SqlDataReader lector = sqlCommand.ExecuteReader();
            bool estado = lector.HasRows;
            conexion.Close();
            return estado;
        }

    }
}
