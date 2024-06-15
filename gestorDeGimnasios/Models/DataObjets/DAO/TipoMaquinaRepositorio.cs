using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class TipoMaquinaRepositorio
    {
        public List<TipoMaquina> obtenerTiposMaquinasRegistradas() {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM tipos_maquinas";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<TipoMaquina> tiposMaquinas = new List<TipoMaquina>();

            while (lector.Read())
            {
                TipoMaquina tipoMaquina = new TipoMaquina();
                tipoMaquina.IdTipoMaquina = lector.GetInt32(0);
                tipoMaquina.Nombre = lector.GetString(1);
                tiposMaquinas.Add(tipoMaquina);
            }

            conexion.Close();
            return tiposMaquinas;
        }

        public bool registrarTipoMaquina(TipoMaquina tipoMaquina) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO tipos_maquinas (Nombre_tipo_maquina) VALUES (@Nombre)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@Nombre", tipoMaquina.Nombre);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

        public bool eliminarTipoMaquina(int idTipoMaquina) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from tipos_maquinas WHERE id_tipo_maquina = @idTipoMaquina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idTipoMaquina", idTipoMaquina);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

        public bool modificarTipoMaquina(TipoMaquina tipoMaquina, int idTipoMaquina) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE tipos_maquinas SET Nombre_tipo_maquina = @Nombre WHERE id_tipo_maquina = @IdTipoMaquina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdTipoMaquina", idTipoMaquina);
            sqlCommand.Parameters.AddWithValue("@Nombre", tipoMaquina.Nombre);
            int actualizado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return actualizado > 0;
        }
    }
}
