using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebService_App_FullRestVersion2.Models;
using WebService_App_FullRestVersion2.Utilities;

namespace WebService_App_FullRestVersion2.Services
{
    public class AdresseRepository : IAdresseRepository
    {
        public Adresse AddAdresse(Adresse adresse)
        {
            MySqlConnection connection = null;
            MySqlTransaction transaction = null;
            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();
                if (connection == null)
                {
                    throw new NullReferenceException(" Erreur lors de la récupération de la connexion");
                }
                connection.Open();
                transaction = connection.BeginTransaction();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                cmd.CommandText = "insert into adresse (numero, rue, ville, code_postal, utilisateur_id) " +
                                  "values (@numero, @rue, @ville, @code_postal, @utilisateur_id)";

                cmd.Parameters.AddWithValue("@numero", adresse.Numero);
                cmd.Parameters.AddWithValue("@rue", adresse.Rue);
                cmd.Parameters.AddWithValue("@ville", adresse.Ville);
                cmd.Parameters.AddWithValue("@code_postal", adresse.CodePostal);
                cmd.Parameters.AddWithValue("@utilisateur_id", adresse.UtilisateurId);

                int nbrAjoutee = cmd.ExecuteNonQuery();
                transaction.Commit();
                adresse.Id = (ulong)cmd.LastInsertedId;

                return adresse;

            }
            catch(Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                Console.WriteLine(" Erreur ...! on peut pas ajouter cette adresse");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            
        }

        ///   /////////////////////////////////////
        ///   
        public IList<Adresse> GetAllAdresse()
        {
            IList<Adresse> ListeAdresses = new List<Adresse>();
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();
                if(connection == null)
                {
                    throw new NullReferenceException("Erreur lors de l'ouverture de la connection");
                }
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from adresse";
                
                reader = cmd.ExecuteReader();
                    if(reader != null && reader.HasRows==true)
                    {
                    while(reader.Read())
                        {
                            Adresse adresse = new Adresse();
                            adresse.Id = reader.GetUInt64(0);
                            adresse.Numero = reader.GetUInt32(1);
                            adresse.Rue = reader.GetString(2);
                            adresse.Ville = reader.GetString(3);
                            adresse.CodePostal = reader.GetString(4);
                            adresse.UtilisateurId = reader.GetUInt64(5);

                            ListeAdresses.Add(adresse);
                        }
                    }

                return ListeAdresses;
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(" Erreur lors de récupération de la liste des adresses ... !");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (connection != null) connection.Close();
            }
        }

        public IList<Adresse> GetAdresse(ulong id)
        {
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            IList<Adresse> ListeAdresses = new List<Adresse>();
            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();
                if (connection == null)
                {
                    throw new NullReferenceException("Impossible de créer unr Connexion d'aprés un objet null ...");
                }
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from adresse where utilisateur_id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Adresse adresse = new Adresse();
                        adresse.Id = reader.GetUInt64(0);
                        adresse.Numero = reader.GetUInt32(1);
                        adresse.Rue = reader.GetString(2);
                        adresse.Ville = reader.GetString(3);
                        adresse.CodePostal = reader.GetString(4);
                        adresse.UtilisateurId = reader.GetUInt64(5);

                        ListeAdresses.Add(adresse);
                    }
                }
                return ListeAdresses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Erreur lors de récupération de la liste des adresses ... !");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (connection != null) connection.Close();
            }

        }

        public bool RemoveAdresse(ulong id)
        {
            MySqlConnection connection = null;
            MySqlTransaction transaction = null;

            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();
                if(connection ==  null)
                {
                    throw new NullReferenceException("Ouuuups ...! Objet null ...");
                }
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                transaction = connection.BeginTransaction();
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandText = "delete from adresse where id=@id";
                cmd.Parameters.AddWithValue("@id",id);

                int NbrLignesSupp = cmd.ExecuteNonQuery();
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

        public bool UpdateAdresse(Adresse adresse)
        {
            MySqlConnection connection = null;
            MySqlTransaction transaction = null;

            try
            {
                connection = DataBaseConnection.getInstance().GetConnection();
                if(connection == null)
                {
                    throw new NullReferenceException("Ouuups ...! Objet null");
                }

                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                transaction = connection.BeginTransaction();
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                cmd.CommandText = "update adresse set numero =@numero, rue =@rue, ville=@ville, " +
                    "code_postal=@codepostal where id=@id && utilisateur_id =@Uid";

               // Adresse adresse = new Adresse();
                
                cmd.Parameters.AddWithValue("@numero",adresse.Numero);
                cmd.Parameters.AddWithValue("@rue",adresse.Rue);
                cmd.Parameters.AddWithValue("@ville",adresse.Ville);
                cmd.Parameters.AddWithValue("@codepostal",adresse.CodePostal);
                cmd.Parameters.AddWithValue("@Uid", adresse.UtilisateurId);
                cmd.Parameters.AddWithValue("@id",adresse.Id);

                int nbrLignesUpdated = cmd.ExecuteNonQuery();
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
    }
}