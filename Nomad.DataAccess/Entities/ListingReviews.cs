using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Entities
{
    public class ListingReviews
    {
        [Key]
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        public int BookingId { get; set; }
        //public Booking Booking { get; set; }
        //    public string Content { get; set; } = string.Empty;
        //    public int Rating { get; set; }
    }
}
