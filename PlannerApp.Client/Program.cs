using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlannerApp.Shared.Services;

namespace PlannerApp.Client
{
    public class Program
    {

        private const string URL = "https://plannerappserver20200228091432.azurewebsites.net/";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<AuthenticationService>(s =>
            {
                return new AuthenticationService(URL);
            });

            await builder.Build().RunAsync();
        }
    }
}
