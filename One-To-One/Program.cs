namespace One_To_One
{
	class Program
	{
		static void Main(string[] args)
		{
			// Отношение «один к одному»
			/*
			 * разберём пример данного отношения — пользователь и его учетные данные.
			 * Для того чтобы рассмотреть данную модель, изменим схему: 
			 * среди наших таблиц оставим пользователя User и отдельно для каждого пользователя заведем данные для авторизации  — UserCredential.
			 */
			using (var db = new AppContext())
			{
				// Для начала создадим пользователей:
				var user1 = new User { Name = "Arthur", Role = "Admin" };
				var user2 = new User { Name = "Bob", Role = "Admin" };
				var user3 = new User { Name = "Clark", Role = "User" };
				var user4 = new User { Name = "Dan", Role = "User" };
				// Добавляем user2 и сохраняем, чтобы получить Id
				db.Users.Add(user2);
				db.SaveChanges();
				db.Users.AddRange(user1, user3, user4);

				// Далее для каждого пользователя мы создадим данные для входа:
				var user1Creds = new UserCredential { Login = "ArthurL", Password = "qwerty123" };
				var user2Creds = new UserCredential { Login = "BobJ", Password = "asdfgh585" };
				var user3Creds = new UserCredential { Login = "ClarkK", Password = "111zlt777" };
				var user4Creds = new UserCredential { Login = "DanE", Password = "zxc333vbn" };
				// Связать объекты сущностей User и UserCredential можно несколькими способами: 
				user1Creds.User = user1; // Через свойство User в объекте класса UserCredential 
				user2Creds.UserId = user2.Id; // Через передачу Id пользователя в свойство UserId. Данный способ будет работать, только если у вас есть Id пользователя, и он уже был записан в БД
				user3.UserCredential = user3Creds; // Через свойство UserCredential в объекте класса User
				user4.UserCredential = user4Creds;

				// Для того чтобы данные оказались в таблице, нам потребуется добавить их в соответствующие коллекции контекста и сохранить изменения.
				// Но важно понимать, что настроенная связь внешнего ключа накладывает на нас ограничения — можно создать пользователя без данных для входа, но наоборот — нет.

				// Не добавляем user1Creds в БД
				db.UserCredentials.AddRange(user2Creds, user3Creds, user4Creds);

				db.SaveChanges();
			}

		}
	}
}
