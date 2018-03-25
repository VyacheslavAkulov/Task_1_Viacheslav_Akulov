using System.Web.Mvc;
using Task_1_Viacheslav_Akulov.Filters;

namespace Task_1_Viacheslav_Akulov
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionFilter());
            filters.Add(new ExceptionFilter());
        }
    }
}