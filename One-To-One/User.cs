namespace One_To_One
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }

		// Навигационное свойство
		public UserCredential UserCredential { get; set; }
	}
}
