using Microsoft.Data.SqlClient;
using gestorDeGimnasios.Data;
namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class RutinaEjercicioRepositorio
    {
        public bool AgregarEjercicioARutina(int? idRutina, int? idEjercicio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO rutinas_ejercicios (id_rutina, id_Ejercicio) VALUES (@IdRutina, @IdEjercicio)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdRutina", idRutina);
            sqlCommand.Parameters.AddWithValue("@IdEjercicio", idEjercicio);
            int creado = sqlCommand.ExecuteNonQuery();
            conexion.Close();
            return creado > 0;
        }

        public bool EliminarEjercicioDeRutina(int? idRutina, int? idEjercicio) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from rutinas_ejercicios WHERE id_ejercicio = @idEjercicio AND id_rutina=@idRutina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idEjercicio", idEjercicio);
            sqlCommand.Parameters.AddWithValue("@idRutina", idRutina);
            int afectados = sqlCommand.ExecuteNonQuery();
            conexion.Close();
            return afectados > 0;
        }

        public bool ExisteEjercicioRutina(int? idRutina, int? idEjercicio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * from rutinas_ejercicios WHERE id_ejercicio = @idEjercicio AND id_rutina=@idRutina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idEjercicio", idEjercicio);
            sqlCommand.Parameters.AddWithValue("@idRutina", idRutina);
            SqlDataReader lector = sqlCommand.ExecuteReader();
            bool estado = lector.HasRows;
            conexion.Close();
            return estado;
        }
    



    }
}



