using System;

namespace Welcome
{
    public delegate void ActionOnError(string message);

    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "Maria Popova";
            user.Password = "123456789";
            user.Email = "maria.popova@tu-sofia.bg";
            user.FacultyNumber = "501222031";
            user.Role = UserRolesEnum.STUDENT;

            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);

            userView.DisplayUserInfo();

            var user2 = new User
            {
                Name = "John Smith",
                Password = "987654321",
                Role = UserRolesEnum.STUDENT,
            };
            try
            {
                var viewModel2 = new UserViewModel(user2);
                var view2 = new UserView(viewModel2);
                view2.DisplayUserInfo();

                //Throw error here
                view2.DisplayError();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("End of program.");
            }
        }

        static void Log(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
