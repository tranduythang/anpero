using System.Web;
using System.Web.Mvc;

namespace _12_Theme_Multi_Product_Option_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
