using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Models
{
    public class CardListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Rating { get; set; }
        public string MainPhotoUrl { get; set; } = string.Empty;

    }
}
