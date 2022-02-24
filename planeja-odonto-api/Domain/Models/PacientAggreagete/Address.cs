using System.Text.Json.Serialization;

namespace PlanejaOdonto.Api.Domain.Models.PacientAggregate
{
    public class Address : BaseModel
    {
       
        public int PacientId { get; set; }

        [JsonIgnore]
        public Pacient Pacient { get; set; }

        public string City { get; set; }

        public string State { get;  set; }

        public string ZipCode { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string Complement { get; set; }
    }
}