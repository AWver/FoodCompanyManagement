using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCompanyManagement.Server.Configurations.Entities
{
	public class DietPlanSeedConfiguration : IEntityTypeConfiguration<DietPlan>
	{
		public void Configure(EntityTypeBuilder<DietPlan> builder)
		{
			throw new NotImplementedException();
		}
	}
}
