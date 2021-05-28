using System;

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
			}
		}
	}
}
