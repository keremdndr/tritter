using Autofac;
using TP.Core.IoC.Modules;

namespace TP.Core.IoC
{
    public static class AutofacBootstrapper
    {
        private static IContainer _container;

        public static void BuilderContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<BusinessModule>();

            _container = builder.Build();
        }

        public static IContainer GetContainer()
        {
            return _container;
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}