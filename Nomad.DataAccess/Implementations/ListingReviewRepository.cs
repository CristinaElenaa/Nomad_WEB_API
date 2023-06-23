using Microsoft.EntityFrameworkCore;
using Nomad.DataAccess.Data;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Implementations
{
    public class ListingReviewRepository: Repository<ListingReviews>, IListingReviewRepository
    {
        public ListingReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Review>> GetReviewsForListing(int listingId)
        {
            var listingsReviews = await _dbContext.ListingReviews.Where(x => x.ListingId == listingId).ToListAsync();

            var data = new List<Review>();
            foreach (var listingReview in listingsReviews)
            {
                var item = await _dbContext.Reviews.FindAsync(listingReview.ReviewId);
                data.Add(item);
            }

            return data;
        }

        public async Task<double> GetListingTotalRating(int listingId)
        {
            double result = 0.0;
            var listingRatings = await GetListingRatings(listingId);

            foreach (var rating in listingRatings)
            {
                result += rating;
            }
            if (result > 0.0)
            {
                result /= listingRatings.Count();
                return result;
            }
            return 0.00;
        }

        public async Task<ICollection<double>> GetListingRatings(int listingId)
        {
            var listingsReviews = await _dbContext.ListingReviews.Where(x => x.ListingId == listingId).ToListAsync();
            var ratings = new List<double>();
            foreach (var listingReview in listingsReviews)
            {
                var item = await _dbContext.Reviews.FindAsync(listingReview.ReviewId);
                ratings.Add(item.Rating);
            }

            return ratings;
        }
    }
}
