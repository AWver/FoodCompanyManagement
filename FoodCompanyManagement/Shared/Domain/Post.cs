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
		public string Poster { get; set; }

		public string PostTitle { get; set; }
		public string PostDesc { get; set; }
		public DateTime PostDate { get; set; }
		public int Topic_Id { get; set; }
		public virtual Topic Topic { get; set; }
	}
}
