using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService_App_FullRestVersion2.Models;

namespace WebService_App_FullRestVersion2.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore"; // élément de cache du serveur Web
        public ContactRepository()
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                if (context.Cache[CacheKey] == null)
                {
                    var contacts = new Contact[]
                    {
                    new Contact
                    {
                        Id = 1, Prenom = "Victor", Nom = "HUGO"
                    },
                    new Contact
                    {
                        Id = 2, Prenom = "Albert", Nom = "CAMUS"
                    }
                    };
                    context.Cache[CacheKey] = contacts;
                }
            }
        }
        public Contact[] GetAllContacts()
        {
            var ccontext = HttpContext.Current;
            if (ccontext != null)
            {
                return (Contact[])ccontext.Cache[CacheKey];
            }
            return new Contact[]
            {
            new Contact
            {
                Id = 0,
                Prenom = "One",
                Nom = "Placeholder"
            }
            };
        }

        public Contact[] GetContact()
        {
            var ccontext = HttpContext.Current;
            if (ccontext != null)
            {
                return (Contact[])ccontext.Cache[CacheKey];
            }
            return new Contact[]
            {
            new Contact
            {
                Id = 0,
                Prenom = "One",
                Nom = "Placeholder"
            }
            };
        }

        public static bool SaveContact(Contact contact)
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                try
                {
                    // récupère les contacts existants dans le cache
                    IList<Contact> ListeContacts = ((Contact[])context.Cache[CacheKey]).ToList();
                    // incrementer L'id

                    int maxId = 0;
                    if (ListeContacts.Count > 0)
                    {
                        maxId = ListeContacts.Max(x => x.Id);
                    }
                    contact.Id = maxId + 1;

                    // ajoute le nouveau contact
                    ListeContacts.Add(contact);
                    // mets à jour le cache avec le nouveau contenu des contacts
                    context.Cache[CacheKey] = ListeContacts.ToArray();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }

        public static bool UpdateConact(int id ,Contact contact)
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                try
                {
                    // récupère les contacts existants dans le cache
                    IList<Contact> ListeContacts = ((Contact[])context.Cache[CacheKey]).ToList();

                    var contactRecherche = ListeContacts.FirstOrDefault(x => x.Id == id);
                    if(contactRecherche != null)
                    {
                        //contactRecherche.Id= id;
                        contactRecherche.Nom = contact.Nom;
                        contactRecherche.Prenom = contact.Prenom;
                    }
                    return true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }

        public static bool DeleteContact(int id)
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                try
                {
                    // récupère les contacts existants dans le cache
                    IList<Contact> ListeContacts = ((Contact[])context.Cache[CacheKey]).ToList();
                    Contact contact = ListeContacts.FirstOrDefault(x => x.Id == id);
                    if (contact != null)
                    {
                        ListeContacts.Remove(contact);
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return false;
                }
            }
            return false;
        }
    }
    
}