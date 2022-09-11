using System.Web;
using System.Web.Mvc;
using Restaurant.Web.CustomFilters;

namespace Restaurant.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomException());
        }
        
    }
}
