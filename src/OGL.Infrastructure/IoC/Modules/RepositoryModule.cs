using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using System.Reflection;
using OGL.Core.Repositories;
using System.Linq;

namespace OGL.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IRepository>()).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
