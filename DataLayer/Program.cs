using DataLayer.Model;
using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.Others;
namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Database.DatabaseContext())
            {
                context.Database.EnsureCreated();

                bool running = true;
                while (running)
                {
                    Console.WriteLine("\nМеню:");
                    Console.WriteLine("1. Изведи всички потребители");
                    Console.WriteLine("2. Добави нов потребител");
                    Console.WriteLine("3. Изтрий потребител");
                    Console.WriteLine("4. Изход");
                    Console.Write("Избор: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            var users = context.Users.ToList();
                            Console.WriteLine("\n--- Потребители ---");
                            foreach (var user in users)
                            {
                                Console.WriteLine($"{user.Id}: {user.Name} | Роля: {user.Role}");
                            }
                            context.AddLog("Извлечени са всички потребители.");
                            break;

                        case "2":
                            Console.Write("Въведи име: ");
                            string name = Console.ReadLine();
                            Console.Write("Въведи парола: ");
                            string password = Console.ReadLine();

                            Console.Write("Въведи имейл: ");
                            string email = Console.ReadLine();

                            Console.Write("Въведи факултетен номер: ");
                            string facultyNumber = Console.ReadLine();

                            context.Users.Add(new DatabaseUser
                            {
                                Name = name,
                                Password = password,
                                Role = UserRolesEnum.STUDENT,
                                Expires = DateTime.Now.AddDays(30),
                                Email = email,
                                FacultyNumber = facultyNumber
                            });
                            context.SaveChanges();
                            context.AddLog($"Добавен е нов потребител: {name}");
                            Console.WriteLine("Потребителят е добавен.");
                            break;

                        case "3":
                            Console.Write("Въведи име на потребител за изтриване: ");
                            string nameToDelete = Console.ReadLine();

                            var userToDelete = context.Users.FirstOrDefault(u => u.Name == nameToDelete);
                            if (userToDelete != null)
                            {
                                context.Users.Remove(userToDelete);
                                context.SaveChanges();
                                context.AddLog($"Изтрит е потребител: {nameToDelete}");
                                Console.WriteLine("Потребителят е изтрит.");
                            }
                            else
                            {
                                Console.WriteLine("Потребителят не е намерен.");
                            }
                            break;

                        case "4":
                            running = false;
                            context.AddLog("Програмата е затворена.");
                            break;

                        default:
                            Console.WriteLine("Невалиден избор.");
                            break;
                    }
                }
            }
        }
    }
}
