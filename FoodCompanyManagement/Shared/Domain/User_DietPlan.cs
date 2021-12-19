using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Shared.Domain
{
	public class User_DietPlan : BaseDomainModel
	{
		public DateTime DietStart { get; set; }
		public DateTime DietEnd { get; set; }
		public int DietID { get; set; }
		public virtual DietPlan DietPlan { get; set; }


	}
}
