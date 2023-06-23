using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

namespace Nomad.DataAccess.Implementations
{
    public class ProfilePhotoRepository: Repository<ProfilePhoto>, IProfilePhotoRepository
    {
        public ProfilePhotoRepository(ApplicationDbContext dbContext,  IOptions<CloudinarySettings> config) : base(dbContext, config)
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
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
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
        public async Task<string> GetMainPhoto(int userId)
        {
            var data = await _dbContext.ProfilePhoto
               .FirstOrDefaultAsync(p => p.IsMain && p.UserId == userId);
            if (data == null)
                return ("https://res.cloudinary.com/dsv77sz5d/image/upload/v1686763813/imageNotAvailable_xp63jh.jpg");

            return data.Url;
        }
    }
}

