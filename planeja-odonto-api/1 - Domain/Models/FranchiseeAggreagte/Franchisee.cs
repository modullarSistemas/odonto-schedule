using System.Collections.Generic;

namespace PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate
{
    public class Franchisee : BaseModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public IList<Franchise> Franchises { get; set; } = new List<Franchise>();
    }
}
