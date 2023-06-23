using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IListingRepository ListingRepository { get; }
        IListingTypeRepository ListingTypeRepository { get; }
        IPrivacyRepository PrivacyRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IListingReviewRepository ListingReviewRepository { get; }
        IUserReviewRepository UserReviewRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        IBookingRepository BookingRepository { get; }
        IProfilePhotoRepository ProfilePhotoRepository { get; }
        IListingPhotoRepository ListingPhotoRepository { get; }
        Task Complete();

    }
}
