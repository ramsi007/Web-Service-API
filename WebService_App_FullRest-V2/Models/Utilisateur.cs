using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService_App_FullRestVersion2.Models
{
    public class Utilisateur
    {
        public ulong Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        public IList<Adresse> ListesAdresses { get; set;}
    }
}