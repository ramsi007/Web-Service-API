using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace WebServiceApi_Web.Entities
{
    public class Client
    {
        public uint Id { get; set; } 
        public string Nom { get; set; } 
        public string Prenom { get; set; } 
        public string Adresse { get; set; } 
        public ulong NumSec { get; set; }

    }
}