using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Models
{
    public  class ReviewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int AuthorId { get; set; }
        //public DateOnly DatePublished { get; set; }
    }
}
