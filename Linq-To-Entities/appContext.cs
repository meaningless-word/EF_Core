using Microsoft.EntityFrameworkCore;

namespace Linq_To_Entities
{
	public class appContext : DbContext
	{
		// Объекты таблицы Users
		public DbSet<User> Users { get; set; }

		// Объекты таблицы Companies
		public DbSet<Company> Companies { get; set; }

		// А из контекста вынесем пересоздание базы:

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(local);Database=EF;Trusted_Connection=True;");
		}
	}
}
