using System;
using System.Text.Json.Serialization;

namespace PlanejaOdonto.Api.Domain.Models.PacientAggregate
{
    public class Dependent 
    {
        public int Id { get; set; }

        public int PacientId { get; set; }

        [JsonIgnore]
        public Pacient Pacient { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }
    }
}