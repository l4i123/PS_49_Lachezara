using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;
namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;
        public UserViewModel(User user)
        {
            _user = new User();
            _user = user;
        }
        public string Name
        {
            get { return _user.Name; }
            set { _user.Name = value; }
        }
        public string Password
        {
            get { return _user.Password; }
            set { _user.Password = value; }
        }
        public string Role
        {
            get { return _user.Role.ToString(); }
            set
            {
                if (Enum.TryParse(value, out UserRolesEnum role))
                {
                    _user.Role = role;
                }
                else
                {
                    throw new ArgumentException("Invalid role value");
                }
            }
        }
        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }
        public string FacultyNumber
        {
            get { return _user.FacultyNumber; }
            set { _user.FacultyNumber = value; }
        }
        public int Age
        {
            get { return _user.Age; }
            set { _user.Age = value; }
        }
       
    }
}
