using System;

namespace Drive.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string? Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Hash { get; set; }
	}
}