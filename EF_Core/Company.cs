using System.Collections.Generic;

namespace EF_Core
{
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<User> Users { get; set; }
	}
}
