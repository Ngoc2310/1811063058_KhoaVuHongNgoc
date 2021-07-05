using System.Web;
using System.Web.Mvc;

namespace _1811063058_KhoaVuHongNgoc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
