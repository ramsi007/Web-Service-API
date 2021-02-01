using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.UI.WebControls;
using WebServiceApi_Web.Entities;

namespace WebServiceApi_Web.Controllers
{
    public class ClientController : ApiController
    {
        private static IList<Client> ListeClients { get; set; } = new List<Client>();
        // GET: http api/ws/Client
        public IList<Client> Get()
        {
            return ListeClients;
        }

        // GET: api/ws/Client/5
        public HttpResponseMessage Get(int id)
        {
            if(id<=0)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "L'id " + id + " n'est pas autorisé!");
            }
            var client = ListeClients.FirstOrDefault(x => x.Id == id);
            if(client != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, client);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Le client avec l'id "+ id +" n'existe pas...!");
        }

        // POST: api/ws/Client
        public HttpResponseMessage Post([FromBody] Client client)
        {
            if (string.IsNullOrEmpty(client?.Nom) || string.IsNullOrEmpty(client?.Prenom) || client?.NumSec <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Les Nom, Prenom et NumSecu sont obligatoires !");
            }

            var clientRecherche = ListeClients.FirstOrDefault(x => x.NumSec.Equals(client?.NumSec));
            if (clientRecherche != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Il y a violation de la contrainte d'unicité du NumSecu ! Le NumSecu existe déjà !");
            }
            uint maxId = 0;
            if (ListeClients.Count > 0)
            {
                maxId = ListeClients.Max(x => x.Id);
            }
            client.Id = maxId + 1;
            ListeClients.Add(client);
            return Request.CreateResponse(HttpStatusCode.OK, client);
        }



        // PUT: api/client/5
        // La méthode PUT permet de remplacer totalement le client concerné
        public HttpResponseMessage Put(int id, [FromBody] Client client)
        {
            if (string.IsNullOrEmpty(client?.Nom) || string.IsNullOrEmpty(client?.Prenom)
                || string.IsNullOrEmpty(client?.Adresse) || client?.NumSec<=0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Impossible de mettre à jour le client " + id + " car " +
                    "une ou toutes les propriétés du client à mettre à jour est(sont) nulle(s) ou vide(s)!");
            }
            var clientRecherche = ListeClients.FirstOrDefault(x => x.Id == id);
            if (clientRecherche != null)
            {
                // Mise à jour de toutes les propriétés de l'item concerné
                clientRecherche.Nom = client.Nom;
                clientRecherche.Prenom = client.Prenom;
                clientRecherche.Adresse = client.Adresse;
                clientRecherche.NumSec = client.NumSec;

                return Request.CreateResponse(HttpStatusCode.OK, clientRecherche);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Le client " + id + " à mettre à jour n'existe pas !");
        }

        // PATCH: api/Client/5
        public HttpResponseMessage Patch(uint id, [FromBody] string adresse)
        {

            var client = ListeClients.FirstOrDefault(x => x.Id == id);
            if (client != null)
            {

                client.Adresse = adresse;
                return Request.CreateResponse(HttpStatusCode.Accepted, "adresse Modifié ... !");
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " L'Id : " + id + "  n'existe pas ...!");
        }

        // DELETE: api/Client/5
        public HttpResponseMessage Delete(uint id)
        {
            Client client = ListeClients.FirstOrDefault(x => x.Id == id);
                if(client != null)
            {
                ListeClients.Remove(client);
                return Request.CreateResponse(HttpStatusCode.OK, client);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Le client avec l'id : "
                + id + " a suuprimer n'existe pas...!");
        }
    }
}
