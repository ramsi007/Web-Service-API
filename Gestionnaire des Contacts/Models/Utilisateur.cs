using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionnaireContacts.Models
{
    public class Utilisateur
    {
        public uint Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public IList<Adresse> ListeAdresses { get; set; }
    }
}