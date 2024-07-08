using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class SocioRepositorio
    {
        public List<Socio> ObtenerSociosRegistrados()
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM socios";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<Socio> socios = new List<Socio>();
            while (lector.Read())
            {

                Socio socio = new Socio();
                socio.IdSocio = (int)lector.GetDecimal(0);
                socio.Nombre = lector.GetString(2);
                socio.Apellido = lector.GetString(3);
                socio.Tipo = lector.GetString(1);
                socio.Telefono = lector.GetString(4);
                socio.CorreoElectronico = lector.GetString(5);
                socio.IdLocal = lector.IsDBNull(6) ? null : (int)lector.GetDecimal(6);
                socio.Local = new LocalRepositorio().ObtenerLocal(socio.IdLocal);
                socios.Add(socio);
                socio.ListaSocioRutinas = new SocioRutinaRepositorio().ObtenerRutinasResgistradasSocio(socio.IdSocio);

            }

            conexion.Close();
            return socios;
        }

        public Socio ObtenerSocio(int? idSocio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM socios WHERE id_socio = @IdSocio";
            SqlCommand sqlComando = new SqlCommand(consulta, conexion);
            sqlComando.Parameters.AddWithValue("@IdSocio", idSocio);
            SqlDataReader lector = sqlComando.ExecuteReader();
            lector.Read();
            Socio socio = new Socio();
            socio.IdSocio = (int)lector.GetDecimal(0);
            socio.Nombre = lector.GetString(2);
            socio.Apellido = lector.GetString(3);
            socio.Tipo = lector.GetString(1);
            socio.Telefono = lector.GetString(4);
            socio.CorreoElectronico = lector.GetString(5);
            socio.IdLocal = lector.IsDBNull(6) ? null : (int)lector.GetDecimal(6);
            socio.Local = new LocalRepositorio().ObtenerLocal(socio.IdLocal);
            socio.ListaSocioRutinas = new SocioRutinaRepositorio().ObtenerRutinasResgistradasSocio(socio.IdSocio);
            conexion.Close();
            return socio;
        }

        public bool RegistrarSocio(Socio socio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO socios (Tipo_socio, Nombre_socio, Apellido_socio, Telefono_socio, Mail_socio, Id_local) VALUES (@Tipo, @Nombre, @Apellido, @Telefono, @CorreoElectronico, @IdLocal)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@Tipo", socio.Tipo);
            sqlCommand.Parameters.AddWithValue("@Nombre", socio.Nombre);
            sqlCommand.Parameters.AddWithValue("@Apellido", socio.Apellido);
            sqlCommand.Parameters.AddWithValue("@Telefono", socio.Telefono);
            sqlCommand.Parameters.AddWithValue("@CorreoElectronico", socio.CorreoElectronico);
            sqlCommand.Parameters.AddWithValue("@IdLocal", socio.IdLocal);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

        public bool EliminarSocio(int? idSocio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from socios WHERE id_socio = @idSocio";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idSocio", idSocio);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

        public bool ModificarSocio(Socio socio, int? idSocio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE socios SET Tipo_socio = @Tipo, Nombre_socio = @Nombre, Apellido_socio = @Apellido, Telefono_socio = @Telefono, Mail_socio = @CorreoElectronico, Id_local = @IdLocal  WHERE id_socio = @idSocio";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idSocio", idSocio);
            sqlCommand.Parameters.AddWithValue("@Tipo", socio.Tipo);
            sqlCommand.Parameters.AddWithValue("@Nombre", socio.Nombre);
            sqlCommand.Parameters.AddWithValue("@Apellido", socio.Apellido);
            sqlCommand.Parameters.AddWithValue("@Telefono", socio.Telefono);
            sqlCommand.Parameters.AddWithValue("@CorreoElectronico", socio.CorreoElectronico);
            sqlCommand.Parameters.AddWithValue("@IdLocal", socio.IdLocal);
            int actualizado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return actualizado > 0;
        }

        public List<Socio> ObtenerSociosSegunTipo(string tipoSocio)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM socios WHERE Tipo_socio = @tipoSocio";
            SqlCommand sqlComando = new SqlCommand(consulta, conexion);
            sqlComando.Parameters.AddWithValue("@tipoSocio", tipoSocio);
            SqlDataReader lector = sqlComando.ExecuteReader();
            List<Socio> socios = new List<Socio>();
            while (lector.Read())
            {

                Socio socio = new Socio();
                socio.IdSocio = (int)lector.GetDecimal(0);
                socio.Nombre = lector.GetString(2);
                socio.Apellido = lector.GetString(3);
                socio.Tipo = lector.GetString(1);
                socio.Telefono = lector.GetString(4);
                socio.CorreoElectronico = lector.GetString(5);
                socio.IdLocal = lector.IsDBNull(6) ? null : (int)lector.GetDecimal(6);
                socio.ListaSocioRutinas = new SocioRutinaRepositorio().ObtenerRutinasResgistradasSocio(socio.IdSocio);
                socios.Add(socio);


            }

            conexion.Close();
            return socios;
        }

        
    }
}
