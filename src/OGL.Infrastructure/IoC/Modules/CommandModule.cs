using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using System.Reflection;
using System.Linq;
using OGL.Infrastructure.Commands;

namespace OGL.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<ICommandHandler>()).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().InstancePerLifetimeScope();
        }
    }
}
