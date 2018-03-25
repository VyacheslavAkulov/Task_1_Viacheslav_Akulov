using Autofac;
using BLL.Interfaces;
using BLL.Services;

namespace Task_1_Viacheslav_Akulov.DIModule
{
    public class WebModule:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<GameService>().As<IGameService>();

            containerBuilder.RegisterType<CommentService>().As<ICommentService>();
        }
    }
}