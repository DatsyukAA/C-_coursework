namespace Travel.Models.ViewModels
{
    public class VouchersVM
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public bool Status { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public bool InCurrentList { get; set; }
        public int Cost { get; set; }
        public int Discount { get; set; }
    }
}
