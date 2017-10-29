using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAO;

namespace WebApi.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreateDate { get; set; }

        public static int RegisterUser(User newUser)
        {
            return UserDAO.registerUser(newUser);
        }
        public static User LoginUser(string email,string password)
        {
            return UserDAO.loginUser(email, password);
        }
    }
}
