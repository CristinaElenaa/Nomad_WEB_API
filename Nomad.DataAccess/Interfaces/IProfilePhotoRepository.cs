using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IProfilePhotoRepository: IRepository<ProfilePhoto>
    {
        public Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        public Task<DeletionResult> DeletePhotoAsync(string publicId);
        public Task<string> GetMainPhoto(int userId);
    }
}
