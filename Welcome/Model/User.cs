using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;// using UserRolesEnum

namespace Welcome.Model
{
    public class User
    {
        private string _name;
        private string _password;
        private UserRolesEnum _role;
        private string _email;
        private string _facultyNumber;
        private int _id;
        private DateTime _expires;
        private int age;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public UserRolesEnum Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string FacultyNumber
        {
            get { return _facultyNumber; }
            set { _facultyNumber = value; }
        }
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Възрастта не може да бъде отрицателна.");
                age = value;
            }
        }
        //Encrypt password
        private string ExcryptPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }
        //Decrypt password
        private string DecryptPassword(string encryptedPassword)
        {
            try { 
            var bytes = Convert.FromBase64String(encryptedPassword);
            return Encoding.UTF8.GetString(bytes);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid encrypted password format.");
            }
        }


    }
}
