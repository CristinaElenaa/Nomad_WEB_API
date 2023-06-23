using Nomad.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Interfaces
{
    public interface IUserReviewService
    {
        Task<List<ReviewDetailsModel>> GetReviewsForUser(int id);
        Task<double> GetRatingForUser(int id);
        Task AddUserReview(RegisterReviewModel registerReviewModel, int userId, int bookingId);
    }
}
