using Microsoft.AspNetCore.Identity;

namespace _19_NguyenPhanDiemHien.Models
{
	public class AppUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
