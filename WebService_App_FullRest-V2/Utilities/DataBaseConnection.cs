using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService_App_FullRestVersion2.Utilities
{
    public sealed class DataBaseConnection
    {
        private static readonly string urlConnection = "SERVER=127.0.0.1; DATABASE=csharp_db; UID=root; PWD=root";
        private static DataBaseConnection instance = null;

        private DataBaseConnection()
        {

        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = null;
            try
            {
            connection = new MySqlConnection(urlConnection);
            }
            catch(Exception ex)
            {
                Console.WriteLine(" Erreur lors de la creation de la connexion ...!");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return connection;
        }

        public static DataBaseConnection getInstance()
        {
            if (instance == null)
            {
              instance = new DataBaseConnection();
            }
            return instance;
        }

    }
}