using Nomad.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Interfaces
{
    public interface IReviewService
    {
        //Task<List<ReviewDetailsModel>> GetReviewsForUser(int id);
        //Task<List<ReviewDetailsModel>> GetReviewsForListing(int id);
        //Task<double> GetRatingForListing(int id);
        //Task<double> GetRatingForUser(int id);
        //Task<List<ReviewDetailsModel>> GetReviewsForListingByUser(int userId, int listingId);
        Task<RegisterReviewModel> AddReview(RegisterReviewModel registerReviewModel);
    }
}
