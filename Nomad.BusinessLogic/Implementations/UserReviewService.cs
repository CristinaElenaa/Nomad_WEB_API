using Nomad.BusinessLogic.Interfaces;
using Nomad.BusinessLogic.Models;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Implementations
{
    public class UserReviewService: IUserReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewService _reviewService;

        public UserReviewService(IUnitOfWork unitOfWork, IReviewService reviewService)
        {
            _unitOfWork = unitOfWork;
            _reviewService = reviewService;
        }

        public async Task<List<ReviewDetailsModel>> GetReviewsForUser(int id)
        {
            var reviews = await _unitOfWork.UserReviewRepository.GetReviewsByUserIdFromDb(id);
            var reviewModels = new List<ReviewDetailsModel>();

            if (reviews.Count == 0)
            {
                return reviewModels;
            }

            foreach (var review in reviews)
            {
                var author = await _unitOfWork.UserRepository.Find(x => x.Id == review.AuthorId);
                var photoUrl = await _unitOfWork.ProfilePhotoRepository.GetMainPhoto(author.Id);
                reviewModels.Add(new ReviewDetailsModel
                {
                    Content = review.Content,
                    Rating = review.Rating,
                    AuthorId = author.Id,
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                    AuthorMainPhotoUrl = photoUrl
                }); ;
            }
            return reviewModels;
        }

        public async Task<double> GetRatingForUser(int id)
        {
            var rating = await _unitOfWork.UserReviewRepository.GetUserTotalRating(id);
            if (rating == 0.00)
            {
                throw new Exception("Rating is not yet calculated!");
            }
            return rating;
        }

        public async Task AddUserReview(RegisterReviewModel registerReviewModel, int userId, int bookingId)
        {
            var review = registerReviewModel;
            var addedReview = await _reviewService.AddReview(review);

            var userReviewModel = new UserReviews
            {
                ReviewId = addedReview.Id,
                UserReviewedId = userId,
                BookingId = bookingId
            };
            await _unitOfWork.UserReviewRepository.Add(userReviewModel);
            await _unitOfWork.Complete();

        }
    }
}
