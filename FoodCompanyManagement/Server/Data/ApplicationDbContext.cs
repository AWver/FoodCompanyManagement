using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FoodCompanyManagement.Server.Models;
using FoodCompanyManagement.Server.Configurations.Entities;

namespace FoodCompanyManagement.Server.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}
		public DbSet<DailyMeal> DailyMeals { get; set; }
		public DbSet<DietPlan> DietPlans { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<ProfileData> ProfileDatas { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<User_DietPlan> User_DietPlans { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new DietPlanSeedConfiguration());
		}
	}
}
