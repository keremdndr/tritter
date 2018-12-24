using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TP.Core.IoC.Interceptors;

namespace TP.Core.IoC.Modules
{
    public class InterceptorModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(i => new BusinessInterceptor());
        }
    }
}
