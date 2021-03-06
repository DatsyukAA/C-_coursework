﻿using System;
using System.Linq;
using Travel.Data;
using Travel.Models.Entites.UserModels;

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
            try
            {
                return dbContext.Users.Where(x => x.Email == name).FirstOrDefault();
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }

        public bool checkPassword(User user, string password)
        {
            if (user.Password == password) return true;
            return false;
        }
    }
}
