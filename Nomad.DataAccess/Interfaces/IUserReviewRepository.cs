using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IUserReviewRepository: IRepository<UserReviews>
    {
        Task<ICollection<Review>> GetReviewsByUserIdFromDb(int userId);
        Task<double> GetUserTotalRating(int userId);
    }
}
