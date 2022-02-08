using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Client.Static
{
	public static class Endpoints
	{
		private static readonly string Prefix = "api";

		public static readonly string TopicsEndpoint = $"{Prefix}/topics";
		public static readonly string PostsEndpoint = $"{Prefix}/posts";
		public static readonly string DietPlansEndpoint = $"{Prefix}/dietPlans";
		public static readonly string ProfileDatasEndpoint = $"{Prefix}/profileDatas";
		public static readonly string User_DietPlansEndpoint = $"{Prefix}/user_DietPlans";
		public static readonly string DailyMealsEndpoints = $"{Prefix}/dailyMeals";
		public static readonly string AccountsEndpoint = $"{Prefix}/accounts";
		
	}
}

