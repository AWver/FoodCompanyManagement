using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Shared.Domain
{
	public class DietPlan : BaseDomainModel
	{
		public string DietCategory { get; set; }
		public int DietWeek { get; set; }
		public string DietReccFoods { get; set; }

	}
}
