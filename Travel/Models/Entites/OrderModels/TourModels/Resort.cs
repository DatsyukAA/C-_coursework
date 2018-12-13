namespace Travel.Models.Entites.OrderModels.TourModels
{
    public class Resort
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string ResortName { get; set; }
    }
}
