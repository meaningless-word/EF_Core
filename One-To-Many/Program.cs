using System;

namespace One_To_Many
{
	class Program
	{
		static void Main(string[] args)
		{
			// Отношение «один ко многим»
			/* 
			 * Самый часто встречающийся пример отношения один ко многим — сотрудник и его должность. 
			 * У одного сотрудника только одна должность. Но эта должность может быть у нескольких сотрудников.
			 */
			// Сейчас же мы разберем другой пример отношения — компания и её сотрудники.
			/* 
			 * Вернёмся к классу компании и снова изменим схему. 
			 * Поскольку в одной компании может быть несколько пользователей, 
			 * но один пользователь может находиться только в одной компании, 
			 * данная схема будет реализовывать отношение один ко многим.
			 */
			using (var db = new AppContext())
			{
				var company1 = new Company { Name = "SF" };
				var company2 = new Company { Name = "VK" };

				var company3 = new Company { Name = "FB" };
				db.Companies.Add(company3);
				db.SaveChanges();

				var user1 = new User { Name = "Arthur", Role = "Admin" };
				var user2 = new User { Name = "Bob", Role = "Admin" };
				var user3 = new User { Name = "Clark", Role = "User" };

				user1.Company = company1; // можно юзеру добавить ссылку на компанию через навигационное свойство
				company2.Users.Add(user2); // можно через навигационное свойство компаний добавить пользователя, что означает добавить ссылку на компанию у пользователя
				user3.CompanyId = company3.Id; // можно указать id компании, но она должна предварительно уже быть добавлена в базу, когда как остальные ситуации работают с объектами в памяти

				db.Companies.AddRange(company1, company2);
				db.Users.AddRange(user1, user2, user3);

				db.SaveChanges();
			}

		}
	}
}
