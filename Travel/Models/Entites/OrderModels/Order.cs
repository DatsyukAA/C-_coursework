using System;
using Travel.Models.Entites.UserModels;

namespace Travel.Models.Entites.OrderModels
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }
        public int Status { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
