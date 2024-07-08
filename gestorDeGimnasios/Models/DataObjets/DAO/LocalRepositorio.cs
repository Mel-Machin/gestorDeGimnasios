using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;


namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class LocalRepositorio
    {
        public List<Local> ObtenerLocalesRegistrados()
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM locales";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<Local> locales = new List<Local>();
            while (lector.Read())
            {
                Local local = new Local();
                local.IdLocal = (int)lector.GetDecimal(0);
                local.Nombre = lector.GetString(1);
                local.Ciudad = lector.GetString(2);
                local.Direccion = lector.GetString(3);
                local.Telefono = lector.GetString(4);
                local.IdResponsable = lector.IsDBNull(5) ? null : lector.GetInt32(5);
                local.Responsable = new ResponsableReposiotorio().ObtenerResponsable(local.IdResponsable);
                locales.Add(local);

            }

            conexion.Close();
            return locales;
        }

        public Local ObtenerLocal(int? idLocal)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM locales WHERE id_local = @IdLocal";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@IdLocal", idLocal);
            SqlDataReader lector = comando.ExecuteReader();
            lector.Read();
            Local local = new Local();
            local.IdLocal = (int)lector.GetDecimal(0);
            local.Nombre = lector.GetString(1);
            local.Ciudad = lector.GetString(2);
            local.Direccion = lector.GetString(3);
            local.Telefono = lector.GetString(4);
            local.IdResponsable = lector.IsDBNull(5) ? null : (int)lector.GetInt32(5);
            local.Responsable = new ResponsableReposiotorio().ObtenerResponsable(local.IdResponsable);
            conexion.Close();
            return local;
        }

        public bool RegistrarLocal(Local local)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO locales (Nombre_local, Ciudad_local, Dirección_local, Teléfono_local, id_responsable) VALUES (@Nombre, @Ciudad, @Direccion, @Telefono, @IdResponsable)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@Nombre", local.Nombre);
            sqlCommand.Parameters.AddWithValue("@Ciudad", local.Ciudad);
            sqlCommand.Parameters.AddWithValue("Direccion", local.Direccion);
            sqlCommand.Parameters.AddWithValue("Telefono", local.Telefono);
            sqlCommand.Parameters.AddWithValue("IdResponsable", local.IdResponsable);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

        public bool EliminarLocal(int? idLocal)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from locales WHERE id_local = @idLocal";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idLocal", idLocal);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

        public bool ModificarLocal(Local local, int? idLocal)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE locales SET Nombre_local = @Nombre, Ciudad_local = @Ciudad, Dirección_local= @Direccion, Teléfono_local= @Telefono, id_responsable = @IdResponsable  WHERE id_local = @idLocal";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idLocal", idLocal);
            sqlCommand.Parameters.AddWithValue("@Nombre", local.Nombre);
            sqlCommand.Parameters.AddWithValue("@Ciudad", local.Ciudad);
            sqlCommand.Parameters.AddWithValue("Direccion", local.Direccion);
            sqlCommand.Parameters.AddWithValue("Telefono", local.Telefono);
            sqlCommand.Parameters.AddWithValue("@IdResponsable", local.IdResponsable);
            int actualizado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return actualizado > 0;
        }

        public bool ExisteResponsableLocal(int? idResponsable)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM locales WHERE id_responsable = @IdResponsable ";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdResponsable", idResponsable);
            SqlDataReader lector = sqlCommand.ExecuteReader();
            bool estado = lector.HasRows;
            conexion.Close();
            return estado;
        }

    }
}
