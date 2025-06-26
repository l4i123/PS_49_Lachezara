using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    internal class UserData
    {
        private List<User> _users;
        private int _nextId;//PRYMARY KEY СЛЕДВАЩОТО СВОБОДНО МЯСТО
        public UserData()
        {
            _users = new List<User>();
            _nextId = 0; // Началната стойност за ID
        }
        public void AddUser(User user)
        {
            if (_users == null)
            {
                _users = new List<User>();
            }
            user.Id = _nextId++;
            _users.Add(user);
        }
        public void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Name == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x=> x.Name == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        }
        public bool ValidateUserLINQ(string name, string password)
        {
            var ret = from user in _users
                      where user.Name == name && user.Password == password
                      select user.Id;
            return ret != null ? true: false;
        }
        public User GetUser(string name, string password)
        {
            var user = (from u in _users
                    where u.Name == name && u.Password == password
                    select u).FirstOrDefault();
            return user;
        }
        public void SetActive(string name, DateTime validUntil)
        {
            var user = (from u in _users
                        where u.Name == name
                        select u).FirstOrDefault();

            if (user != null)
            {
                user.Expires = validUntil;
            }
        }
        public void AssignUserRole(string name, UserRolesEnum role)
        {
            var user = (from u in _users
                        where u.Name == name
                        select u).FirstOrDefault();

            if (user != null)
            {
                user.Role = role;
            }
        }

    }
}
