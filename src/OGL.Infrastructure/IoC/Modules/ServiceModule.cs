using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using OGL.Infrastructure.Services;
using System.Linq;

namespace OGL.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IService>()).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Encrypter>().As<IEncrypter>().SingleInstance();
            builder.RegisterType<JwtHandler>().As<IJwtHandler>().SingleInstance();
        }
    }
}
