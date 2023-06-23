using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Nomad.BusinessLogic.Models;
using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoModel> AddProfilePhoto(IFormFile file, int userId);
        Task<ListingPhoto> AddPhotoToNewListing(IFormFile file);
        Task<PhotoModel> AddListingPhoto(IFormFile file, int listingId);
    }
}
