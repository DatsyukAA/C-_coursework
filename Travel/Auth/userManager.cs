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

        public Client getClientByName(string name)
        {
            if (dbContext.Clients.Where(x => x.Email == name).Count() > 0)
            {
                return dbContext.Clients.Where(x => x.Email == name).FirstOrDefault();
            }
            return null;
        }

        public bool checkPassword(Client user, string password)
        {
            if (user.Password == password) return true;
            return false;
        }
    }
}
