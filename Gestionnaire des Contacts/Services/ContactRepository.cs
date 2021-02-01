using GestionnaireContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestContacts.services
{
    public class ContactRepository
    {
        // élément de cache du serveur web qui nous permet de stocker
        // les contacts ajoutés depuis le client.
        private const string CacheKey = "ContactStore";

        public ContactRepository()
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                if (context.Cache[CacheKey] == null)
                {
                    // initialiser la liste lors du démarrage de l'application :
                    //        var contacts = new Contact[]
                    //        {
                    //            new Contact
                    //            {
                    //                Id = 1,
                    //                Prenom = "Albert",
                    //            },
                    //            new Contact
                    //            {
                    //                Id = 2,
                    //                Prenom = "Victor",
                    //            }
                    //        };
                    context.Cache[CacheKey] = new Contact[0];
                }
            }
        }

        public Contact[] GetAllContacts()
        {
            var context = HttpContext.Current;

            //if (ccontext != null)
            //{
            //    return (Contact[])ccontext.Cache[CacheKey];
            //}
            //return new Contact[]
            //    {
            //        new Contact
            //        {
            //            Id = 0,
            //            Prenom = "Placeholder"
            //        }
            //    };

            try
            {
                if (context != null)
                {
                    return (Contact[])context.Cache[CacheKey];
                }
                return (new List<Contact>()).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool SaveContact(Contact contact)
        {
            var context = HttpContext.Current;
            try
            {
                if (context != null)
                {
                    // On récupère les contacts existants dans le cache
                    Object cache = context.Cache[CacheKey];
                    if (cache != null)
                    {
                        var listContactsInCache = ((Contact[])cache).ToList();

                        // on incrémente l'id par rapport au dernier id existant
                        // dans le cache.
                        var maxId = 0;
                        if (listContactsInCache.Count > 0)
                        {
                            maxId = listContactsInCache.Max(x => x.Id);
                        }
                        contact.Id = maxId + 1;

                        // On ajoute le nouveau contact au cache
                        listContactsInCache.Add(contact);

                        // Mise à jour du cache avec le nouveau contenu 
                        context.Cache[CacheKey] = listContactsInCache.ToArray();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return false;
        }

        public bool UpdateContact(Contact contact)
        {
            //TODO
            return false;
        }

        public bool DeleteContact(Contact contact)
        {
            //TODO
            return false;
        }

    }
}