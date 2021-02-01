using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService_App_FullRestVersion2.Models;

namespace WebService_App_FullRestVersion2.Services
{
    interface IAdresseRepository
    {
        IList<Adresse> GetAllAdresse();
        IList<Adresse> GetAdresse(ulong id);
        Adresse AddAdresse(Adresse adresse);
        bool  UpdateAdresse(Adresse adresse);
        bool RemoveAdresse(ulong id);
    }
}
