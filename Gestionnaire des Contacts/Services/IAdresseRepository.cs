using GestionnaireContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionnaireContacts.Services
{
    public interface IAdresseRepository
    {
        IList<Adresse> GetAdresses(uint idUtilisateur);
        Adresse AddAdresse(Adresse adresse);
        void SetAdresse(Adresse adresse);
        void RemoveAdresse(uint id);
    }
}