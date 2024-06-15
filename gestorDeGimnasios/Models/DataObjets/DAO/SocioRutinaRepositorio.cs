using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;
using gestorDeGimnasios.Models.DataObjets.DAO;

namespace gestorDeGimnasios.Models.DataObjets.DAO{
    public class SocioRutinaRepositorio{
       public bool AgregarRutinaASocio(SocioRutina socioRutina, int idSocio, int idRutina) {

            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO socios_rutinas (id_socio, id_rutina, Fecha_inicio, Fecha_fin, calificacion) VALUES (@IdSocio,@IdRutina, @FechaInicio, @FechaFin, @Calificacion)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdRutina", idRutina);
            sqlCommand.Parameters.AddWithValue("@IdSocio", idSocio);
            sqlCommand.Parameters.AddWithValue("@FechaInicio", socioRutina.FechaInicio);
            sqlCommand.Parameters.AddWithValue("@FechaFin", socioRutina.FechaFin );
            sqlCommand.Parameters.AddWithValue("@Calificacion", socioRutina.Calificacion);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

       public bool EliminarRutinaASocio(int idRutina) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from socios_rutinas WHERE id_Rutina = @idRutina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idRutina", idRutina);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

       public bool ModificarRutinaASocio(SocioRutina socioRutina, int idRutina, int idSocio) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE socios_rutinas SET id_Rutina = @NuevoIdRutina, Fecha_inicio = @FechaInicio, Fecha_fin = @FechaFin, calificacion = @Calificacion WHERE id_Rutina = @idRutina AND id_socio = @idSocio";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@NuevoIdRutina", socioRutina.IdRutina);
            sqlCommand.Parameters.AddWithValue("@FechaInicio", socioRutina.FechaInicio);
            sqlCommand.Parameters.AddWithValue("@FechaFin", socioRutina.FechaFin);
            sqlCommand.Parameters.AddWithValue("@Calificacion", socioRutina.Calificacion);

            sqlCommand.Parameters.AddWithValue("@idRutina", idRutina);
            sqlCommand.Parameters.AddWithValue("@id_socio", idSocio);

            int actualizado = sqlCommand.ExecuteNonQuery();
            conexion.Close();
            return actualizado > 0;
        }
    }
}
