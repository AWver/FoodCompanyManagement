using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Server.Models
{
	public class ProfileData : BaseDomainModel
	{
		public string Gender { get; set; }
		public string DietRestriction { get; set; }
		public float Weight { get; set; }

	}
}
