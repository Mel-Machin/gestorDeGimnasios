using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class SocioRutinaRepositorio
    {
        public bool AgregarRutinaASocio(SocioRutina socioRutina,int idSocio, int idRutina)
        {

            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO socios_rutinas (id_socio, id_rutina, Fecha_inicio, Fecha_fin, calificacion) VALUES (@IdSocio,@IdRutina, @FechaInicio, @FechaFin, @Calificacion)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdRutina", idRutina);
            sqlCommand.Parameters.AddWithValue("@IdSocio", idSocio);
            sqlCommand.Parameters.AddWithValue("@FechaInicio", socioRutina.FechaInicio);
            sqlCommand.Parameters.AddWithValue("@FechaFin", socioRutina.FechaFin);
            sqlCommand.Parameters.AddWithValue("@Calificacion", socioRutina.Calificacion);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

        public bool EliminarRutinaASocio(int idRutina)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from socios_rutinas WHERE id_Rutina = @idRutina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idRutina", idRutina);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

        public bool ModificarRutinaASocio(SocioRutina socioRutina, int idRutina, int idSocio)
        {
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

        public List<SocioRutina> ObtenerRutinasResgistradasSocio(int idSocio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT r.*,sr.* FROM socios_rutinas sr inner join rutinas r on sr.Id_rutina = r.id_rutina where sr.id_socio = @idsocio;";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@idsocio", idSocio);
            SqlDataReader lector = comando.ExecuteReader();

            List<SocioRutina> socioRutinas = new List<SocioRutina>();
            while (lector.Read())
            {

                Rutina rutina = new Rutina();
                rutina.IdRutina = (int)lector.GetDecimal(0);
                rutina.Descripcion = lector.GetString(1);
                rutina.TipoRutina = lector.GetString(2);
                rutina.CalificacionRutinaPromedio = lector.IsDBNull(3) ? null : lector.GetDecimal(3);
                
                SocioRutina socioRutina = new SocioRutina();
                socioRutina.Rutina = rutina;
                socioRutina.IdRutina = (int)lector.GetDecimal(5);
                socioRutina.FechaInicio = lector.GetDateTime(6);
                socioRutina.FechaFin = lector.GetDateTime(7);
                socioRutina.Calificacion = lector.GetDecimal(8);
                socioRutinas.Add( socioRutina );

            }
            conexion.Close();
            return socioRutinas;
        }
    }
}
