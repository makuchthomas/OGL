using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OGL.Infrastructure.EF;
using OGL.Infrastructure.IoC;
using OGL.Infrastructure.Services;
using OGL.Infrastructure.Settings;

namespace OGL.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //public void ConfigureServices(IServiceCollection services)
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
            services.AddMemoryCache();

            services.AddEntityFrameworkSqlServer()
                    .AddEntityFrameworkInMemoryDatabase()
                    .AddDbContext<OglContext>();
            //Auth

            var jwtSection = Configuration.GetSection("jwt");
            services.Configure<JwtSettings>(jwtSection);
            var jwtSettings = new JwtSettings();
            jwtSection.Bind(jwtSettings);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(c =>
                {
                    c.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = false
                    };
                });

            // create a Autofac container builder
            var builder = new ContainerBuilder();
            // read service collection to Autofac
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            //builder.RegisterModule<CommandModule>();
            //builder.RegisterModule(new SettingsModule(Configuration));
            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseAuthentication();
            app.UseMvc();

            var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
            if (generalSettings.SeedData)
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.SeedData();
            }


            lifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}

