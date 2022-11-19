using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class MyConnection
    {
        MySqlConnection conex = new MySqlConnection();
        static string servidor = "localhost";
        static string bd = "libraryconsoleappcsharp";
        static string usuario = "root";
        static string password = "";
        static string puerto = "3306";

        string cadenaConexion = 
            "server=" + servidor + ";" +
            "port=" + puerto +  ";" +
            "user id="  + usuario + ";" +
            "password=" + password + ";" +
            "database=" + bd + ";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                Console.WriteLine("Se logro la conexion correctamente con la bd.");
                
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            
            return conex;
        }
        public void cerrarConexion()
        {
            conex.Close();
        }
    }
}
