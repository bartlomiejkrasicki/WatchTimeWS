using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WatchTimeWS.Models;

namespace WatchTimeWS
{
    [WebService(Namespace = "http://tempuri.org/Users", Name = "WatchTime Users Web Service")]
    public class UsersService : System.Web.Services.WebService
    {

        private EfDbContext _context;

        public UsersService()
        {
            _context = new EfDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [WebMethod]
        public User Login(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                user.Password = "";
                return user;
            }
            else
            {
                return new User
                {
                    Role = "ERROR"
                };
            }
        }

        [WebMethod]
        public User Register(string email, string login, string password )
        {
            var isUserExists = _context.Users.SingleOrDefault(u => u.Email == email || u.Login == login);
            if (isUserExists == null)
            {
                ICryptoService cryptoService = new PBKDF2();
                var newUser = new User
                {
                    Email = email,
                    Login = login,
                    Password = password,
                    Role = "USER"
                };

                var userFromDb = _context.Users.Add(newUser);
                _context.SaveChanges();
                userFromDb.Password = "";
                return userFromDb;
            }
            else
            {
                return new User
                {
                    Role = "ERROR"
                };
            }
        }
    }
}
