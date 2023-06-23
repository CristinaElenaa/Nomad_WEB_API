using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IListingReviewRepository: IRepository<ListingReviews>
    {
        Task<ICollection<Review>> GetReviewsForListing(int listingId);
        Task<double> GetListingTotalRating(int listingId);
    }
}
