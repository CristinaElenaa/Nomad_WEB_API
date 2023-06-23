using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; } 
        public DateTime DatePublished { get; set; }

    }
}
