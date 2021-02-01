using GestContacts.services;
using GestionnaireContacts.Models;
using System.Web.Http;

namespace GestionnaireContacts.Controllers
{
    public class ContactController : ApiController
    {

        //public string[] Get()
        //{
        //    return new string[]
        //    {
        //        "Hello",
        //        "World"
        //    };
        //}

        public Contact[] Get()
        {
            return new Contact[]
            {
                new Contact
                {
                    Id = 1,
                    Prenom = "Victor",
                    Nom = "HUGO"
                },
                new Contact
                {
                    Id = 2,
                    Prenom = "Albert",
                    Nom = "CAMUS"
                }
            };
        }

        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        //public Contact[] Get()
        //{
        //    return contactRepository.GetAllContacts();
        //}


    }
}
