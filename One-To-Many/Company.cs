using System.Collections.Generic;

namespace One_To_Many
{
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }

		// Навигационное свойство
		public List<User> Users { get; set; } = new List<User>(); // много пользователей в одной компании
	}
}
