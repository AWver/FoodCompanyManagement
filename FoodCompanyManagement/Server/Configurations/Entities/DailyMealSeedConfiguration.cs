using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCompanyManagement.Server.Models;
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
				MealPhoto = "URL placed here",
				MealDate = DateTime.Today,
				UserDiet_Id = 1
			}
			);
		}
	}
}