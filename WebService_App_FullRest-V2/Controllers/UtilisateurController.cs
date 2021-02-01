using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService_App_FullRestVersion2.Models;
using WebService_App_FullRestVersion2.Services;

namespace WebService_App_FullRestVersion2.Controllers
{
    public class UtilisateurController : ApiController
    {
        public readonly UtilisateurRepository userRepo = new UtilisateurRepository();
        

        // GET: api/Utilisateur

        public HttpResponseMessage Get()
        {
            IList<Utilisateur> ListeUtilisateurs = userRepo.GetAllUtilisateur();
            if(ListeUtilisateurs == null && ListeUtilisateurs.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Aucun utilisateur n'as été trouvé ...");
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListeUtilisateurs);
        }

        // GET: api/Utilisateur/5
        public HttpResponseMessage Get(ulong id)
        {
            Utilisateur utilisateur = userRepo.GetUtilisateur(id);
            if(utilisateur == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Aucun utilisateur n'a été trouvé");
            }
            return Request.CreateResponse(HttpStatusCode.OK, utilisateur);
        }

        // POST: api/Utilisateur
        public HttpResponseMessage Post([FromBody] Utilisateur utilisateur)
        {
            Utilisateur user = userRepo.AddUtilisateur(utilisateur);
            if(user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Aucun utilisateur n'as été trouvé ...");

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // PUT: api/Utilisateur/5
        public HttpResponseMessage Put(ulong id,[FromBody] Utilisateur utilisateur)
        {
            utilisateur.Id = id;
            bool IsUpdated = userRepo.UpdateUtilisateur(utilisateur);
            if ( !IsUpdated )
                return Request.CreateResponse(HttpStatusCode.NotFound, "Ouups ...! modification echoué ...");

            return Request.CreateResponse(HttpStatusCode.OK, utilisateur);
        }

        // DELETE: api/Utilisateur/5
        public HttpResponseMessage Delete(ulong id)
        {
            bool IsDeleted = userRepo.RemoveUtilisateur(id);
            if (!IsDeleted)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Ouups ...! modification echoué ...");

            return Request.CreateResponse(HttpStatusCode.OK, "utilisateur supprimé");
        }
    }
}
