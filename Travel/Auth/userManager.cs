using System.Collections.Generic;
using System.Linq;
using Travel.Data;
using Travel.Models.Entites;

namespace Travel.Auth
{
    public class UserManager
    {
        private readonly TravelDbContext dbContext;

        public UserManager(TravelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User getClientByName(string name)
        {
            if (dbContext.Users.Where(x => x.Email == name).Count() > 0)
            {
                return dbContext.Users.Where(x => x.Email == name).FirstOrDefault();
            }
            return null;
        }

        public bool checkPassword(User user, string password)
        {
            if (user.Password == password) return true;
            return false;
        }
    }
}
