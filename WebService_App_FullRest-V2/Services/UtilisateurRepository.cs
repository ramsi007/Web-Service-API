using MySql.Data.MySqlClient;
using Renci.SshNet.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService_App_FullRestVersion2.Models;
using WebService_App_FullRestVersion2.Utilities;

namespace WebService_App_FullRestVersion2.Services
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        public Utilisateur AddUtilisateur(Utilisateur utilisateur)
        {
            MySqlConnection connection = null;
            MySqlTransaction transaction = null;
            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();
                if(connection == null)
                {
                    throw new NullReferenceException("Erreur lors de la récupération de connexion");
                }
                connection.Open();
                transaction = connection.BeginTransaction();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                cmd.CommandText = "INSERT INTO utilisateur(nom, prenom, email) VALUES(@nom, @prenom, @email)";
                cmd.Parameters.AddWithValue("@nom",utilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom",utilisateur.Prenom);
                cmd.Parameters.AddWithValue("@email",utilisateur.Email);

                int nbrLigneAjoutee = cmd.ExecuteNonQuery();
                transaction.Commit();

                utilisateur.Id = (ulong)cmd.LastInsertedId;

                return utilisateur;
            }
            catch(Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                    Console.WriteLine("Ouuups ...! On peut pas ajouter cet utilisateur");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }

        public IList<Utilisateur> GetAllUtilisateur()
        {
            AdresseRepository adresseRepo = new AdresseRepository();
            IList<Utilisateur> ListeUtilisateurs = new List<Utilisateur>();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();
                if (connection == null)
                {
                    throw new NullReferenceException("Impossible de récupérer une connexion");
                }
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from utilisateur";
                reader = cmd.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Utilisateur user = new Utilisateur();
                        user.ListesAdresses = new List<Adresse>();

                        user.Id = reader.GetUInt64(0);
                        user.Nom = reader.GetString(1);
                        user.Prenom = reader.GetString(2);
                        user.Email = reader.GetString(3);

                        IList<Adresse> Listesadr = adresseRepo.GetAdresse(user.Id);
                        foreach (Adresse a in Listesadr)
                        {
                            user.ListesAdresses.Add(a);
                        }
                        ListeUtilisateurs.Add(user);
                    }
                }
            return ListeUtilisateurs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Erreur Lors de la récupération de la liste des utilisateurs");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if(reader !=null) reader.Close();

                if(connection != null) connection.Close();
            }
        }

        public Utilisateur GetUtilisateur(ulong id)
        {
            Utilisateur user = new Utilisateur();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();
                if(connection == null)
                {
                    throw new NullReferenceException("Impossible de récuperer une Connexion ...!");
                }
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from utilisateur where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();
               
                if(reader != null && reader.HasRows)
                {
                    while(reader.Read())
                    {
                        user.Id = reader.GetUInt64(0);
                        user.Nom = reader.GetString(1);
                        user.Prenom = reader.GetString(2);
                        user.Email = reader.GetString(3);

                        AdresseRepository adresseRepo = new AdresseRepository();
                        IList<Adresse> Listeadr = adresseRepo.GetAdresse(user.Id);
                        user.ListesAdresses = new List<Adresse>();
                        foreach (Adresse a in Listeadr)
                        {
                            user.ListesAdresses.Add(a);
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ouuups! une erreur s'est exécuté lors de l'ajout d'utilisateur");
                Console.Write(ex.Message);
                throw ex;
            }
            finally
            {
                if (connection != null) connection.Close();
                if (reader != null) reader.Close();
            }
        }

        public bool RemoveUtilisateur(ulong id)
        {
            MySqlConnection connection = null;
            MySqlTransaction transaction = null;

            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();

                if(connection == null)
                {
                    throw new NullReferenceException("Echec ....!  Objet null...");
                }
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                transaction = connection.BeginTransaction();
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandText = "delete from utilisateur where id =@idU";

                cmd.Parameters.AddWithValue("@idU",id);
                int NbrLignesSupp = cmd.ExecuteNonQuery();
                transaction.Commit();

                transaction = connection.BeginTransaction();
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                cmd.CommandText = "delete from adresse where utilisateur_id=@idA";
                cmd.Parameters.AddWithValue("@idA", id);
                NbrLignesSupp = cmd.ExecuteNonQuery();
                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                Console.WriteLine("Mis à jours echoué ...!");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if (connection != null) connection.Close();
            }         
        }

        public bool UpdateUtilisateur(Utilisateur utilisateur)
        {
            MySqlConnection connection = null;
            MySqlTransaction transaction = null;

            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();

                if(connection == null)
                {
                    throw new NullReferenceException("Ouuuups...! L'objet est null...");
                }
                connection.Open();
                transaction = connection.BeginTransaction();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                cmd.CommandText = "update utilisateur set nom =@nom, prenom =@prenom, email =@email where id =@id";
                cmd.Parameters.AddWithValue("@nom",utilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom",utilisateur.Prenom);
                cmd.Parameters.AddWithValue("@email", utilisateur.Email);
                cmd.Parameters.AddWithValue("@id",utilisateur.Id);

                int nbrLigneUpdated = cmd.ExecuteNonQuery();
                transaction.Commit();

                return true;
            }
            catch(Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                Console.WriteLine("Mis à jours echoué ...!");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }
    }
}