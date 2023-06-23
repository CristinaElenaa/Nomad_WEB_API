using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Models
{
    public class RegisterListingReviewModel
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        //public string Content { get; set; } = string.Empty;
        //public double Rating { get; set; }
        //public int AuthorId { get; set; }
        //public int ReviewId { get; set; }
        public int ListingId { get; set; }
        public int BookingId { get; set; }
    }
}
