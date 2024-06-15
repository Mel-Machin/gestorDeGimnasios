﻿using gestorDeGimnasios.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace gestorDeGimnasios.Models.DataObjets.DAO
{
    public class MaquinaRepositorio
    {
        public List<Maquina> obtenerMaquinasRegistradas()
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM maquinas";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            List<Maquina> maquinas = new List<Maquina>();

            while (lector.Read())
            {
                Maquina maquina = new Maquina();
                maquina.IdMaquina = lector.GetInt32(0);
                maquina.IdLocal= lector.GetInt32(1);
                maquina.FechaCompra = lector.GetDateTime(2);
                maquina.Precio = lector.GetDecimal(3);
                maquina.VidaUtil = lector.GetInt16(4);
                maquina.IdTipoMaquina = lector.GetInt32(5);
                maquina.Disponibilidad = lector.GetString(6);
                maquinas.Add(maquina);
            }

            conexion.Close();
            return maquinas;
        }

        public bool registrarMaquina(Maquina maquina) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO maquinas (Id_tipo_maquina, Id_local, Fecha_compra, Precio_compra, Vida_util, Disponibilidad) VALUES (@IdTipoMaquina, @IdLocal, @FechaCompra, @Precio, @VidaUtil, @Disponibilidad)";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdTipoMaquina", maquina.IdTipoMaquina);
            sqlCommand.Parameters.AddWithValue(" @IdLocal", maquina.IdLocal);
            sqlCommand.Parameters.AddWithValue("@FechaCompra", maquina.FechaCompra);
            sqlCommand.Parameters.AddWithValue("@Precio", maquina.Precio);
            sqlCommand.Parameters.AddWithValue("@VidaUtil", maquina.VidaUtil);
            sqlCommand.Parameters.AddWithValue("@Disponibilidad", maquina.Disponibilidad);
            int creado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return creado > 0;
        }

        public bool eliminarMaquina(int idMaquina) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "DELETE from maquinas WHERE id_maquina = @IdMaquina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdMaquina", idMaquina);
            int afectados = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return afectados > 0;
        }

        public bool modificarMaquina(Maquina maquina, int idMaquina) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "UPDATE maquinas SET Id_tipo_maquina = @IdTipoMaquina, Id_local = @IdLocal, Fecha_compra= @FechaCompra, Precio_compra= @Precio, Vida_util = @VidaUtil, Disponibilidad = @Disponibilidad WHERE id_maquina = @idMaquina";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdMaquina", idMaquina);
            sqlCommand.Parameters.AddWithValue("@IdTipoMaquina", maquina.IdTipoMaquina);
            sqlCommand.Parameters.AddWithValue("@IdLocal", maquina.IdLocal);
            sqlCommand.Parameters.AddWithValue("@FechaCompra", maquina.FechaCompra);
            sqlCommand.Parameters.AddWithValue("@Precio", maquina.Precio);
            sqlCommand.Parameters.AddWithValue("@VidaUtil", maquina.VidaUtil);
            sqlCommand.Parameters.AddWithValue("@Disponibilidad", maquina.Disponibilidad);
            int actualizado = sqlCommand.ExecuteNonQuery();

            conexion.Close();
            return actualizado > 0; 
        }

        public List<Maquina> ObtenerMaquinasPorLocal(Local local) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM maquinas WHERE Id_local = @IdLocal";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@IdLocal", local.IdLocal);
            SqlDataReader lector = sqlCommand.ExecuteReader();
            List<Maquina> maquinas = new List<Maquina>();

            while (lector.Read())
            {
                Maquina maquina = new Maquina();
                maquina.IdMaquina = lector.GetInt32(0);
                maquina.IdLocal = lector.GetInt32(1);
                maquina.FechaCompra = lector.GetDateTime(2);
                maquina.Precio = lector.GetDecimal(3);
                maquina.VidaUtil = lector.GetInt16(4);
                maquina.IdTipoMaquina = lector.GetInt32(5);
                maquina.Disponibilidad = lector.GetString(6);
                maquinas.Add(maquina);
            }

            conexion.Close();
            return maquinas;
        }

        public List<Maquina> ordenarMaquinasPorFechaCompra(string orden)
        {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "sp_ObtenerMaquinasOrdenadas";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Orden", orden);

            SqlDataReader lector = sqlCommand.ExecuteReader();
            List<Maquina> maquinasOrdenadas = new List<Maquina>();
            while (lector.Read())
            {
                Maquina maquina = new Maquina();
                maquina.IdMaquina = lector.GetInt32(0);
                maquina.IdLocal = lector.GetInt32(1);
                maquina.FechaCompra = lector.GetDateTime(2);
                maquina.Precio = lector.GetDecimal(3);
                maquina.VidaUtil = lector.GetInt16(4);
                maquina.IdTipoMaquina = lector.GetInt32(5);
                maquina.Disponibilidad = lector.GetString(6);
                maquinasOrdenadas.Add(maquina);
            }

            conexion.Close();
            return maquinasOrdenadas;
        }

    
        public int calcularVidaUtilRestante(int idMaquina) {
            SqlConnection conexion = new Connection().obtenerConexion();
            conexion.Open();
            string consulta = "SELECT dbo.fn_CalcularVidaUtilRestante(@id_maquina) AS VidaUtilRestante";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            sqlCommand.Parameters.AddWithValue("@id_maquina", idMaquina);
            SqlDataReader lector = sqlCommand.ExecuteReader();
            if (lector.Read())
            {
                conexion.Close();
                return lector.GetInt32(lector.GetOrdinal("VidaUtilRestante"));
            }
            else
            {
                throw new Exception("No se encontró la máquina especificada.");
            }
        }
    }
}