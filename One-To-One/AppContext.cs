using Microsoft.EntityFrameworkCore;

namespace One_To_One
{
	public class AppContext: DbContext
	{
		// Объекты таблицы User
		public DbSet<User> Users { get; set; }

		// Объекты таблицы UserCredentials
		public DbSet<UserCredential> UserCredentials { get; set; }

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
