using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;
namespace Welcome.View
{
    public class UserView
    {
        UserViewModel _viewModel;
        public UserView(UserViewModel userViewModel)
        {
            _viewModel = userViewModel;
        }
        public UserViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }
        public void DisplayUserInfo()
        {
            Console.WriteLine("Welcome:");
            Console.WriteLine("User Name: " + _viewModel.Name);
            Console.WriteLine("User Role: " + _viewModel.Role);
            Console.WriteLine("User Email: " + _viewModel.Email);
            Console.WriteLine("User Age: " + _viewModel.Age);
        }

        public void DisplayError()
        {
            throw new NotImplementedException();
        }
    }
}
