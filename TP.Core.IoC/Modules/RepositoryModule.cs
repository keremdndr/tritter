using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TP.Data;
using TP.Data.Contracts;
using TP.Data.DataRepositories;

namespace TP.Core.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var service = Assembly.GetAssembly(typeof(GenericRepository<,>));

            builder.RegisterAssemblyTypes(service)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterType<TPContext>();
        }
    }


    public class ConfigModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
          

            IConfiguration configuration = new ConfigurationBuilder()
                //.SetBasePath(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))
                
             .AddJsonFile("appsettings.json", optional: true)
            .Build();
            
            builder.RegisterInstance(configuration);


            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            builder.RegisterInstance(httpContextAccessor);
        }
    }












}