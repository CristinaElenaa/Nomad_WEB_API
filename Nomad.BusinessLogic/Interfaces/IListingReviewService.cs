using Nomad.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Interfaces
{
    public interface IListingReviewService
    {
        Task<List<ReviewDetailsModel>> GetReviewsForListing(int id);
        Task<double> GetRatingForListing(int id);
        Task AddListingReview(RegisterReviewModel registerReviewModel, int ListingId, int BookingId);
    }
}
