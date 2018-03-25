using BLL.Infrastructure;
using System.Web.Mvc;

namespace Task_1_Viacheslav_Akulov.Filters
{
    /// <summary>
    /// Log application exceptions
    /// </summary>
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception != null)
            {
                Logger.Log.Error($"Exception:{filterContext.Exception.Message}. Place:{filterContext.Controller.GetType().Name}. Status code:{filterContext.HttpContext.Response.StatusCode}");
                filterContext.ExceptionHandled = true;
            }         
        }
    }
}