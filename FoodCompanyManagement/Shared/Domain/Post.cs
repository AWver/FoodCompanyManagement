using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Shared.Domain
{
	public class Post : BaseDomainModel
	{
		public string PostDesc { get; set; }

		public DateTime PostDate { get; set; }
		public string Topic_Name { get; set; }
		public virtual Topic Topic { get; set; }
	}
}
