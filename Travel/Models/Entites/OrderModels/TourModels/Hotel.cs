namespace Travel.Models.Entites.OrderModels.TourModels
{
    public class Hotel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string HotelName { get; set; }
    }
}
