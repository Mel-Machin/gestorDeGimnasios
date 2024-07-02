namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class RutinaEjercicioRepositorio
    {/*
        public bool AgregarEjercicioARutina(int idRutina, int idEjercicio)
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

        public bool EliminarEjercicioDeRutina(int idEjercicio) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from rutinas_ejercicios WHERE id_ejercicio = @idEjercicio";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idEjercicio", idEjercicio);
            int afectados = sqlCommand.ExecuteNonQuery();
            conexion.Close();
            return afectados > 0;
        }

        public bool CambiarEjercicioDeRutina(RutinaEjercicio rutinaEjercicio, int idEjercicioACambiar) 
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE rutinas_ejercicios SET id_Ejercicio = @IdEjercicio WHERE id_Ejercicio = @idEjercicioACambiar";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idEjercicioACambiar", idEjercicioACambiar);
            sqlCommand.Parameters.AddWithValue("@IdEjercicio", rutinaEjercicio.IdEjercicio);
            conexion.Close();
            int actualizado = sqlCommand.ExecuteNonQuery();

            return actualizado > 0;

        }*/
    }
}



