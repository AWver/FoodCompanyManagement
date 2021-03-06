//ClientApplicationUser.cs
using System.Text.Json.Serialization;
namespace FoodCompanyManagement.Server.Models
{
	public class ClientApplicationUser
	{
		public ClientApplicationUser(ApplicationUser AppUser)
		{
			this.Id = AppUser.Id;
			this.FirstName = AppUser.FirstName;
			this.LastName = AppUser.LastName;
			this.PhoneNumber = AppUser.PhoneNumber;
			this.NormalizedEmail = AppUser.NormalizedEmail;
			this.Email = AppUser.Email;
			this.NormalizedUserName = AppUser.NormalizedUserName;
			this.UserName = AppUser.UserName;
			this.Profile_Id = AppUser.Profile_Id;
			this.isStaff = AppUser.isStaff;
			this.UserDiet_Id = AppUser.UserDiet_Id;
		}
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string NormalizedEmail { get; set; }
		public string Email { get; set; }
		public string NormalizedUserName { get; }
		public string UserName { get; set; }
		public string Id { get; set; }
		public int Profile_Id { get; set; }
		public int UserDiet_Id { get; set; }
		public bool isStaff { get; set; }
	}
}
//End of Code