using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate
{
    public class Franchise 
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Franchisee Franchisee { get; set; }

        public int FranchiseeId { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string District { get; set; }

    }
}
