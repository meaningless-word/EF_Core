using Microsoft.EntityFrameworkCore;

namespace Migration_test
{
	public class AppContext: DbContext
	{
		// Объекты таблицы Users
		public DbSet<User> Users { get; set; }

		// Объекты таблицы Companies
		public DbSet<Company> Companies { get; set; }

		public AppContext()
		{
			// Database.EnsureDeleted(); // удаление БД при запуске приложения
			Database.EnsureCreated(); // создание таблиц соглачно описанной модели
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(local);Database=EF;Trusted_Connection=True;");
		}

	}
}
