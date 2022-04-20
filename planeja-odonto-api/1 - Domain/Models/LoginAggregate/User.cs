using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;

namespace PlanejaOdonto.Api.Domain.Models.LoginAggregate
{
    public class User : BaseModel
    {
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
