namespace Travel.Models.ViewModels
{
    public class ReportsVM
    {
        public int Id { get; set; }
        public int OperatorId { get; set; }
        public string ReportText { get; set; }
        public string SendTime { get; set; }
        public string[] VoucherList { get; set; }
    }
}
