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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        //private readonly ApplicationDbContext _dbContext;

        public ReviewRepository(ApplicationDbContext dbContext) : base(dbContext) { }


        //public async Task<ICollection<Review>> GetReviewsByListingIdFromDb(int listingId)
        //{
        //    var listingsReviews = await _dbContext.ListingReviews.Where(x => x.ListingId == listingId).ToListAsync();

        //    var data = new List<Review>();
        //    foreach (var listingReview in listingsReviews)
        //    {
        //        var item = await _dbContext.Reviews.FindAsync(listingReview.ReviewId);
        //        data.Add(item);
        //    }

        //    return data;
        //}

        //public async Task<ICollection<double>> GetListingRatings(int listingId)
        //{
        //    var listingsReviews = await _dbContext.ListingReviews.Where(x => x.ListingId == listingId).ToListAsync();
        //    var ratings = new List<double>();
        //    foreach (var listingReview in listingsReviews)
        //    {
        //        var item = await _dbContext.Reviews.FindAsync(listingReview.ReviewId);
        //        ratings.Add(item.Rating);
        //    }

        //    return ratings;
        //}

        //public async Task<ICollection<double>> GetUserRatings(int userId)
        //{
        //    var userReviews = await _dbContext.UsersReviews.Where(x => x.UserReviewedId == userId).ToListAsync();
        //    var ratings = new List<double>();
        //    foreach (var listingReview in userReviews)
        //    {
        //        var item = await _dbContext.Reviews.FindAsync(listingReview.ReviewId);
        //        ratings.Add(item.Rating);
        //    }

        //    return ratings;
        //}

        //public async Task<double> GetListingTotalRating(int listingId)
        //{
        //    double result = 0.0;
        //    var listingRatings = await GetListingRatings(listingId);

        //    foreach (var rating in listingRatings)
        //    {
        //        result += rating;
        //    }
        //    if (result > 0.0)
        //    {
        //        result /= listingRatings.Count();
        //        return result;
        //    }
        //    return 0.00;
        //}

        //public async Task<double> GetUserTotalRating(int userId)
        //{
        //    double result = 0.0;
        //    var userRatings = await GetUserRatings(userId);

        //    foreach (var rating in userRatings)
        //    {
        //        result += rating;
        //    }
        //    if (result > 0.0)
        //    {
        //        result /= userRatings.Count();
        //        return result;
        //    }
        //    return 0.00;
        //}

        //public async Task<ICollection<Review>> GetReviewsByUserIdFromDb(int userId)
        //{
        //    var userReviews = await _dbContext.UsersReviews.Where(x => x.UserReviewedId == userId).ToListAsync();
        //    var data = new List<Review>();
        //    foreach (var listingReview in userReviews)
        //    {
        //        var item = await _dbContext.Reviews.FindAsync(listingReview.ReviewId);
        //        data.Add(item);
        //    }

        //    return data;
        //}

        public async Task<bool> GetReviewByUserListingAndBooking(int userId, int listingId, int bookingId)
        {
            var review = await _dbContext.Reviews
                        .FirstOrDefaultAsync(r => r.AuthorId == userId
                        && _dbContext.ListingReviews.Any(lr
                        => lr.ListingId == listingId && lr.BookingId == bookingId));

            return review != null;
        }

        //public async Task AddListingReview(Review review, ListingReviews listingReview)
        //{
        //    await _dbContext.Reviews.AddAsync(review);
        //    await _dbContext.ListingReviews.AddAsync(listingReview);

        //}
    }
}
