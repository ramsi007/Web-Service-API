using GestionnaireContacts.Models;
using GestionnaireContacts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionnaireContacts.Controllers
{
    public class UtilisateurController : ApiController
    {
        private readonly IUtilisateurRepository userRepo = new UtilisateurRepository();

        // GET: api/Utilisateur
        public HttpResponseMessage Get()
        {
            IList<Utilisateur> listeUtilisateurs = userRepo.GetUtilisateurs();
            if (listeUtilisateurs == null || listeUtilisateurs.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Il n'existe aucun utilisateur");
            }
            return Request.CreateResponse(HttpStatusCode.OK, listeUtilisateurs);
        }

        // GET: api/Utilisateur/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Cette méthode n'est pas encore implémentée !");
        }

        // POST: api/Utilisateur
        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Cette méthode n'est pas encore implémentée !");
        }

        // PUT: api/Utilisateur/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Cette méthode n'est pas encore implémentée !");
        }

        // DELETE: api/Utilisateur/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Cette méthode n'est pas encore implémentée !");
        }
    }
}
