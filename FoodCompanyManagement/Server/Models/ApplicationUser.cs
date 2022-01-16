using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FoodCompanyManagement.Shared.Domain;

namespace FoodCompanyManagement.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public virtual List<Topic> Topics { get; set; }
	}
}
