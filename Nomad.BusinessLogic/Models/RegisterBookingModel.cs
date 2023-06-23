using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Models
{
    public class RegisterBookingModel
    {
        public int? GuestId { get; set; }
        public int ListingId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfNightsBooked { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
