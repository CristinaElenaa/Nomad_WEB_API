using Nomad.BusinessLogic.Models;
using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserModel>> GetAllUsers();
        //public Task<UserModel> GetUserByFullName(string firstName, string lastName);
        //public Task<UserModel> GetUserByEmail(string userEmail);
        public Task<UserModel> GetUserById(int id);
        //public Task<int> GetUserIdByFullName(string userFirstName, string userLastName);
        //public Task<int> GetUserIdByEmail(string userEmail);
        public Task UpdateUser(UpdateUserModel updateUserModel);
        public Task Add(RegisterModel registerModel);
        public Task<UserModel> Login(LoginModel loginModel);
        public Task RemoveUser(int userId);


    }
}
