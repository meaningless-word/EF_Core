using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core
{
	public class AppContext: DbContext
	{
		/// <summary>
		/// Объект таблицы Users
		/// </summary>
		public DbSet<User> Users { get; set; }

		public AppContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// параметр - строка подключения
			optionsBuilder.UseSqlServer(@"Data Source=(local);Database=EF;Trusted_Connection=True;");
		}
	}
}
