using Nomad.BusinessLogic.Interfaces;
using Nomad.DataAccess.Implementations;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Implementations
{
    public class PrivacyService: IPrivacyService
    {
        //private readonly IPrivacyRepository _privacyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PrivacyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GetPrivacyTypeByID(int id)
        {
            var privacy = await _unitOfWork.PrivacyRepository.Get(id);
            if(privacy == null)
            {
                throw new Exception("Privacy Type is null!");
            }

            return privacy.Type;
        }
    }
}
