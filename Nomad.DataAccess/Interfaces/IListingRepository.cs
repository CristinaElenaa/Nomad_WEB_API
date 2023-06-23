using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IListingRepository: IRepository<Listing>
    {
        Task<IEnumerable<Listing>>  GetAllWithPhotos();
        Task<IEnumerable<Listing>> FindAllWithPhotos(Expression<Func<Listing, bool>> predicate);
        //Task<Listing> GetListingByTileFromDb(string title);
        //Task<int> GetListingIdByTitleFromDb(string title);
        Task<Listing> GetListingWithPhotos(int listingId);

    }
}
