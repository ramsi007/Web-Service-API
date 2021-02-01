using GestionnaireContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionnaireContacts.Services
{
    public interface IUtilisateurRepository
    {
        IList<Utilisateur> GetUtilisateurs();
        Utilisateur GetUtilisateur(uint id);
        Utilisateur AddUtilisateur(Utilisateur utilisateur);
        void SetUtilisateur(Utilisateur utilisateur);
        void RemoveUtilisateur(uint id);
    }
}