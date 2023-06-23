using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Models
{
    public class ReviewDetailsModel
    {
        public string Content { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; } = string.Empty;
        public string AuthorLastName { get; set; } = string.Empty;
        public string AuthorMainPhotoUrl { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }

    }
}
