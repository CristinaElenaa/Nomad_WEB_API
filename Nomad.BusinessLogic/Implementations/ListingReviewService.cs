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
    public class ListingReviewService: IListingReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewService _reviewService;

        public ListingReviewService(IUnitOfWork unitOfWork, IReviewService reviewService)
        {
            _unitOfWork = unitOfWork;
            _reviewService = reviewService;
        }

        public async Task<List<ReviewDetailsModel>> GetReviewsForListing(int id)
        {
            var reviews = await _unitOfWork.ListingReviewRepository.GetReviewsForListing(id);
            var reviewModels = new List<ReviewDetailsModel>();

            //if (reviews.Count == 0)
            //{
            //    //throw new Exception("This listing is not reviewed yet!");
            //    //return reviewModels;
            //}

            
            foreach (var review in reviews)
            {
                var author = await _unitOfWork.UserRepository.Find(x => x.Id == review.AuthorId);
                var authorMainPhotoUrl = await _unitOfWork.ProfilePhotoRepository.GetMainPhoto(author.Id);

                reviewModels.Add(new ReviewDetailsModel
                {
                    Content = review.Content,
                    Rating = review.Rating,
                    AuthorId = author.Id,
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                    AuthorMainPhotoUrl = authorMainPhotoUrl,
                    DatePublished = review.DatePublished,
                }); ;
            }
            return reviewModels;
        }

        public async Task<double> GetRatingForListing(int id)
        {
            var rating = await _unitOfWork.ListingReviewRepository.GetListingTotalRating(id);
            //if(rating==0.00)
            //{
            //    throw new Exception("Rating is not yet calculated!");
            //}
            return rating;
        }

        public async Task AddListingReview(RegisterReviewModel registerReviewModel, int listingId, int bookingId)
        {
            var review = new RegisterReviewModel();
            review = registerReviewModel;
            var addedReview = await _reviewService.AddReview(review);

            var listingReviewModel = new ListingReviews
            {
                ReviewId = addedReview.Id,
                ListingId = listingId,
                BookingId = bookingId
            };
            await _unitOfWork.ListingReviewRepository.Add(listingReviewModel);
            await _unitOfWork.Complete();
        }
    }
}
