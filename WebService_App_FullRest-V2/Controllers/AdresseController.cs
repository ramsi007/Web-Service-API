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
   
    public class AdresseController : ApiController
    {
        public readonly AdresseRepository adresseRepo = new AdresseRepository();
        // GET: api/Adresse
        public HttpResponseMessage Get()
        {
            IList<Adresse> ListeAdresse = adresseRepo.GetAllAdresse();
            if (ListeAdresse == null && ListeAdresse.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Aucune Adresse n'est été trouvé ...");
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListeAdresse);
  
        }

        // GET: api/Adresse/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Reportez une adresse sans spécifier l'utilisateur" +
                " concerné n'a aucun sens  ...!");
        }

        // POST: api/Adresse
        public HttpResponseMessage Post([FromBody] Adresse adresse)
        {
            Adresse adr = adresseRepo.AddAdresse(adresse);
            if(adr == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Aucune adresse n'a été trouvé ...!");

            return Request.CreateResponse(HttpStatusCode.OK, adr);
        }

        // PUT: api/Adresse/5
        public HttpResponseMessage Put(ulong id, [FromBody] Adresse adresse)
        {
            adresse.Id = id;
            bool IsUpdated = adresseRepo.UpdateAdresse(adresse);
            if (!IsUpdated)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Mis à jour échoué ...!");

                return Request.CreateResponse(HttpStatusCode.OK, adresse);
        }

        // DELETE: api/Adresse/5
        public HttpResponseMessage Delete(ulong id)
        { 
            bool IsDeleted = adresseRepo.RemoveAdresse(id);
            if (!IsDeleted)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Suppression échoué ...!");
            else
            return Request.CreateResponse(HttpStatusCode.OK, "Adresse dont Id :" + id + " supprimé");
        }
    }
}
