using System.Web;
using System.Web.Mvc;

namespace Lab2_Ed1_ABB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
