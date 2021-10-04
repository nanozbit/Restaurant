using Blazored.Modal;
using Blazored.SessionStorage;
using FrontendRestaurant.Services;
using FrontendRestaurant.Services.Interface;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontendRestaurant
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44358/") });
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddBlazoredModal();
            await builder.Build().RunAsync();
        }
    }
}
