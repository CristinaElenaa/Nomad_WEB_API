using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using Nomad.BusinessLogic.Helpers;
using Nomad.BusinessLogic.Interfaces;
using Nomad.BusinessLogic.Models;
using Nomad.BussinessLogic.Helpers;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Implementations;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Nomad.BusinessLogic.Implementations
{
    public class ListingService: IListingService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IListingReviewService _listingReviewService;
        private readonly IPhotoService _photoService;
        public ListingService(IUnitOfWork unitOfWork, IListingReviewService listingReviewService,
            IPhotoService photoService) 
        {
            _unitOfWork = unitOfWork;
            _listingReviewService = listingReviewService;
            _photoService = photoService;
        }

        public async Task<List<ListingModel>> GetAllListings()
        {
            var listings = await _unitOfWork.ListingRepository.GetAllWithPhotos();
            var listingModels = new List<ListingModel>();
            foreach (var item in listings)
            {
                var host = await _unitOfWork.UserRepository.Get(item.HostId);
                var mainPhotoUrl = await _unitOfWork.ProfilePhotoRepository.GetMainPhoto(item.HostId);
                var privacy = await _unitOfWork.PrivacyRepository.Get(item.PrivacyTypeId);
                var listingType = await _unitOfWork.ListingTypeRepository.Get(item.ListingTypeId);
                
                listingModels.Add(
                    new ListingModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Photos = item.Photos,
                        Number = item.Number,
                        Street = item.Street,
                        City = item.City,
                        County = item.County,
                        PostalCode = item.PostalCode,
                        Country = item.Country,
                        Capacity = item.Capacity,
                        BedroomCount = item.BedroomCount,
                        BathroomCount = item.BedroomCount,
                        BedCount = item.BedCount,
                        HasAirConditioning = item.HasAirConditioning,
                        HasParking = item.HasParking,
                        HasTv = item.HasTv,
                        HasWiFi = item.HasWiFi,
                        Price = item.Price,
                        HostFirstName = host.FirstName,
                        HostLastName = host.LastName,
                        HostMainPhotoUrl = mainPhotoUrl,
                        HostId = item.HostId,
                        ListingType = listingType.Type,
                        PrivacyType = privacy.Type,
                        TotalRating = await _listingReviewService.GetRatingForListing(item.Id),
                    }) ;
            }

            return listingModels;
        }

        public async Task<PagedList<CardListingModel>> GetAllCardListings(Helpers.UserParams userParams)
        {
            var listings = await _unitOfWork.ListingRepository.GetAllWithPhotos();
            
            if(listings == null)
            {
                throw new Exception("The listings cannot be retrieved!");
            }

            var cardListings =  new List<CardListingModel>();
            foreach (var listing in listings)
            {
                var mainPhoto = new ListingPhoto();
                foreach(var photo in listing.Photos)
                {
                    if(photo.IsMain)
                    {
                        mainPhoto = photo;
                    }
                }

                var rating = await _listingReviewService.GetRatingForListing(listing.Id);

                cardListings.Add(new CardListingModel
                {
                    Id = listing.Id,
                    Name = listing.Name,
                    Description = listing.Description,
                    City = listing.City,
                    Price = listing.Price,
                    Rating = rating,
                    MainPhotoUrl = mainPhoto.Url,
                });
            }

            return await PagedList<CardListingModel>.Create(cardListings, userParams.PageNumber, userParams.PageSIze);
         
        }

        public async Task<ListingModel> GetListingById(int id)
        {
            var item = await _unitOfWork.ListingRepository.GetListingWithPhotos(id);

            if(item == null)
            {
                throw new Exception("Listing does not exist");
            }

            var host = await _unitOfWork.UserRepository.Find(u => u.Id == item.HostId);
            var mainPhotoUrl = await _unitOfWork.ProfilePhotoRepository.GetMainPhoto(item.HostId);
            var listingType = await _unitOfWork.ListingTypeRepository.Find(lt => lt.Id == item.ListingTypeId);
            var privacy = await _unitOfWork.PrivacyRepository.Find(p => p.Id == item.PrivacyTypeId);
            var listingModel = new ListingModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Photos = item.Photos,
                Number = item.Number,
                Street = item.Street,
                City = item.City,
                County = item.County,
                PostalCode = item.PostalCode,
                Country = item.Country,
                Capacity = item.Capacity,
                BedroomCount = item.BedroomCount,
                BathroomCount = item.BedroomCount,
                BedCount = item.BedCount,
                HasAirConditioning = item.HasAirConditioning,
                HasParking = item.HasParking,
                HasTv = item.HasTv,
                HasWiFi = item.HasWiFi,
                Price = item.Price,
                HostFirstName = host.FirstName,
                HostLastName = host.LastName,
                HostMainPhotoUrl = mainPhotoUrl,
                HostId = host.Id,
                ListingType = listingType.Type,
                PrivacyType = privacy.Type,
                TotalRating = await _listingReviewService.GetRatingForListing(item.Id),
            };

            return listingModel;
        }

        public async Task<IEnumerable<CardListingModel>> GetListingsForHost(int hostId)
        {
            var userExists = await _unitOfWork.UserRepository.CheckIfUserExists(hostId);
            if (!userExists)
            {
                throw new Exception("This user does not exist!");

            }

            var listings = await _unitOfWork.ListingRepository.FindAll(x => x.HostId == hostId);
            if(listings == null)
            {
                return  Enumerable.Empty<CardListingModel>();
            }

            var resultedListings = new List<CardListingModel>();
            foreach(var item in listings)
            {
                var mainPhotoUrl = await _unitOfWork.ListingPhotoRepository.GetMainPhoto(item.Id);
                resultedListings.Add(
                new CardListingModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    City = item.City,
                    Price = item.Price,
                    Rating = item.Rating,
                    MainPhotoUrl = mainPhotoUrl

                });
            }

            return resultedListings;
        }

      
        public async Task<IEnumerable<CardListingModel>> SearchListingsByTitle(string title)
        {
            var items = await _unitOfWork.ListingRepository.FindAll(l => l.Name == title);

            if(!items.Any())
            {
                throw new Exception("No listings were found!");
            }
            else
            {
                var listingModels = new List<CardListingModel>();
                foreach (var item in items)
                {
                    var mainPhotoUrl = await _unitOfWork.ListingPhotoRepository.GetMainPhoto(item.Id);

                    listingModels.Add(new CardListingModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        City = item.City,
                        Price = item.Price,
                        Rating = item.Rating,
                        MainPhotoUrl = mainPhotoUrl
                    });
                    
                }
                return listingModels;
            }
        }


        public async Task<bool> IsListingAvailable(int listingId, DateTime checkInDate, DateTime checkOutDate)
        {
            var bookings = await _unitOfWork.BookingRepository.FindAll(b => b.ListingId == listingId);
            if(bookings.Count() == 0)
            {
                return true;
            }

            foreach (var booking in bookings)
            {
                if (checkInDate >= booking.CheckOut || checkOutDate <= booking.CheckIn)
                {
                    // The provided dates do not overlap with the existing booking
                    continue;
                }

                // The listing is occupied on the provided dates
                return false;
            }

            // The listing is available on the provided dates
            return true;
        }
      

        public async Task<IEnumerable<CardListingModel>> SearchListingByFilters(string listingCity,
            string checkInString, string checkOutString, int capacity)
        {
            var listingByCity = await _unitOfWork.ListingRepository.FindAllWithPhotos(l =>
                                    l.City == listingCity && l.Capacity >= capacity);

            DateTime checkInDate = DateTime.Parse(checkInString).Date;
            DateTime checkOutDate = DateTime.Parse(checkOutString).Date;

            var filteredListings = new List<Listing>();
            var resultedListings = new List<CardListingModel>();

            foreach ( var listing in listingByCity)
            {
                if(await IsListingAvailable(listing.Id, checkInDate,checkOutDate))
                {
                    filteredListings.Add(listing);
                }
               
            }

            foreach (var item in filteredListings)
                {
                    var mainPhotoUrl = await _unitOfWork.ListingPhotoRepository.GetMainPhoto(item.Id);
                    resultedListings.Add(
                    new CardListingModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        City = item.City,
                        Price = item.Price,
                        Rating = item.Rating,
                        MainPhotoUrl = mainPhotoUrl

                    });
                }

            return resultedListings;
        }

        public async Task UpdateListing(UpdateListingModel updateListingModel)
        {
            var listing = await _unitOfWork.ListingRepository.Find( l => l.Id == updateListingModel.Id );
            if(listing == null)
            {
                throw new Exception("The listing does not exist!");
            }

            var listingType = await _unitOfWork.ListingTypeRepository.Find(lt =>
                        lt.Type == updateListingModel.ListingType);
            if(listingType == null)
            {
                throw new Exception("The listing type does not exist!");
            }

            var privacyType = await _unitOfWork.PrivacyRepository.Find(lt =>
                        lt.Type == updateListingModel.PrivacyType);
            if(privacyType == null)
            {
                throw new Exception("The privacy type does not exist!");
            }

            listing.Name = updateListingModel.Name;
            listing.Description = updateListingModel.Description;
            listing.Number = updateListingModel.Number;
            listing.Street = updateListingModel.Street;
            listing.PostalCode = updateListingModel.PostalCode;
            listing.City = updateListingModel.City;
            listing.County = updateListingModel.County;
            listing.Country = updateListingModel.Country;
            listing.Price = updateListingModel.Price;
            listing.Capacity = updateListingModel.Capacity;
            listing.BedroomCount = updateListingModel.BedroomCount;
            listing.BedCount = updateListingModel.BedCount;
            listing.BathroomCount = updateListingModel.BathroomCount;
            listing.HasWiFi = updateListingModel.HasWiFi;
            listing.HasTv = updateListingModel.HasTv;
            listing.HasParking = updateListingModel.HasParking;
            listing.HasAirConditioning = updateListingModel.HasAirConditioning;
            listing.ListingTypeId = listingType.Id;
            listing.PrivacyTypeId = privacyType.Id;

            await _unitOfWork.Complete();
        }

        public async Task AddListing(RegisterListingModel registerListingModel)
        {
            ListingType existingListingType = await _unitOfWork.ListingTypeRepository.Find(lt => lt.Type == registerListingModel.ListingType);
            PrivacyType existingPrivacyType = await _unitOfWork.PrivacyRepository.Find(p => p.Type == registerListingModel.PrivacyType);
            User host = await _unitOfWork.UserRepository.Get(registerListingModel.HostId);
            var photo = await _photoService.AddPhotoToNewListing(registerListingModel.Photo);

            if (existingListingType == null)
            {

                throw new Exception("Listing type not found");
            }
            if (existingPrivacyType == null)
            {

                throw new Exception("Privacy type not found");
            }
            if (host == null)
            {

                throw new Exception("Host not found");
            }

            var listing = new Listing
            {
                Name = registerListingModel.Name,
                Description = registerListingModel.Description,
                Number = registerListingModel.Number,
                Street = registerListingModel.Street,
                City = registerListingModel.City,
                County = registerListingModel.County,
                PostalCode = registerListingModel.PostalCode,
                Country = registerListingModel.Country,
                Capacity = registerListingModel.Capacity,
                BedroomCount = registerListingModel.BedroomCount,
                BathroomCount = registerListingModel.BedroomCount,
                BedCount = registerListingModel.BedCount,
                HasWiFi = registerListingModel.HasWiFi,
                HasAirConditioning = registerListingModel.HasAirConditioning,
                HasParking = registerListingModel.HasParking,
                HasTv   = registerListingModel.HasTv,
                Price = registerListingModel.Price,
                //Rating = registerListingModel.TotalRating,
                PrivacyType = existingPrivacyType,
                ListingType = existingListingType,
                Host = host
            };
            listing.Photos.Add(photo);

            await _unitOfWork.ListingRepository.Add(listing);
            await _unitOfWork.Complete();
        }

        public async Task RemoveListing(int listingId)
        {
            var listing = await _unitOfWork.ListingRepository.Get(listingId);
            if(listing == null)
            {
                throw new Exception("Listing does not exist!");
            }

            await _unitOfWork.ListingRepository.Remove(listing);
            await _unitOfWork.Complete();
        }
    }

}
