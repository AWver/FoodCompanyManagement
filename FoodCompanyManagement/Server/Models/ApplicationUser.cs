using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FoodCompanyManagement.Server.Models;

namespace FoodCompanyManagement.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public virtual List<Topic> Topics { get; set; }
		public bool MembershipStatus { get; set; }
		public int UserDiet_Id { get; set; }
		public virtual User_DietPlan User_DietPlan { get; set; }
		public int Profile_Id { get; set; }
		public virtual ProfileData ProfileData { get; set; }
		public bool isStaff { get; set; }
	}
}
