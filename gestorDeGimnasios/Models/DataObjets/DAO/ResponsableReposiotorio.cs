﻿using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class ResponsableReposiotorio
    {
        public List<Responsable> ObtenerResponsablesRegistrados()
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM Responsables";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<Responsable> responsables = new List<Responsable>();
            while (lector.Read())
            {
                Responsable responsable = new Responsable();
                responsable.IdResponsable= lector.GetInt32(0);
                responsable.Nombre = lector.GetString(1);
                responsable.Telefono = lector.GetString(2);
                responsables.Add(responsable);

            }

            conexion.Close();
            return responsables;
        }
        public Responsable ObtenerResponsable(int idResponsable)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM Responsables WHERE id_responsable = @IdResponsable";
            SqlCommand sqlComando = new SqlCommand(consulta, conexion);
            sqlComando.Parameters.AddWithValue("@IdResponsable", idResponsable);
            SqlDataReader lector = sqlComando.ExecuteReader();
            lector.Read();
                Responsable responsable = new Responsable();
                responsable.IdResponsable = lector.GetInt32(0);
                responsable.Nombre = lector.GetString(1);
                responsable.Telefono = lector.GetString(2);
            conexion.Close();
            return responsable;
        }
        public bool RegistrarResponsable(Responsable responsable)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO Responsables (Nombre_responsable,Telefono_responsable) VALUES (@Nombre, @Telefono)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@Nombre", responsable.Nombre);
            sqlCommand.Parameters.AddWithValue("@Telefono", responsable.Telefono);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }
        public bool ModificarResponsable(Responsable responsable, int idResponsable) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE Responsables SET nombre_responsable = @Nombre, telefono_responsable = @Telefono WHERE id_responsable = @idResponsable";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idResponsable", idResponsable);
            sqlCommand.Parameters.AddWithValue("@Nombre", responsable.Nombre);
            sqlCommand.Parameters.AddWithValue("Telefono", responsable.Telefono);
            
            int actualizado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return actualizado > 0;
        }
        public bool EliminarResponsable(int idResponsable) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from Responsables WHERE id_responsable = @idResponsable";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@idResponsable", idResponsable);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

    }
}
