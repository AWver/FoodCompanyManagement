using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Shared.Domain
{
	public class Premium : BaseDomainModel
	{
		public string CardNumber{ get; set; }
		public int CVV { get; set; }
		public string ExpiryDate { get; set; }
	


	}
}
