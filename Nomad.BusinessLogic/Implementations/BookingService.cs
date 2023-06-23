using Microsoft.Extensions.Hosting;
using Nomad.BusinessLogic.Interfaces;
using Nomad.BusinessLogic.Models;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Implementations
{
    public class BookingService: IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookingDetailsModel>> GetAll()
        {
            var bookings = await _unitOfWork.BookingRepository.GetAll();
            
            var bookingModels = new List<BookingDetailsModel>();
            foreach (var booking in bookings)
            {
                var listing = await _unitOfWork.ListingRepository.Find(l => l.Id == booking.ListingId);
                var host = await _unitOfWork.UserRepository.Find(u => u.Id == listing.HostId);
                bookingModels.Add(new BookingDetailsModel
                {
                    Id = booking.Id,
                    ListingId = booking.ListingId,
                    ListingName = listing.Name,
                    TotalPrice = listing.Price * booking.NumberOfNightsBooked,
                    HostId = listing.HostId,
                    HostName = host.FirstName,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    NumberOfGuests = booking.NumberOfGuests,
                    NumberOfNightsBooked = booking.NumberOfNightsBooked,

                });
            }

            return bookingModels;
        }
        public async Task<IEnumerable<BookingDetailsModel>> GetAllByListingId(int listingId)
        {
            var bookings = await _unitOfWork.BookingRepository.FindAll(x => x.ListingId == listingId);

            if(bookings.Count() == 0)
            {
                throw new Exception("This listing does not have bookings!");
            }

            var bookingModels = new List<BookingDetailsModel>();
            var listing = await _unitOfWork.ListingRepository.Find(l => l.Id == listingId);
            var host = await _unitOfWork.UserRepository.Find(u => u.Id == listing.HostId);
            foreach (var booking in bookings)
            {
                bookingModels.Add(new BookingDetailsModel
                {
                    Id = booking.Id,
                    ListingId = booking.ListingId,
                    ListingName = listing.Name,
                    TotalPrice = listing.Price * booking.NumberOfNightsBooked,
                    HostId = listing.HostId,
                    HostName = host.FirstName,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    NumberOfGuests = booking.NumberOfGuests,
                    NumberOfNightsBooked = booking.NumberOfNightsBooked,
                });
            }


            return bookingModels;
        }

        public async Task<IEnumerable<DateTime>> GetOccupiedDates(int listingId)
        {
            var bookings = await _unitOfWork.BookingRepository.FindAll(x => x.ListingId == listingId);

            if (bookings.Count() == 0)
            {
                return Enumerable.Empty<DateTime>();
            }

            var occupiedDays = new List<DateTime>();

            foreach (var booking in bookings)
            {
                var daysInRange = Enumerable.Range(0, (int)(booking.CheckOut - booking.CheckIn).TotalDays)
                    .Select(offset => booking.CheckIn.AddDays(offset));

                occupiedDays.AddRange(daysInRange);
            }

            return occupiedDays;
        }

        public async Task<IEnumerable<BookingDetailsModel>> GetAllByUserId(int userId)
        {
            var bookings = await _unitOfWork.BookingRepository.FindAll(x => x.GuestId == userId);
           
            if (bookings.Count() == 0)
            {
                return Enumerable.Empty<BookingDetailsModel>();
            }

            var bookingModels = new List<BookingDetailsModel>();
            foreach (var booking in bookings)
            {
                var listing = await _unitOfWork.ListingRepository.Find(l => l.Id == booking.ListingId);
                var host = await _unitOfWork.UserRepository.Find(u => u.Id == listing.HostId);
                bookingModels.Add(new BookingDetailsModel
                {
                    Id = booking.Id,
                    ListingId = booking.ListingId,
                    ListingName = listing.Name,
                    TotalPrice = listing.Price * booking.NumberOfNightsBooked,
                    HostId = listing.HostId,
                    HostName = host.FirstName,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    NumberOfGuests = booking.NumberOfGuests,
                    NumberOfNightsBooked = booking.NumberOfNightsBooked,
                    isReviewed = await HasUserReviewedListingForBooking(userId, listing.Id, booking.Id)
                }) ;
            }

            return bookingModels;
        }

        public async Task Add(RegisterBookingModel registerBookingModel)
        {
            var booking = new Booking
            {
                CheckIn = registerBookingModel.CheckIn,
                CheckOut = registerBookingModel.CheckOut,
                NumberOfGuests = registerBookingModel.NumberOfGuests,
                NumberOfNightsBooked = registerBookingModel.NumberOfNightsBooked,
                GuestId = registerBookingModel.GuestId,
                ListingId = registerBookingModel.ListingId
            };

            await _unitOfWork.BookingRepository.Add(booking);
            await _unitOfWork.Complete();
        }

        public async Task<bool> HasUserReviewedListingForBooking(int userId, int listingId, int bookingId)
        {
            var reviewExists = await _unitOfWork.ReviewRepository.GetReviewByUserListingAndBooking(userId, listingId, bookingId);
            if (reviewExists)
            {
                return true;
            }
            return false;
        }
    }
}
