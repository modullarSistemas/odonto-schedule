using PlanejaOdonto.Api.Domain.Models.Enums;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using System.Text.Json.Serialization;

namespace PlanejaOdonto.Api.Domain.Models.DentistAggregate
{
    public class Dentist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FranchiseId { get; set; }

        [JsonIgnore]
        public Franchise Franchise { get; set; }

        public DentistCategory Category { get; set; }

    }
}
