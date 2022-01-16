using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Server.Models
{
	public class Topic : BaseDomainModel
	{
		public bool IsMembership { get; set; }
		public string TopicDesc { get; set; }
		public string TopicName { get; set; }
		public int User_Id { get; set; }
		public virtual User User { get; set; }

		public virtual ApplicationUser appUser { get; set; }
	}
}
