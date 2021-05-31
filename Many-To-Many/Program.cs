﻿namespace Many_To_Many
{
	class Program
	{
		static void Main(string[] args)
		{
			// Отношение «многие ко многим»
			/*
			 * Для того чтобы изучить данное отношение, мы будем рассматривать схему пользователей на форуме с различными разделами. 
			 * В схеме будут сущность User — пользователь, и сущность Topic — раздел. 
			 * Поскольку каждый пользователь может следить за несколькими разделами, а к каждому разделу может относиться более одного пользователя, 
			 * данная связь реализуется через отношение многие ко многим.
			 */

			/*
			 * При реализации такого отношения создается дополнительная таблица, которая содержит в себе записи, отражающие принадлежность пользователя к разделу. 
			 * Именно в этой таблице будут установлены внешние ключи.
			 */

			/*
			 * EF (EF Core) с версии 5.0 позволяет не заботиться о создании связующей таблицы, а разрешает это сам. 
			 * Таким образом, нам не нужно создавать класс TopicUser, чтобы реализовать связь многие ко многим. 
			 * Если вам интересно, как это работало в более ранних версиях, вы можете прочитать об этом здесь. https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
			 */

			/*
			 * Поскольку объявленные в классах навигационные свойства позволяют переходить сразу от разделов к пользователям, 
			 * нам не потребуется доступ к связующей таблице для работы с объектами. 
			 * В логике работы с объектами у нас есть раздел и пользователь: мы можем добавить пользователя в раздел и наоборот.
			 */

			using (var db = new AppContext())
			{
				var topic1 = new Topic() { Name = "Раздел 1" };
				var topic2 = new Topic() { Name = "Раздел 2" };
				var topic3 = new Topic() { Name = "Раздел 3" };

				var user1 = new User() { Name = "Пользователь 1", Email = "a1@a.a" };
				var user2 = new User() { Name = "Пользователь 2", Email = "a2@a.a" };
				var user3 = new User() { Name = "Пользователь 3", Email = "a3@a.a" };
				var user4 = new User() { Name = "Пользователь 4", Email = "a4@a.a" };

				topic1.Users.AddRange(new[] { user3, user4 });
				topic2.Users.AddRange(new[] { user1, user2 });

				user1.Topics.AddRange(new[] { topic1, topic3 });

				db.Topics.AddRange(topic1, topic2, topic3);
				db.Users.AddRange(user1, user2, user3, user4);

				db.SaveChanges();
			}
		}
	}
}