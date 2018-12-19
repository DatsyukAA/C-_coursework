namespace Travel.Models.ViewModels
{
    public class ToursVM
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int ResortId { get; set; }
        public string ResortName { get; set; }
        public bool Status { get; set; }
    }
}
