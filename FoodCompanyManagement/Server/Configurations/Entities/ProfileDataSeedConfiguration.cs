using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCompanyManagement.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCompanyManagement.Server.Configurations.Entities
{
	public class ProfileDataSeedConfiguration : IEntityTypeConfiguration<ProfileData>
	{
		public void Configure(EntityTypeBuilder<ProfileData> builder)
		{
			builder.HasData(
			new ProfileData
			{
				Id = 1,
				Gender = "Male",
				DietRestriction = "Muslim",
				Weight = 65.0f
			}
			);
		}
	}
}