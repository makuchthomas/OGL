using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.Extensions.Configuration;
using OGL.Infrastructure.Extensions;
using System.Linq;
using OGL.Infrastructure.Settings;
using OGL.Infrastructure.EF;

namespace OGL.Infrastructure.IoC.Modules
{
    public class SettingsModule :  Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>()).SingleInstance();
        }
    }
}
