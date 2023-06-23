using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Models
{
    public class BookingDetailsModel
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public string ListingName { get; set; } = string.Empty;
        //public string ListingCity { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        //public string ListingMainPhotoUrl { get; set; } = string.Empty;
        public int HostId { get; set; }
        public string HostName { get; set; } = string.Empty;
        public int NumberOfNightsBooked { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool isReviewed { get; set; }

    }
}
