using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService_App_FullRestVersion2.Models
{
    public class Adresse
    {
        public ulong Id { get; set; }
        public uint Numero { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public ulong UtilisateurId { get; set; }
    }
}