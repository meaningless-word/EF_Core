﻿using System;

namespace Migration_test
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Для начала стоит установить пакет Microsoft.EntityFrameworkCore.Tools в проект:
			 * 
			 * Затем вам необходимо открыть окно «Консоль диспетчера пакетов» (или Package Manager Console):
			 * Вид\Другие окна\Консоль диспетчера пакетов
			 * 
			 * Первое, что вам понадобится — создать начальную миграцию. 
			 * Она будет включать в себя процесс создания БД с нуля. Для схемы БД мы взяли используемую выше схему с пользователем и компанией.
			 *
			 * Далее введите в консоли команду «Add-Migration Initial», которая создаст миграцию Initial:
			 * 
			 * В проекте появился ряд новых файлов в папке «Migrations»:
			 * %Дата%_Initial.cs — основной файл миграции, который содержит все применяемые действия;
			 * %Дата%_Initial.Designer.cs — метаданные файла миграции, используемые EF-ом;
			 * %Имя контекста%ModelSnapshot.cs — метаданные текущего состояния схемы, которые будут использованы для следующей миграции.
			 * 
			 * Для нас интересен сам файл миграции, который содержит в себе методы Up и Down для применения миграции и её отката:
			 * 
			 * Поскольку данная миграция является первичной, она была создана таким образом, чтобы создать базу данных с нуля. 
			 * И если мы попробуем применить данную миграцию с помощью команды Update-Database на уже существующую БД с данными, получим ошибку:
			 * 
			 * Таким образом, начинать работу с миграциями нужно с начала жизни проекта. 
			 * Если же у вас уже есть какая-то база и данные в ней, то данную проблему можно решить 2 способами:
			 * 1. Удалить все таблицы БД и применить миграцию. При этом все данные будут потеряны
			 * 2. Убрать первую миграцию из папки, оставив файл  ***ModelSnapshot. Затем при изменении модели создать новую миграцию и применить её.
			 * 
			 * Поскольку в нашей БД уже есть данные, воспользуемся вторым способом. 
			 * Для этого мы перенесём файлы «20210215182607_Initial.cs» и «20210215182607_Initial.Designer.cs» за пределы проекта, чтобы сохранить их.
			 * 
			 * Далее изменим класс Company, добавив город:
			 * 
			 * После этого добавим миграцию:
			 * В ней отображается только изменение, связанное с полем City:
			 * Применим ее командой Update-Database и проверим БД:
			 * 
			 * В таблицах появилась специальная таблица «__EFMigrationsHistory», которая хранит Id последней миграции. А также появился столбец City для таблицы «Companies».
			 * 
			 * Добавим ещё одну миграцию, чтобы показать механизм удаления миграций. 
			 * Для этого добавим в компанию поле Type с типом данных string.
			 * 
			 * Например, откатим изменения с типом компании:
			 * Для того чтобы откатить изменения, внесенные последней миграцией, следует использовать команду «Remove-Migration». После этого данную миграцию можно будет удалить.
			 * 
			 * мне помогло только Remove-Migration -Force, без неё выыводилось сообщение об ошибке
			 * The migration '20210601104951_add_type' has already been applied to the database. Revert it and try again. If the migration has been applied to other databases, consider reverting its changes using a new migration instead.
			 * 
			 * 
			 */
		}
	}
}
