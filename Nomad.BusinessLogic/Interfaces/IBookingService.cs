using Nomad.BusinessLogic.Models;
using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDetailsModel>> GetAll();
        Task<IEnumerable<BookingDetailsModel>> GetAllByListingId(int listingId);
        public Task<IEnumerable<DateTime>> GetOccupiedDates(int listingId);
        Task<IEnumerable<BookingDetailsModel>> GetAllByUserId(int userId);
        Task Add(RegisterBookingModel registerBookingModel);
    }
}
