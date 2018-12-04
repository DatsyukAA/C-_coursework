using System;

namespace Travel.Models.Entites.OrderModels
{
    public class Voucher
    {
        public int Id { get; set; }
        public Tour Tour { get; set; }
        public bool Status { get; set; }
        public DateTime EnableFrom { get; set; }
        public DateTime EnableTo { get; set; }
    }
}
