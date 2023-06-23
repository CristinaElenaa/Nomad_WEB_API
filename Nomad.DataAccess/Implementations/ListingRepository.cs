using Microsoft.EntityFrameworkCore;
using Nomad.DataAccess.Data;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Implementations
{
    public class ListingRepository: Repository<Listing>, IListingRepository
    {
        
        public ListingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Listing>> GetAllWithPhotos()
        {
            var data = await _dbContext.Listings
                .Include(x => x.Photos)
                .ToListAsync();

            return data;
        }

        //public async Task<Listing> GetListingByTileFromDb(string title)
        //{
        //    var data = await _dbContext.Listings.FirstOrDefaultAsync(l => l.Name == title);

        //    return data;
        //}

        //public async Task<int> GetListingIdByTitleFromDb(string title)
        //{
        //    var data = await _dbContext.Listings.FirstOrDefaultAsync(l => l.Name == title);

        //    return data.Id;
        //}
        public async Task<Listing> GetListingWithPhotos(int listingId)
        {
            var data = await _dbContext.Listings
                        .Include(p => p.Photos)
                        .SingleOrDefaultAsync(l => l.Id == listingId);

            return data;
        }

        public async Task<IEnumerable<Listing>> FindAllWithPhotos(Expression<Func<Listing, bool>> predicate)
        {
            return await _dbContext.Listings.Include(p => p.Photos).Where(predicate).ToListAsync();
        }

       
    }
}
