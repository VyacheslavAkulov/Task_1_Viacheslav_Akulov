using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BLL.DIModule;
using Task_1_Viacheslav_Akulov.DIModule;

namespace Task_1_Viacheslav_Akulov.Autofac
{

    public class AutofacConfig
    {
        /// <summary>
        /// Autofac config
        /// </summary>
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new ServiceModule("GameStoreConnection"));
            builder.RegisterModule(new WebModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}