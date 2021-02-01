using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionnaireContacts.Models
{
    public class Adresse
    {
        public uint Id { get; set; }
        public uint Numero { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
    }
}