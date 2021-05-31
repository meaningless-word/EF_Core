﻿namespace EF_Core
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }

		/// <summary>
		/// Внешний ключ
		/// </summary>
		public int CompanyId { get; set; }
		/// <summary>
		/// Навигационное свойство
		/// </summary>
		public Company Company { get; set; }
	}
}
