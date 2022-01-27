using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCompanyManagement.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCompanyManagement.Server.Configurations.Entities
{
	public class User_DietPlanSeedConfiguration : IEntityTypeConfiguration<User_DietPlan>
	{
		public void Configure(EntityTypeBuilder<User_DietPlan> builder)
		{
			builder.HasData(
			new User_DietPlan
			{
				Id = 1,
				DietStart = DateTime.Today,
				DietEnd = DateTime.Today,
				Diet_Id = 1
			}
			);
		}
	}
}
