using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Entities
{
    public class Listing
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ListingPhoto> Photos { get; set; } = new List<ListingPhoto>();
        public string Number { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public int BedCount { get; set; }
        public bool HasWiFi { get; set; }
        public bool HasTv { get; set; }
        public bool HasParking { get; set; }
        public bool HasAirConditioning { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public int ListingTypeId { get; set; }
        public ListingType ListingType { get; set; }
        public int PrivacyTypeId { get; set; }
        public PrivacyType PrivacyType { get; set; }
        public int HostId { get; set; }
        public User Host { get; set; }


    }
}
