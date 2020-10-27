using System.Web;
using System.Web.Mvc;

namespace Servicios_Web_1_Semana08
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
