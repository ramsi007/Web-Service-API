using GestionnaireContacts.Models;
using GestionnaireContacts.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionnaireContacts.Services
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private IAdresseRepository adresseRepo = new AdresseRepository();

        public IList<Utilisateur> GetUtilisateurs()
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
                cmd.CommandText = "SELECT * FROM utilisateur";
                reader = cmd.ExecuteReader();

                IList<Utilisateur> listeUtilisateurs = new List<Utilisateur>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Utilisateur user = new Utilisateur();
                        user.Id = reader.GetUInt32(0);
                        user.Nom = reader.GetString(1);
                        user.Prenom = reader.GetString(2);
                        user.Email = reader.GetString(3);

                        user.ListeAdresses = new List<Adresse>();

                        IList<Adresse> listeAdresses = adresseRepo.GetAdresses(user.Id);
                        foreach (var adresse in listeAdresses)
                        {
                            user.ListeAdresses.Add(adresse);
                        }
                        listeUtilisateurs.Add(user);
                    }
                }
                return listeUtilisateurs;

            } catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération de la liste des utilisateurs");
                Console.WriteLine(ex);
                throw (ex);

            } finally
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

        public Utilisateur AddUtilisateur(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public Utilisateur GetUtilisateur(uint id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUtilisateur(uint id)
        {
            throw new NotImplementedException();
        }

        public void SetUtilisateur(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}