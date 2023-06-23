using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Nomad.BusinessLogic.Helpers;
using Nomad.BusinessLogic.Models;
using Nomad.BussinessLogic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Interfaces
{
    public interface IListingService
    {
        Task<List<ListingModel>> GetAllListings();
        Task<PagedList<CardListingModel>> GetAllCardListings(UserParams userParams);
        Task<IEnumerable<CardListingModel>> GetListingsForHost(int hostId);
        Task<ListingModel> GetListingById(int id);
        Task AddListing(RegisterListingModel registerListingModel);
        Task<IEnumerable<CardListingModel>> SearchListingsByTitle(string title);
        Task<IEnumerable<CardListingModel>> SearchListingByFilters(string listingCity,
           string checkInString, string checkOutString, int capacity);
        Task UpdateListing(UpdateListingModel updateListingModel);
        Task RemoveListing(int listingId);
    }
}
