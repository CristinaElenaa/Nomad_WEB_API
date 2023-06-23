using Nomad.DataAccess.Data;
using Nomad.DataAccess.Entities;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Implementations
{
    public class PrivacyRepository: Repository<PrivacyType>, IPrivacyRepository
    {
        public PrivacyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        //public async Task<string> GetPrivacyTypeByID(int id)
        //{
        //    var data = await _dbContext.PrivacyTypes.Find(id);

        //    return data.Type;
        //}
    }
}
