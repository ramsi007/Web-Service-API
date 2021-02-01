using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_AspNetWebApiRest.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Nss { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }

    }
}