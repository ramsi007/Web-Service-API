using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GestionnaireContacts.Services
{
    public class DbConnection
    {
        private static readonly string urlConnection = "SERVER=127.0.0.1; DATABASE=csharp_db; UID=root; PWD=root";
        private static DbConnection instance = null;

        private DbConnection()
        {
        }

        public MySqlConnection getConnection()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(urlConnection);
            } catch(Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération d'une connexion");
                Console.WriteLine(ex);
                throw (ex);
            }
            return connection;
        }

        public static DbConnection getInstance()
        {
            if (instance == null)
            {
                instance = new DbConnection();
            }
            return instance;
        }

    }
}