using Travel.Models.Entites.OrderModels.TourModels;

namespace Travel.Models.Entites.OrderModels
{
    public class Tour
    {
        public int Id { get; set; }
        public Country Counry { get; set; }
        public Hotel Hotel { get; set; }
        public Resort Resort { get; set; }
        public bool Status { get; set; }
    }
}
