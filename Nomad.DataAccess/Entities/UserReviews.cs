using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Entities
{
    public class UserReviews
    {
        [Key]
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; } = new Review();
        public int UserReviewedId { get; set; }
        //public User UserReviewed { get; set; }
        public int BookingId { get; set; }
        //public string Content { get; set; } = string.Empty;
        //public int Rating { get; set; }  
    }
}
