using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCompanyManagement.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCompanyManagement.Server.Configurations.Entities
{
	public class DailyMealSeedConfiguration : IEntityTypeConfiguration<DailyMeal>
	{
		public void Configure(EntityTypeBuilder<DailyMeal> builder)
		{
			builder.HasData(
			new DailyMeal
			{
				Id = 1,
				MealDescription = "Pan-seared Salmon",
				MealPhoto = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.mos.cms.futurecdn.net%2FrqoDpnCCrdpGFHM6qky3rS-1200-80.jpg&f=1&nofb=1",
				MealDate = DateTime.Today,
				UserDiet_Id = 1
			}
			);
		}
	}
}