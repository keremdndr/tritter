using Autofac;
using System.Reflection;
using TP.Business;
using TP.Business.Contracts;

namespace TP.Core.IoC.Modules
{
    public class BusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var service = Assembly.GetAssembly(typeof(BusinessEngineBase));

            builder.RegisterAssemblyTypes(service)
                .Where(t => t.Name.EndsWith("Engine"))
                .AsImplementedInterfaces();
        }
    }
}