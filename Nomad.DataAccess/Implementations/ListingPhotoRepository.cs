using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Nomad.DataAccess.Data;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Helpers;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Nomad.DataAccess.Implementations
{
    public class ListingPhotoRepository: Repository<ListingPhoto>, IListingPhotoRepository
    {
        public ListingPhotoRepository(ApplicationDbContext dbContext, IOptions<CloudinarySettings> config) : base(dbContext, config)
        {

        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Width(1000) .Crop("scale") .FetchFormat("auto"),
                    Folder = "da-net7"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            return await _cloudinary.DestroyAsync(deleteParams);
        }

        public async Task<string> GetMainPhoto(int listingId)
        {
            var data = await _dbContext.ListingPhotos
               .FirstOrDefaultAsync(p => p.IsMain && p.ListingId == listingId);
            if (data == null)
                return ("https://res.cloudinary.com/dsv77sz5d/image/upload/v1686763813/imageNotAvailable_xp63jh.jpg");

            return data.Url;
        }
    }
}

