using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Shared.Domain
{
	public class DietPlan : BaseDomainModel
	{
		[Required]
		public string DietCategory { get; set; }
		public int DietWeek { get; set; }
		[Required]
		public string DietReccFoods { get; set; }

	}
}
