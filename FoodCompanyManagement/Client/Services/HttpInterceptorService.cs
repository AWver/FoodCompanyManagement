using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor;

namespace FoodCompanyManagement.Client.Services
{
	public class HttpInterceptorService
	{
		private readonly HttpClientInterceptor interceptor;
		private readonly NavigationManager navManager;

		public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
		{
			this.interceptor = interceptor;
			this.navManager = navManager;
		}
		public void MonitorEvent() => interceptor.AfterSend += InterceptResponse;

		private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
