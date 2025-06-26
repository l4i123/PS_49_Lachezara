using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Welcome.Model;
namespace WelcomeExtended.Helpers

{
    public static class UserHelper
    {
        public static string ToUserString(this User user)
        {
            if ((user == null))
            {
                return "string is empty";
            }
            else
            {
                return $"Name: {user.Name}, Password: {user.Password}, Role: {user.Role}, Email: {user.Email}, FacultyNumber: {user.FacultyNumber}, Id: {user.Id}, Expires: {user.Expires}";
            }
        }
        public static void ValidateCredentials(User user, string name, string password, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                logger.LogError("Login failed at {time}: The '{field}' cannot be empty", DateTime.Now, nameof(name));
                throw new ArgumentException($"The '{nameof(name)}' cannot be empty");
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                logger.LogError("Login failed at {time}: The '{field}' cannot be empty", DateTime.Now, nameof(password));
                throw new ArgumentException($"The '{nameof(password)}' cannot be empty");
            }
            else if (user == null)
            {
                logger.LogError("Login failed at {time}: User not found", DateTime.Now);
                throw new ArgumentException("User not found");
            }
            else if (user.Name != name || user.Password != password)
            {
                logger.LogError("Login failed at {time}: Invalid credentials for user '{name}'", DateTime.Now, name);
                throw new ArgumentException("Invalid username or password");
            }
            else
            {
                logger.LogInformation("User '{name}' successfully logged in at {time}", name, DateTime.Now);
            }
        }

        public static string GetUser(this User user, string name, string password)
        {
            return user.GetUser(name, password);
        }

    }
}
