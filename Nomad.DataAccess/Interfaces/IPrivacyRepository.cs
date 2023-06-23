using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IPrivacyRepository: IRepository<PrivacyType>
    {
        //Task<string> GetPrivacyTypeByID(int id);
    }
}
