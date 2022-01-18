using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCompanyManagement.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCompanyManagement.Server.Configurations.Entities
{
	public class DietPlanSeedConfiguration : IEntityTypeConfiguration<DietPlan>
	{
		public void Configure(EntityTypeBuilder<DietPlan> builder)
		{
			builder.HasData(
			new DietPlan
			{
				Id = 1,
				DietCategory = "Pescatarian",
				DietWeek = 1,
				DietReccFoods = "Salmon, Sea bass"
			}
			);
		}
	}
}
