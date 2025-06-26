using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Others;
using WelcomeExtended.Loggers;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended
{
    public class Program
    {
        static void Main(string[] args)
        {
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

                // Изкуствено генерираме грешка
                view2.DisplayError();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("End of program.");
            }

            var logger = new HashLoggers("MyLogger", "logfile.txt");

            // Логване на съобщения
            logger.Log(LogLevel.Information, new EventId(1), "Information message", null, (state, exception) => state.ToString());
            logger.Log(LogLevel.Error, new EventId(2), "Error message", null, (state, exception) => state.ToString());

            // Печат на всички съобщения
            logger.PrintLog();

            // Премахваме съобщението за Event ID 1
            logger.DeleteEventMessage(1);

            // Принтираме всички съобщения след изтриването
            logger.PrintLog();

        }
    }
}

