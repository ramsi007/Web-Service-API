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
    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;
        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }

        // POST: api/Contact
        public HttpResponseMessage Post([FromBody] Contact contact)
        {
            if (string.IsNullOrEmpty(contact?.Nom) || string.IsNullOrEmpty(contact?.Prenom))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " Le nom et les prénom sont obligatoir ...!");
            if (ContactRepository.SaveContact(contact))
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Erreur Lors de l'ajout du contact ... !");
        }

        // Put : api/Contact

        public HttpResponseMessage Put(int id, [FromBody] Contact contact)
        {
            if (string.IsNullOrEmpty(contact?.Nom) || string.IsNullOrEmpty(contact?.Prenom))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " Le nom et les prénom sont obligatoir" +
                    "pour faire la modification");
            if (ContactRepository.UpdateConact(id, contact))
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Erreur Lors de la modification ... !");
        }

        // DElete : api/Contact
        public HttpResponseMessage Delete(int id, [FromBody] Contact contact)
        {
                  
            if (ContactRepository.DeleteContact(id))
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Erreur Lors de la suppression ... !");
        }

    }
}
