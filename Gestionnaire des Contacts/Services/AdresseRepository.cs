using GestionnaireContacts.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionnaireContacts.Services
{
    public class AdresseRepository : IAdresseRepository
    {
        public Adresse AddAdresse(Adresse adresse)
        {
            throw new NotImplementedException();
        }

        public IList<Adresse> GetAdresses(uint idUtilisateur)
        {
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = DbConnection.getInstance().getConnection();

                if (connection == null)
                {
                    throw new NullReferenceException("Impossible de récupérer une connexion");
                }
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM adresse WHERE utilisateur_id = @id";
                cmd.Parameters.AddWithValue("@id", idUtilisateur);
                reader = cmd.ExecuteReader();

                IList<Adresse> listeAdresses = new List<Adresse>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Adresse adresse = new Adresse();
                        adresse.Id = reader.GetUInt32(0);
                        adresse.Numero = reader.GetUInt32(1);
                        adresse.Rue = reader.GetString(2);
                        adresse.Ville = reader.GetString(3);
                        adresse.CodePostal = reader.GetString(4);
                        listeAdresses.Add(adresse);
                    }
                }
                return listeAdresses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération de la liste des adresses");
                Console.WriteLine(ex);
                throw (ex);

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void RemoveAdresse(uint id)
        {
            throw new NotImplementedException();
        }

        public void SetAdresse(Adresse adresse)
        {
            throw new NotImplementedException();
        }
    }
}