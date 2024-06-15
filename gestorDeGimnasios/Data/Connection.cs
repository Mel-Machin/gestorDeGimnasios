using Microsoft.Data.SqlClient;


namespace gestorDeGimnasios.Data
{
    public class Connection { 
        public SqlConnection obtenerConexion()
        {
            string datosConexion = @"Data Source=ELBRUJOAQUINO\SQLEXPRESS;Initial Catalog=Gym24;Integrated Security=True;Encrypt=False;";

            SqlConnection conexion = new SqlConnection(datosConexion);
            return conexion;
        }
   
    }
}
