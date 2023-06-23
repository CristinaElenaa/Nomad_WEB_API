using Microsoft.EntityFrameworkCore;
using Nomad.DataAccess.Data;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Interfaces;
using Nomad.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Implementations
{
    public class UserRepository: Repository<User>, IUserRepository   
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserWithPhotos(int id)
        {
            return await _dbContext.Users.Include(p => p.Photos).SingleOrDefaultAsync(u => u.Id ==id);
        }

        public async Task<bool> CheckIfUserExists(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return user != null;
        }
    }
}
