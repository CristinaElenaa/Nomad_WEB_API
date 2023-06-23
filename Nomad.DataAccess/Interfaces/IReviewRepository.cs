using Microsoft.EntityFrameworkCore;
using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IReviewRepository: IRepository<Review>
    {
        //Task<ICollection<Review>> GetReviewsByListingIdFromDb(int listingId);
        //Task<double> GetListingTotalRating(int listingId);
        //Task<double> GetUserTotalRating(int userId);
        //Task<ICollection<double>> GetListingRatings(int listingId);
        //Task<ICollection<double>> GetUserRatings(int userId);
        //Task<ICollection<Review>> GetReviewsByUserIdFromDb(int userId);
        Task<bool> GetReviewByUserListingAndBooking(int userId, int listingId, int bookingId);
    }
}
