using System.Collections.Generic;
using Travel.Models.Entites.OrderModels;

namespace Travel.Models.Entites.UserModels
{
    public class Operator
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
