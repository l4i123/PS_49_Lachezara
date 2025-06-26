Проекта е разработен повреме на учебни занятия по дизциплина „Програмни среди“. Целта на програмата е разработване на учебна информационна система  за управление на потребители.За създаването и са използвани C#, MVVM, LINQ, Loggers,.NET, EntityFramework, , WPF
•	Модули и компоненти на проекта

o	1. Welcome (конзолно приложение)
- MVVM архитектура с класовете: User, UserViewModel, UserView
- Използва enums и namespaces
- Демонстрира визуализация на потребителски данни в конзола

o	2. WelcomeExtended
- Разширение с делегати, логъри, интерфейси (ILogger)
- Използване на ConcurrentDictionary за log съобщения
- try-catch блокове и обработка на изключения

o	3. DataLayer
- Свързване с SQLite чрез Entity Framework Core
- Създава база на Desktop-а
- Съдържа: DatabaseUser, DatabaseContext, Log
- Реализира CRUD операции и начални данни

o	4. UI (WPF приложение)
- Интерфейс със StudentList и MainWindow
- Визуализира потребителите чрез DataGrid
- Използва PasswordHiderConverter за скрити пароли
- Добавени бутони за изчисления (възраст, брой потребители и др.)

Технология / Концепция	Описание
Entity Framework Core	ORM за достъп до база
SQLite	Лека файлова база Welcome.db
Code First	Миграции чрез OnModelCreating, без ръчни SQL скриптове
LINQ	Извличане и филтриране на данни
Автоматично генерирани ID	ValueGeneratedOnAdd() и DatabaseGeneratedOption.Identity
Seed данни	Начално зареждане на потребители

WPF / XAML (UI)
Елемент	Описание
WPF + XAML	Графичен интерфейс с DataGrid и бутони
UserControl	StudentList.xaml за многократна употреба
Data Binding	Binding="{Binding Property}" в DataGrid
Converters	PasswordHiderConverter за скриване на пароли
Event handling (Click)	Бутони за изчисления като средна възраст
MVVM основа	UI слой започва да следва MVVM философията

NuGet пакети	Microsoft.EntityFrameworkCore.Sqlite
ConcurrentDictionary	(в WelcomeExtended) безопасни логове
Форматиране на време	DateTime.Now.AddDays(...)
Файлова система	Environment.GetFolderPath(...) за път към Welcome.db
Логика за сигурност	Скриване на пароли, криптиране/декриптиране
Command line меню	В Program.cs на DataLayer за CRUD чрез Console.ReadLine()

Концепции на ООП, енумерации, делегати и др.


Връзка към Курсов Проект: https://tusofiabg-my.sharepoint.com/:w:/g/personal/llazarova_tu-sofia_bg/EQ6Q-HMRvctDhAr-ey1DrWoBUmH3eK4qL5H4K7MZqIx9lA?e=oPb3vH
