using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository
    {
        private readonly SchoolDbContext _context;

        public UserRepository()
        {
            _context = new SchoolDbContext();
        }

        public bool ValidateUser(string username, string password)
        {
            return _context.Users.Any(u => u.Username == username && u.Password == password);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}