using Microsoft.AspNetCore.Components.Forms;
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
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<List<ReviewDetailsModel>> GetReviewsForUser(int id)
        //{
        //    var reviews = await _unitOfWork.ReviewRepository.GetReviewsByUserIdFromDb(id);
        //    var reviewModels = new List<ReviewDetailsModel>();

        //    if (reviews.Count == 0)
        //    {
        //        //throw new Exception("This user is not reviewed yet!");
        //        return reviewModels;
        //    }

        //    foreach (var review in reviews)
        //    {
        //        var author = await _unitOfWork.UserRepository.Find(x => x.Id == review.AuthorId);
        //        reviewModels.Add(new ReviewDetailsModel
        //        {
        //            Content = review.Content,
        //            Rating = review.Rating,
        //            AuthorId = author.Id,
        //            AuthorFirstName = author.FirstName,
        //            AuthorLastName = author.LastName,
        //        }); ;
        //    }
        //    return reviewModels;
        //}

        //public async Task<List<ReviewDetailsModel>> GetReviewsForListingByUser(int userId, int listingId)
        //{
        //    var listingReviews = await _unitOfWork.ReviewRepository.GetReviewsByListingIdFromDb(listingId);
        //    var reviewsForUser = listingReviews.Where(review => review.AuthorId == userId).ToList();
        //    var reviewModels = new List<ReviewDetailsModel>();

        //    foreach (var review in reviewsForUser)
        //    {
        //        var author = await _unitOfWork.UserRepository.Find(x => x.Id == review.AuthorId);
        //        reviewModels.Add(new ReviewDetailsModel
        //        {
        //            Content = review.Content,
        //            Rating = review.Rating,
        //            AuthorId = author.Id,
        //            AuthorFirstName = author.FirstName,
        //            AuthorLastName = author.LastName,
        //        }); 
        //    }
        //    return reviewModels;
        //}

        //public async Task<List<ReviewDetailsModel>> GetReviewsForListing(int id)
        //{
        //    var reviews = await _unitOfWork.ReviewRepository.GetReviewsByListingIdFromDb(id);

        //    if(reviews.Count == 0)
        //    {
        //        throw new Exception("This listing is not reviewed yet!");
        //    }

        //    var reviewModels = new List<ReviewDetailsModel>();
        //    foreach (var review in reviews)
        //    {
        //        var author = await _unitOfWork.UserRepository.Find(x => x.Id == review.AuthorId);
        //        var authorMainPhotoUrl = await _unitOfWork.ProfilePhotoRepository.GetMainPhoto(author.Id);

        //        reviewModels.Add(new ReviewDetailsModel
        //        {
        //            Content = review.Content,
        //            Rating = review.Rating,
        //            AuthorId = author.Id,
        //            AuthorFirstName = author.FirstName,
        //            AuthorLastName = author.LastName,
        //            AuthorMainPhotoUrl = authorMainPhotoUrl,
        //        }); ;
        //    }
        //    return reviewModels;
        //}

        //public async Task<double> GetRatingForListing(int id)
        //{
        //    var rating = await _unitOfWork.ReviewRepository.GetListingTotalRating(id);
        //    //if(rating==0.00)
        //    //{
        //    //    throw new Exception("Rating is not yet calculated!");
        //    //}
        //    return rating;
        //}

        //public async Task<double> GetRatingForUser(int id)
        //{
        //    var rating = await _unitOfWork.ReviewRepository.GetUserTotalRating(id);
        //    if (rating == 0.00)
        //    {
        //        throw new Exception("Rating is not yet calculated!");
        //    }
        //    return rating;
        //}

        public async Task<RegisterReviewModel> AddReview(RegisterReviewModel registerReviewModel)
        {
            var review = new Review
            {
                Content = registerReviewModel.Content,
                Rating = registerReviewModel.Rating,
                AuthorId = registerReviewModel.AuthorId,
            };

            if (review == null)
            {
                throw new Exception("Review is null!");
            }

            await _unitOfWork.ReviewRepository.Add(review);
            await _unitOfWork.Complete();

            var newRegisterReviewModel = new RegisterReviewModel
            {
                Id = review.Id,
                AuthorId = review.AuthorId,
                Content = review.Content,
                Rating = review.Rating,
            };

            return newRegisterReviewModel;
        }

    }
}
