using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using BLL.Infrastructure;

namespace Task_1_Viacheslav_Akulov.Filters
{
    /// <summary>
    /// Log user activity
    /// </summary>
    public class ActionFilter : FilterAttribute, IActionFilter
    {
        private Stopwatch timer;

        public ActionFilter()
        {
            timer = new Stopwatch();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger.Log.Info($"User {filterContext.HttpContext.User.Identity.Name} ({filterContext.HttpContext.Request.UserHostAddress}) go to {filterContext.HttpContext.Request.Url}");

            timer.Start();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();

            Logger.Log.Info($"Request for user {filterContext.HttpContext.User.Identity.Name} ({filterContext.HttpContext.Request.UserHostAddress}) completed. Request time {timer.ElapsedMilliseconds}mls. ");
        }
    }
}