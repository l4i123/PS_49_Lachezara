using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Microsoft.EntityFrameworkCore;
using DataLayer.Model;
using Welcome.Others;
using System.Security.Cryptography.X509Certificates;

namespace DataLayer.Database
{
    public class DatabaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");

            /*В този метод задаваме път към Sqlite базата данни която ще използваме, а
            на последният ред създаваме конфигурацията на базата данни за работа с
            Sqlite.*/
        }
        public DbSet<DatabaseUser> Users { get; set; }
        /*Тук задаваме как да се генерират стойностите на Id-то на потребителя,
              а именно автоматично при добавяне на нов потребител в базата данни.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            

            var user = new DatabaseUser()
            { 
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddDays(10),
                Email = "john@example.com",
                FacultyNumber = "F123456",
                Age = 52

            };
            
            modelBuilder.Entity<DatabaseUser>().HasData(user);
            /* В този метод се описва какво искаме да направим при инициализация на
             контекста на базата данни, в този случай първо казваме, че полето Id на
             Entity - то DatabaseUser трябва да се генерира автоматично. След това
             създаваме потребител в базата като обект и го добавяме в базата ако не
             съществува.*/

            //по аналог създаваме и друг потребител
            var user2 = new DatabaseUser()
            {
                Id = 2,
                Name = "Jane Smith",
                Password = "5678",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddDays(20),
                Email = "jane@example.com",
                FacultyNumber = "F234567",
                Age = 21

            };
            modelBuilder.Entity<DatabaseUser>().HasData(user2);

            var user3 = new DatabaseUser()
            {
                Id = 3,
                Name = "Maria Popova",
                Password = "123456789",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddDays(15),
                Email = "maria@example.com",
                FacultyNumber = "F345678",
                Age = 59

            };
            modelBuilder.Entity<DatabaseUser>().HasData(user3);

            modelBuilder.Entity<Log>().Property(l => l.Id).ValueGeneratedOnAdd();
        }
        public DbSet<Log> Logs { get; set; }
        public void AddLog(string message)
        {
            Logs.Add(new Log { Message = message, TimeStamp = DateTime.Now });
            SaveChanges();
        }
    }
}
