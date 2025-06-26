using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
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

            
        }
    }
}
