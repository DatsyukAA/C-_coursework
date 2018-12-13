using System;
using System.Collections.Generic;
using Travel.Models.Entites.OrderModels;

namespace Travel.Models.Entites.UserModels.OperatorModels
{
    public class Report
    {
        public int Id { get; set; }
        public Operator Operator { get; set; }
        public string ReportText { get; set; }
        public List<Voucher> VoucherList { get; set; }
        public DateTime SendTime { get; set; }
    }
}
