using Autofac;
using DAL.Interfases;
using DAL.Repository;
using Module = System.Reflection.Module;

namespace BLL.DIModule
{
    /// <summary>
    /// Autofac service module
    /// </summary>
    public class ServiceModule : Autofac.Module
    {
        private readonly string connection;


        public ServiceModule(string connection)
        {
            this.connection = connection;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("connection", this.connection);
        }
    }
}