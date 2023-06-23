using Nomad.BusinessLogic.Interfaces;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Implementations
{
    public class ListingTypeService: IListingTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListingTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GetListingTypeByID(int id)
        {
            var data = await _unitOfWork.ListingTypeRepository.Get(id);
            if(data.Type == null)
            {
                throw new Exception("ListingType is null!");
            }

            return data.Type;
        }
    }
}
