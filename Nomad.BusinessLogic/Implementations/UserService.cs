using Microsoft.AspNetCore.Identity;
using Nomad.BusinessLogic.Interfaces;
using Nomad.BusinessLogic.Models;
using Nomad.DataAccess.Data;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Implementations;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public UserService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
           var data = await _unitOfWork.UserRepository.GetAll();
           
           var users = new List<UserModel>();
       

            users = data.Select(item => new UserModel
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                Token = _tokenService.CreateToken(item),
                PhoneNumber = item.PhoneNumber,
                //PhotoUrl = item.Photo.Url,
                Number = item.Number,
                Street = item.Street,
                City = item.City,
                County = item.County,
                Country = item.Country,
                PostalCode = item.PostalCode

            }).ToList();
            return users;
        }

        public async Task<UserModel> GetUserByFullName(string firstName, string lastName)
        {
            var user = await _unitOfWork.UserRepository.Find( u => u.FirstName == firstName && u.LastName == lastName);
            
            var userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                //Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Number = user.Number,
                Street = user.Street,
                City = user.City,
                County = user.County,
                Country = user.Country,
                PostalCode = user.PostalCode
            };

            return userModel;
        }

        public async Task<int> GetUserIdByFullName(string firstName, string lastName)
        {
            var user = await _unitOfWork.UserRepository.Find(u => u.FirstName == firstName && u.LastName == lastName);

            return user.Id;
        }

        public async Task<int> GetUserIdByEmail(string userEmail)
        {
            var user = await _unitOfWork.UserRepository.Find(u => u.Email == userEmail);

            return user.Id;
        }

        public async Task<UserModel> GetUserByEmail(string userEmail)
        {
            var user = await _unitOfWork.UserRepository.Find(u => u.Email == userEmail);
            
            var userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                PhoneNumber = user.PhoneNumber,
                
                Number = user.Number,
                Street = user.Street,
                City = user.City,
                County = user.County,
                Country = user.Country,
                PostalCode = user.PostalCode
            };

            return userModel;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.Get(id);
            //var user1 = await _unitOfWork.UserRepository.GetUserWithPhotos(id);
            var photoUrl = await _unitOfWork.ProfilePhotoRepository.GetMainPhoto(user.Id);

            var userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                PhoneNumber = user.PhoneNumber,
                PhotoUrl = photoUrl,
                Number = user.Number,
                Street = user.Street,
                City = user.City,
                County = user.County,
                Country = user.Country,
                PostalCode = user.PostalCode
            };

            return userModel;
        }

        public async Task<bool> UserExists(string email)
        {
            var user =  await _unitOfWork.UserRepository.Find(u => u.Email == email.ToLower());
            if (user!=null)
            {
                return true;
            }
            return false;
        }

        public async Task UpdateUser(UpdateUserModel updateUserModel)
        {
            var user = await _unitOfWork.UserRepository.Find(u => u.Id == updateUserModel.Id);
            if (user == null)
            {
                throw new Exception("User not found!");
            }


            user.FirstName = updateUserModel.FirstName;
            user.LastName = updateUserModel.LastName;
            user.Email = updateUserModel.Email;
            user.PhoneNumber = updateUserModel.PhoneNumber;
            
            user.Street = updateUserModel.Street;
            user.Number = updateUserModel.Number;
            user.PostalCode = updateUserModel.PostalCode;
            user.City = updateUserModel.City;
            user.Country = updateUserModel.Country;
            user.County = updateUserModel.County;
            

            await _unitOfWork.Complete();
        }

        public async Task Add(RegisterModel registerModel)
        {
            UserType existingUserType = await _unitOfWork.UserTypeRepository.Get(3);

            if (await UserExists(registerModel.Email))
            {
                throw new Exception("You are already registered!");
            }

            if (existingUserType == null)
            {
                
                throw new Exception("User type not found");
            }

            using var hmac = new HMACSHA512();
            var user = new User
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerModel.Password)),
                PasswordSalt = hmac.Key,
                PhoneNumber = registerModel.PhoneNumber,
                Number = registerModel.Number,
                Street = registerModel.Street,
                City = registerModel.City,
                County = registerModel.County,
                Country = registerModel.Country,
                PostalCode = registerModel.PostalCode,
                UserType = existingUserType
            };

            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.Complete();
        }

        public async Task<UserModel> Login(LoginModel loginModel)
        {
            var user = await _unitOfWork.UserRepository.SingleOrDefault(u => u.Email == loginModel.Email.ToLower());

            if (user == null)
            {
                throw new Exception("Unauthorized");
            }
            //var result = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginModel.Password));
            for(int i=0; i<computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    throw new Exception("User unauthorized!");
                }
            }

            var userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                PhoneNumber = user.PhoneNumber,
                Number = user.Number,
                Street = user.Street,
                City = user.City,
                County = user.County,
                Country = user.Country,
                PostalCode = user.PostalCode
            };

            return userModel;
        }

        public async Task RemoveUser(int userId)
        {
            var user = await _unitOfWork.UserRepository.Get(userId);
            if (user == null)
            {
                throw new Exception("User does not exist!");
            }

            await _unitOfWork.UserRepository.Remove(user);
            await _unitOfWork.Complete();
        }

    }

    
}
