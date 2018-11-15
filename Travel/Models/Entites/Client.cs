namespace Travel.Models.Entites
{
    public class Client
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public User Identity { get; set; }
        public string Test { get; set; } 
    }
}
