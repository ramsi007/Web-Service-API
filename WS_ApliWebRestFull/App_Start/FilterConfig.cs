using System.Web;
using System.Web.Mvc;

namespace WS_ApiWebRestFull_bis
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
