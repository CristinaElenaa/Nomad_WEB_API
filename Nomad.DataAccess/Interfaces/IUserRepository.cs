using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
         Task<User> GetUserWithPhotos(int id);
         Task<bool> CheckIfUserExists(int id);
    }
}
