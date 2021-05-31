using Microsoft.EntityFrameworkCore;

namespace Many_To_Many
{
	public class AppContext : DbContext
	{
		// Объекты таблицы Users
		public DbSet<User> Users { get; set; }

		// Объекты таблицы Topics
		public DbSet<Topic> Topics { get; set; }

		public AppContext()
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(local);Database=EF;Trusted_Connection=True;");
		}
	}
}
