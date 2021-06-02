using System.Linq;

namespace EF_Core
{
	class Program
	{
		static void Main(string[] args)
		{
			// После создания контекста приложения можно использовать EF в проекте. 
			// Для этого следует создать объект контекста с помощью конструктора без параметров.
			// Поскольку DbContext реализует интерфейс IDisposable, мы можем использовать конструкцию using. Обернём создание контекста в using:
			using (var db = new AppContext())
			{
				// Поскольку ORM позволяет работать с БД через объекты, то создадим несколько экземпляров созданного нами класса User:
				var user1 = new User { Name = "Arthur", Role = "admin" };
				var user2 = new User { Name = "Klim", Role = "User" };
				// Далее добавим пользователей в таблицу Users, обращаясь к полю Users нашего контекста db, и сохраним изменения (об этом поговорим позже):
				db.Users.Add(user1);
				db.Users.Add(user2);
				db.SaveChanges();

				// Вот ещё один способ добавления данных: AddRange
				var user3 = new User { Name = "Alice", Role = "User" };
				var user4 = new User { Name = "Bob", Role = "User" };
				var user5 = new User { Name = "Bruce", Role = "User" };
				db.Users.AddRange(user3, user4, user5);
				db.SaveChanges();

				// Удаление выглядит так:
				db.Users.Remove(user3);
				db.SaveChanges();

				// Либо так:
				db.Entry(user4).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
				db.SaveChanges();

				// чтобы выбрать, которые не были созданы непосредственно в данной части кода, нужно выбрать их из контекста
				// к примеру, всех пользователей
				var allUsers = db.Users.ToList();
				// или только админов
				var admins = db.Users.Where(user => user.Role == "admin").ToList();


				// изменение
				// выбираем первую попавшуюся запись их таблицы:
				var firstUser = db.Users.FirstOrDefault();
				firstUser.Email = "simpleemail@gmail.com";
				db.SaveChanges();


				/*
				 * Для связей между моделями в Entity Framework Core применяются внешние ключи и навигационные свойства. Добавим к рассмотренной ранее модели пользователя компанию
				 * В данной схеме зависимой сущностью является User, поскольку содержит ссылку на Company. 
				 * Для того чтобы отобразить эту зависимость, в класс User был добавлен внешний ключ CompanyId и навигационное свойство Company, 
				 * по которому можно будет найти компанию пользователя.
				 * Поскольку мы изменили модель классов в системе, нам придется дополнить и контекст приложения
				 */



			}
		}
	}
}
