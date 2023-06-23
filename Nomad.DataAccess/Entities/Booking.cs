using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int? GuestId { get; set; }
        public User Guest { get; set; }
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfNightsBooked { get; set; }
        public int NumberOfGuests { get; set; }

    }
}
