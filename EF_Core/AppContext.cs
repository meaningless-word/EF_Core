using Microsoft.EntityFrameworkCore;

namespace EF_Core
{
	public class AppContext: DbContext
	{
		/// <summary>
		/// Объект таблицы Users
		/// </summary>
		public DbSet<User> Users { get; set; }

		public DbSet<Company> Companies { get; set; }

		public AppContext()
		{
			/*
			 * Мы добавили коллекцию Companies для работы с таблицей компаний. 
			 * Поскольку мы изменили модель, мы не сможем просто так соотнести старые таблицы, которые уже были в БД, с новыми моделями. 
			 * Для этого мы добавили строку для удаления БД при запуске приложения — Database.EnsureDeleted(), 
			 * чтобы затем создавать её через использование Database.EnsureCreated().
			 */
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// параметр - строка подключения
			optionsBuilder.UseSqlServer(@"Data Source=(local);Database=EF;Trusted_Connection=True;");
		}
	}
}
