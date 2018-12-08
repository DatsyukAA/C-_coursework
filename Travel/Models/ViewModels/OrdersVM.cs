using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Models.ViewModels
{
    public class OrdersVM
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int  VoucherId{ get; set; }
        public int Status { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
    }
}
