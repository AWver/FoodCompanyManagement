using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FoodCompanyManagement.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace FoodCompanyManagement.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddHttpClient("FoodCompanyManagement.ServerAPI", (sp,client) => {
				client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
			client.EnableIntercept(sp);
			})
				.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();


			builder.Services.AddHttpClientInterceptor();
			builder.Services.AddScoped<HttpInterceptorService>();
			// Supply HttpClient instances that include access tokens when making requests to the server project
			builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FoodCompanyManagement.ServerAPI"));

			builder.Services.AddApiAuthorization();

			await builder.Build().RunAsync();
		}
	}
}
