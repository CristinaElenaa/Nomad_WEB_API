using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using Nomad.DataAccess.Data;
using Nomad.DataAccess.Helpers;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IOptions<CloudinarySettings> _config;

        public UnitOfWork(ApplicationDbContext context, IOptions<CloudinarySettings> config)
        {

            _dbContext = context;
            _config = config;

            UserRepository = new UserRepository(_dbContext);
            ListingRepository = new ListingRepository(_dbContext);
            ListingTypeRepository = new ListingTypeRepository(_dbContext);
            PrivacyRepository = new PrivacyRepository(_dbContext);
            ReviewRepository = new ReviewRepository(_dbContext);
            ListingReviewRepository = new ListingReviewRepository(_dbContext);
            UserReviewRepository = new UserReviewRepository(_dbContext);
            UserTypeRepository = new UserTypeRepository(_dbContext);
            BookingRepository = new BookingRepository(_dbContext);
            ProfilePhotoRepository = new ProfilePhotoRepository(_dbContext, _config);
            ListingPhotoRepository = new ListingPhotoRepository(_dbContext, _config);

        }

        public IUserRepository UserRepository { get; private set; }
        public IListingRepository ListingRepository { get; private set; }
        public IListingTypeRepository ListingTypeRepository { get; private set; }
        public IPrivacyRepository PrivacyRepository { get; private set; }
        public IReviewRepository ReviewRepository { get; private set; }
        public IListingReviewRepository ListingReviewRepository { get; private set; }
        public IUserReviewRepository UserReviewRepository { get; private set; }
        public IUserTypeRepository UserTypeRepository { get; private set; }
        public IBookingRepository BookingRepository { get; private set; }
        public IProfilePhotoRepository ProfilePhotoRepository { get; private set; }
        public IListingPhotoRepository ListingPhotoRepository { get; private set; }

        public async Task Complete()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
