using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCompanyManagement.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCompanyManagement.Server.Configurations.Entities
{
	public class TopicSeedConfiguration : IEntityTypeConfiguration<Topic>
	{
		public void Configure(EntityTypeBuilder<Topic> builder)
		{
			builder.HasData(
			new Topic
			{
				Id = 1,
				IsMembership = true,
				TopicDesc = "Does Whey Protein have any side effects on health?",
				TopicName = "Whey Protein",
				User_Id = 1
			}
			);
		}
	}
}