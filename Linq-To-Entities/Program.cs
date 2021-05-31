using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Linq_To_Entities
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаем контекст для добавления данных
			using (var db = new appContext())
			{
				// Пересоздаем базу
				db.Database.EnsureDeleted();
				db.Database.EnsureCreated();

				// Заполняем данными
				var company1 = new Company { Name = "SF" };
				var company2 = new Company { Name = "VK" };
				var company3 = new Company { Name = "FB" };
				db.Companies.AddRange(company1, company2, company3);

				var user1 = new User { Name = "Arthur", Role = "Admin", Company = company1 };
				var user2 = new User { Name = "Bob", Role = "Admin", Company = company2 };
				var user3 = new User { Name = "Clark", Role = "User", Company = company2 };
				var user4 = new User { Name = "Dan", Role = "User", Company = company3 };

				db.Users.AddRange(user1, user2, user3, user4);

				db.SaveChanges();
			}


			// Создаем контекст для выбора данных
			using (var db = new appContext())
			{
				var usersQuery =
					from user in db.Users
					where user.CompanyId == 2
					select user;

				// Данное выражение может быть записано также с помощью методов-расширений LINQ:
				var usersQuery1 = db.Users.Where(u => u.CompanyId == 2);

				// Использование LINQ-методов может сократить код в некоторых случаях. 
				// Важно, что при таких запросах мы получаем данные только из таблицы пользователей, а значит, свойство Company для полученных пользователей будет равно null. 
				// Для того чтобы включить данные и по компании в запрос, следует уточнить таблицу с помощью Include:
				var usersQuery2 =
					from user in db.Users.Include(u => u.Company) 
					where user.CompanyId == 2 
					select user;

				// Или:
				var usersQuery3 = db.Users.Include(u => u.Company).Where(u => u.CompanyId == 2);
				// Также важно понимать, что поскольку мы выбираем данные по связанным компаниям, мы можем преобразовать запрос:
				var usersQuery4 = db.Users.Include(u => u.Company).Where(u => u.Company.Id == 2);
				// Или:
				var usersQuery5 = db.Users.Include(u => u.Company).Where(u => u.Company.Name == "VK");


				var users = usersQuery5.ToList();
				foreach (var user in users)
				{
					// Вывод Id пользователей
					Console.WriteLine("{0} : {1} ({2})", user.Name, user.Company.Name, user.CompanyId);
				}

				var userCompany = db.Users.Select(v => v.Company);

				var firstUser = db.Users.First();

				// join требует 4 параметра 1: таблицу, с которой джоиним, 2: свойство, по которому джоиним, 3: свойство таблицы, к которой джоиним, 4: формируемый результат
				var joinedCompanies = db.Users.Join(db.Companies, c => c.CompanyId, p => p.Id, (p, c) => new { CompanyName = c.Name, UserName = p.Name });

				var jc = joinedCompanies.ToList();
				foreach (var c in jc)
				{
					Console.WriteLine("{0} : {1}", c.CompanyName, c.UserName);
				}

				var sumCompanies = db.Users.Sum(v => v.CompanyId);


			}
		}
	}
}
