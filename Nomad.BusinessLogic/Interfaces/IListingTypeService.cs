using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Interfaces
{
    public interface IListingTypeService
    {
        Task<string> GetListingTypeByID(int id);
    }
}
