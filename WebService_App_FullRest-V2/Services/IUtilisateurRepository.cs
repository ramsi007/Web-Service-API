using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebService_App_FullRestVersion2.Models
{
    public interface IUtilisateurRepository
    {
        IList<Utilisateur> GetAllUtilisateur();
        Utilisateur GetUtilisateur(ulong id);
        Utilisateur AddUtilisateur(Utilisateur utilisateur);
        bool UpdateUtilisateur(Utilisateur utilisateur);
        bool RemoveUtilisateur(ulong id);
    }
}
