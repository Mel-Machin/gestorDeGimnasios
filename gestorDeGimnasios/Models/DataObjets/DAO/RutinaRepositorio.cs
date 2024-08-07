﻿using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class RutinaRepositorio
    {
        public List<Rutina> ObtenerRutinasResgistradas()
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM rutinas";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<Rutina> rutinas = new List<Rutina>();
            while (lector.Read())
            {

                Rutina rutina = new Rutina();
                rutina.IdRutina = (int)lector.GetDecimal(0);
                rutina.Descripcion = lector.GetString(1);
                rutina.TipoRutina = lector.GetString(2);
                rutina.CalificacionRutinaPromedio = lector.IsDBNull(3) ? null : lector.GetDecimal(3);
                rutina.ListaEjercicios = new EjercicioRepositorio().ObtenerEjerciciosPorRutina(rutina.IdRutina);
                rutinas.Add(rutina);

            }
            conexion.Close();
            return rutinas;
        }

        public Rutina ObtenerRutina(int? idRutina)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM rutinas  WHERE id_rutina = @IdRutina";
            SqlCommand sqlComando = new SqlCommand(consulta, conexion);
            sqlComando.Parameters.AddWithValue("@IdRutina", idRutina);
            SqlDataReader lector = sqlComando.ExecuteReader();
            lector.Read();
            Rutina rutina = new Rutina();
            rutina.IdRutina = (int)lector.GetDecimal(0);
            rutina.Descripcion = lector.GetString(1);
            rutina.TipoRutina = lector.GetString(2);
            rutina.CalificacionRutinaPromedio = lector.IsDBNull(3) ? null : lector.GetDecimal(3);
            rutina.ListaEjercicios = new EjercicioRepositorio().ObtenerEjerciciosPorRutina(rutina.IdRutina);
            conexion.Close();
            return rutina;
        }

        public bool RegistrarRutina(Rutina rutina)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO rutinas (Descripcion_rutina, Tipo_rutina) VALUES (@Descripcion, @TipoRutina)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@Descripcion", rutina.Descripcion);
            sqlCommand.Parameters.AddWithValue("@TipoRutina", rutina.TipoRutina);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

        public bool EliminarRutina(int? idRutina)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from rutinas WHERE id_rutina = @idRutina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idRutina", idRutina);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

        public bool ModificarRutina(Rutina rutina, int? idRutina)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE rutinas SET Descripcion_rutina = @Descripcion, Tipo_rutina = @TipoRutina WHERE id_rutina = @idRutina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idRutina", idRutina);
            sqlCommand.Parameters.AddWithValue("@Descripcion", rutina.Descripcion);
            sqlCommand.Parameters.AddWithValue("@TipoRutina", rutina.TipoRutina);
            int actualizado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return actualizado > 0;
        }

        public List<Rutina> ObtenerRutinaSocio(int? idSocio)
        {
            return null;
        }
    }
}
