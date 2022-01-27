using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCompanyManagement.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCompanyManagement.Server.Configurations.Entities
{
	public class PostSeedConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasData(
			new Post
			{
				Id = 1,
				Poster = "Amir_Weaver",
				PostDesc = "Not entirely certain whether Whey Protein will have any detrimental side effects. I am taking it after every gym session, will there be any issues?",
				User_Id = 1,
				Topic_Id = 1
			}
			);
		}
	}
}