using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool Login(string username, string password)
        {
            // Business Logic before validating user
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            return _userRepository.ValidateUser(username, password);
        }
    }
}