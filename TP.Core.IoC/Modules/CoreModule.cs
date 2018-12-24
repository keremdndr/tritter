using Autofac;
using AutoMapper;

using TP.Core.Contracts;
using TP.Core.Mapper;

namespace TP.Core.IoC.Modules
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigurationHelper>().As<IConfigurationHelper>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());

            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}