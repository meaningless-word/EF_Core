using System.Collections.Generic;

namespace Migration_test
{
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string Type { get; set; }

		// Навигационное свойство
		public List<User> Users { get; set; } = new List<User>(); // много пользователей в одной компании
	}
}
