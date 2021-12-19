using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Shared.Domain
{
	public class User : BaseDomainModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool isStaff { get; set; }
		public bool MembershipStatus { get; set; }
		public int UserDietID { get; set; }
		public virtual User_DietPlan User_DietPlan { get; set; }
		public int ProfileID { get; set; }
		public virtual ProfileData ProfileData { get; set; }



	}
}
