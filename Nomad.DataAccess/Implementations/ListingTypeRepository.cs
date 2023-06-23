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
    public class ListingTypeRepository: Repository<ListingType>, IListingTypeRepository
    {

        public ListingTypeRepository(ApplicationDbContext dbContext):base(dbContext) { }


    }
}
