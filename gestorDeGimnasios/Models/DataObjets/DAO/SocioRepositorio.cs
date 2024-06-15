﻿using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class SocioRepositorio
    {
        public List<Socio> obtenerSociosRegistrados() {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM socios";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<Socio> socios = new List<Socio>();
            while (lector.Read())
            {

                Socio socio = new Socio();
                socio.IdSocio = lector.GetInt32(0);
                socio.Nombre = lector.GetString(1);
                socio.Tipo = lector.GetString(2);
                socio.Telefono= lector.GetString(3);
                socio.CorreoElectronico = lector.GetString(4);
                socio.IdLocal = lector.GetInt32(5);
                socios.Add(socio);

            }

            conexion.Close();
            return socios;
        }

        public bool registrarSocio(Socio socio) {
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

        public bool eliminarSocio(int idSocio) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from socios WHERE id_socio = @idSocio";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idSocio", idSocio);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

        public bool modificarSocio(Socio socio, int idSocio) {
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

        public List<Socio> obtenerSociosSegunTipo(string tipoSocio) {
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
                socio.IdSocio = lector.GetInt32(0);
                socio.Nombre = lector.GetString(1);
                socio.Tipo = lector.GetString(2);
                socio.Telefono = lector.GetString(3);
                socio.CorreoElectronico = lector.GetString(4);
                socio.IdLocal = lector.GetInt32(5);
                socios.Add(socio);

            }

            conexion.Close();
            return socios;
        }
    }
}