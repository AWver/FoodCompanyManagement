using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Shared.Domain
{
	public class DailyMeal : BaseDomainModel
	{
		[Required]
		public string MealDescription { get; set; }
		[Required]
		public string MealPhoto { get; set; }
		public DateTime MealDate { get; set; }
		public int UserDiet_Id { get; set; }
		public virtual User_DietPlan User_DietPlan { get; set; }


	}
}
