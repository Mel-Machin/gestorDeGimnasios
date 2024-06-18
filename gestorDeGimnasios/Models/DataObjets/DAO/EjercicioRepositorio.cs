using gestorDeGimnasios.Models;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Data{
    public class EjercicioRepositorio{
        public List<Ejercicio> ObtenerEjerciciosRegistrados(){
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM ejercicios";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<Ejercicio> ejercicios = new List<Ejercicio>();
            while (lector.Read())
            {

                Ejercicio ejercicio = new Ejercicio();
                ejercicio.IdEjercicio = (int)lector.GetDecimal(0);
                ejercicio.Descripcion = lector.GetString(1);
                ejercicio.IdTipoMaquina = (int)lector.GetInt32(3);
                ejercicios.Add(ejercicio);

            }

            conexion.Close();
            return ejercicios;
        }

        public Ejercicio ObtenerEjercicio(int idEjercicio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM ejercicios";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            lector.Read();
            Ejercicio ejercicio = new Ejercicio();
            ejercicio.IdEjercicio = (int)lector.GetDecimal(0);
            ejercicio.Descripcion = lector.GetString(1);
            ejercicio.IdTipoMaquina = lector.GetInt32(3);
            conexion.Close();
            return ejercicio;
        }
        public bool RegistrarEjercicio(Ejercicio ejercicio){
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO ejercicios (Descripcion_ejercicio, Id_tipo_maquina) VALUES (@Descripcion, @idTipoMaquina)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@Descripcion", ejercicio.Descripcion);
            sqlCommand.Parameters.AddWithValue("@idTipoMaquina", ejercicio.IdTipoMaquina);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

        public bool EliminarEjercicio(int idEjercicio) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from ejercicios WHERE id_ejercicio = @idEjercicio";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idEjercicio", idEjercicio);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
            
        }

        public bool ModificarEjercicio(Ejercicio ejercicio, int idEjercicio) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE ejercicios SET Descripcion_ejercicio = @Descripcion, Id_tipo_maquina = @IdTipoMaquina WHERE id_Ejercicio = @idEjercicio";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idEjercicio", idEjercicio);
            sqlCommand.Parameters.AddWithValue("@Descripcion", ejercicio.Descripcion);
            sqlCommand.Parameters.AddWithValue("@idTipoMaquina", ejercicio.IdTipoMaquina);
            int actualizado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return actualizado > 0;
        }

    }
}
