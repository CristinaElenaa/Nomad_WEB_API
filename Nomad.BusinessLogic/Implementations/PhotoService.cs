using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Nomad.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Interfaces;
using Nomad.BusinessLogic.Models;
using Microsoft.AspNetCore.Identity;

namespace Nomad.BusinessLogic.Implementations
{
    public class PhotoService: IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PhotoModel> AddProfilePhoto(IFormFile file, int userId)
        {
            var user = await _unitOfWork.UserRepository.Find(u => u.Id == userId);
            var photos =  await _unitOfWork.ProfilePhotoRepository.FindAll(u => u.UserId == userId);
            if(user == null)
            {
                throw new Exception("The user was not found!");
            }

            var result = await _unitOfWork.ProfilePhotoRepository.AddPhotoAsync(file);
            if (result.Error != null)
            {
                throw new Exception("The photo was not aded!");
            }

            if(photos.Count() > 0)
            {
                foreach(var item in photos)
                {
                    item.IsMain = false;
                }
            }

            var photo = new ProfilePhoto
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                IsMain = true
            };

            user.Photos.Add(photo);

            await _unitOfWork.Complete();
            var photoModel = new PhotoModel
            {
                Id = photo.Id,
                Url = photo.Url,
                IsMain = photo.IsMain
            };

            if (photoModel != null)
            {
                return photoModel;
            }
            throw new Exception("The photo was not added!");

        }

       public async Task<ListingPhoto> AddPhotoToNewListing(IFormFile file)
        {
            var result = await _unitOfWork.ListingPhotoRepository.AddPhotoAsync(file);
            if (result.Error != null)
            {
                throw new Exception("The photo was not added!");
            }

            var photo = new ListingPhoto
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                IsMain = true
            };

            return photo;
        }

        public async Task<PhotoModel> AddListingPhoto(IFormFile file, int listingId)
        {
            var listing = await _unitOfWork.ListingRepository.GetListingWithPhotos(listingId);
            if(listing == null)
            {
                throw new Exception("This listing does not exist!");
            }

            var result = await _unitOfWork.ListingPhotoRepository.AddPhotoAsync(file);
            if (result.Error != null)
            {
                throw new Exception("The photo was not aded!");
            }

            var photo = new ListingPhoto
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
            };

            if (listing.Photos.Count() == 0)
            {
                photo.IsMain = true;
            }
            listing.Photos.Add(photo);

            await _unitOfWork.Complete();

            var photoModel = new PhotoModel
            {
                Id = photo.Id,
                Url = photo.Url,
                IsMain = photo.IsMain
            };

            if (photoModel != null)
            {
                return photoModel;
            }
            throw new Exception("The photo was not added!");

        }
    }
}

