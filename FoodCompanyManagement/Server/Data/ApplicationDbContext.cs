using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FoodCompanyManagement.Server.Models;
using FoodCompanyManagement.Shared.Domain;
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
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new DietPlanSeedConfiguration());
			builder.ApplyConfiguration(new DailyMealSeedConfiguration());
			builder.ApplyConfiguration(new PostSeedConfiguration());
			builder.ApplyConfiguration(new ProfileDataSeedConfiguration());
			builder.ApplyConfiguration(new UserRoleSeedConfiguration());
			builder.ApplyConfiguration(new UserSeedConfiguration());
			builder.ApplyConfiguration(new User_DietPlanSeedConfiguration());
			builder.ApplyConfiguration(new RoleSeedConfiguration());
			builder.ApplyConfiguration(new TopicSeedConfiguration());
		}
	}
}
