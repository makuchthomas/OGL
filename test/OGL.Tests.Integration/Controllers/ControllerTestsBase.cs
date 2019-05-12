using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OGL.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace OGL.Tests.Integration.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        public ControllerTestsBase()
        {

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetFullPath(@"../../.."))
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration));
            Client = Server.CreateClient();

        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
